
# CompilerCamp: the Cish compiler

Cish is a small C-like teaching language. This repository is a hand-written compiler for it, in C# on .NET 8, that turns a `.cish` source file into textual CIL (Common Intermediate Language) which `ilasm.exe` can assemble into a runnable Windows executable.

Everything below was verified by running the code on 2026-09-09. Sections marked *works* were exercised end to end; sections marked *known issue* reproduce on demand.

## Pipeline

| Stage | Entry point | Output |
|-------|-------------|--------|
| Lexing | `Lexer.TokenizeInputCode(string[] lines)` | flat `List<TokenNode>` including whitespace tokens |
| Parsing | `Parser.ParseFile(List<TokenNode>)` | concrete syntax tree, rotated for operator precedence, then converted to an `AbstractSyntaxTree` |
| Semantic analysis | `SemanticAnalysiser.Analyze(AbstractSyntaxTree)` | scope tree plus a `List<ErrorData>` of type and scope errors |
| Code generation | `CodeGeneration.GenerateMainMethod(ASTNode root)` | `List<string>` of CIL lines for a single static `Main` |

## Quick start

```
dotnet build CishCompiler.sln
dotnet run --project CishRunner -- --all --assemble
dotnet run --project CishRunner -- Arithmetic --run
dotnet test
```

`CishRunner` is a console project that runs the whole pipeline on one file and prints every stage. It resolves bare names against `CishCompiler/CishSmallProjects`, or takes a path.

```
CishRunner <file.cish | sample-name> [--tokens] [--out <path.il>] [--assemble] [--run]
CishRunner --all [--assemble]

  --tokens     also print the lexer output
  --out        write the generated IL to a file
  --assemble   write the IL and assemble it with the .NET Framework ilasm.exe
  --run        assemble, then run the produced .exe with stdin forwarded
  --all        run every sample and print a one-line summary per sample

Exit codes: 0 ok, 1 pipeline or semantic failure, 2 pipeline timeout, 3 ilasm failure
```

The parser has no error recovery and loops forever on any syntax error, so the runner bounds each pipeline run to 10 seconds and reports `TIMEOUT` instead of hanging. Assembly uses `%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\ilasm.exe`, which ships with Windows; the IL and `.exe` land in `%TEMP%\CishRunner\`.

## Current results on the bundled samples

Output of `dotnet run --project CishRunner -- --all --assemble`:

```
Sample             Lex            Parse     Semantic    IL         ilasm
Arithmetic         ok             ok        0 error(s)  52 lines   ok
ArrayManip         17 bad token(s) TIMEOUT   -           -          -
Counter            ok             ok        0 error(s)  53 lines   ok
GuessingGame       ok             ok        0 error(s)  66 lines   ok
Test               ok             ok        0 error(s)  19 lines   FAIL
ArrayManip: timed out in stage 'parse'
Test: ilasm failed: ...\Test.il(15) : error : syntax error at token 'ldc.i4' in: ldc.i4.10
3/5 sample(s) compiled.
```

| Sample | What it shows |
|--------|---------------|
| `Arithmetic.cish` | Int declarations, `+`, `IF` with `>`, string `OUTPUT`. Assembles and runs, printing `big` then `done`. |
| `Counter.cish` | `WHILE` with `<`, reassignment inside the loop body. Assembles and runs, printing `tick` three times then `end`. |
| `GuessingGame.cish` | String variables, `WHILE`, nested `IF`, `INPUT`. Assembles and runs, but both strings start equal so the loop body is skipped and it prints `Congratulations!` immediately. |
| `Test.cish` | Scratch file used by the xunit test. Its literal `10` hits the `ldc.i4.N` bug listed below. |
| `ArrayManip.cish` | Aspirational. Uses `INT`, arrays, `FOR`, `+=`, function parameters and calls, none of which the compiler supports yet. |

Example of a full single-file run (`dotnet run --project CishRunner -- Arithmetic --run`):

```
== AST
BodyNode
\-- MAINKeyWordNode 'MAIN'
    \-- BodyNode
        |-- AssignmentOperatorNode '='
        |   |-- IntegerNode 'Int'
        |   |-- IdentifierNode 'a'
        |   \-- NumberLiteralNode '3'
        ...
        |-- IFKeyWordNode 'IF'
        |   |-- GreaterThanOperatorNode '>'
        |   |   |-- IdentifierNode 'c'
        |   |   \-- IdentifierNode 'd'
        |   \-- BodyNode
        |       \-- OUTPUTKeyWordNode 'OUTPUT'
        |           \-- StringLiteralNode '"big"'
        \-- OUTPUTKeyWordNode 'OUTPUT'
            \-- StringLiteralNode '"done"'
== Semantic analysis: 0 error(s)
== IL (52 lines)
...
== Assembled to C:\Users\...\Temp\CishRunner\Arithmetic.exe
== Running (stdin is forwarded to the program)
big
done
== Program exited with code 0
```

Example of semantic errors being reported (a mismatched declaration and an undeclared name):

```
== Semantic analysis: 4 error(s)
  line 5, token 3: Type mismatch: 'b' is of type 'Int' but 's' is of type 'String'.
  line 6, token 7: Symbol 'd' not found in scope 5.
  line 6, token 7: Type mismatch: 'd' is of type 'Unknown' but '1' is of type 'Int'.
  line 6, token 3: Type mismatch: 'c' is of type 'Int' but '+' is of type 'Unknown'.
```

## The language as it works today

Source rules:

- Every token must be separated by whitespace. `a=1` is one unrecognised token; `a = 1` is three tokens. The one exception is a function name, which is lexed together with its opening parenthesis (`Sum(`).
- Identifiers are lowercase letters and dots: `[a-z.]+`.
- Type names are capitalised words: `Int`, `String`. Any other `[A-Z][a-z]*` word lexes as a generic object type.
- Number literals are digits with an optional fraction. Only integers 0 to 8 survive code generation (see known issues).
- String literals are double-quoted and cannot contain whitespace, because the lexer splits on whitespace first.
- Statements end with ` ;` and blocks are `{ ... }`. Comments start with `//`.
- The whole program is one `MAIN { ... }` block.

Supported statements inside `MAIN`:

| Statement | Form | Lexer | Parser | Semantic | Codegen | Runs |
|-----------|------|:-----:|:------:|:--------:|:-------:|:----:|
| Declaration | `Int x = expr ;` / `String s = expr ;` | yes | yes | yes | yes | yes |
| Assignment | `x = expr ;` | yes | yes | yes | yes | yes |
| Output | `OUTPUT expr ;` | yes | yes | yes | yes | strings only |
| Input | `INPUT x ;` | yes | yes | yes | yes | into `String` only |
| If | `IF cond { ... }` (no else) | yes | yes | partial | yes | yes |
| While | `WHILE cond { ... }` | yes | yes | partial | yes | yes |
| Function | `FNC Type Name( ) { ... RETURN expr ; }` | yes | yes | no scope | no | no |
| Class | `CLASS Name { ... }` | yes | yes | crashes in AST conversion | no | no |

Expressions:

| Category | Tokens lexed | Codegen supports |
|----------|--------------|------------------|
| Arithmetic | `+ - * / & \| !` | `+` `-` |
| Comparison | `== != > < >= <= && \|\|` | `== != > <` |
| Compound assignment | `+= -= *= /= &= \|=` | none |
| Grouping | `( expr )` | yes |

Arithmetic precedence is handled by a tier on each operator node (`+ -` tier 1, `* /` tier 2, `& \|` tier 3) and a left rotation pass after parsing.

Keywords that are lexed but have no grammar rule yet: `IFELSE`, `ELSE`, `FOR`, `VAR`, `BREAK`, `CONTINUE`, `GOTO`.

## Known issues

Each of these was reproduced with the runner.

1. **Any syntax error hangs the parser.** `ParseTokensToCST` restarts from token 0 when the top-level expression fails, so a missing `;` or an unrecognised token loops forever. The runner's 10 second timeout is the only guard.
2. **Identifiers inside `IF` / `WHILE` scopes resolve to type `Unknown`.** `SemanticAnalysiser.GetType` walks parent scopes to confirm the symbol exists, then looks the type up in the innermost scope only. Comparing an inner-scope identifier to a literal (`IF c > 5`) is reported as a type mismatch; comparing two identifiers passes only because both sides are `Unknown`. Assigning `i = i + 1` inside a loop also fails; `i = i + one` with `Int one = 1 ;` declared outside works.
3. **Integer literals above 8 produce invalid IL.** Codegen emits `ldc.i4.<value>`, and CIL only defines that short form for 0 to 8. `Int a = 10 ;` assembles with a syntax error.
4. **Only `+ - == != > <` reach code generation.** Any other operator throws `KeyNotFoundException` from `CodeLibrary.Library`.
5. **`OUTPUT` of an `Int` crashes at runtime.** Codegen always calls `Console.WriteLine(string)`, so an int on the stack becomes a null string reference. `INPUT` into an `Int` has the mirror problem.
6. **`<` and `>` on strings compare references.** They assemble and run but the result is meaningless.
7. **`FNC` bodies are inlined into `Main`.** Codegen has no function support; the body statements are emitted as if they were part of `MAIN`.
8. **Trailing whitespace on the last line throws.** The token-skipping loop in `ParseSingleExpression` walks past the end of the token list.
9. **Local slots are a flat list.** Same-named variables in different scopes share the last slot found, so shadowing is not supported.
10. **Generated IL references `[System.Runtime]System.Object` without declaring it.** ilasm autodetects and warns; it does not fail.

## Repository layout

```
CishCompiler.sln
CishCompiler/                 class library: the compiler
  Lexing/                     Lexer, TokenType enum
  Nodes/                      TokenNode hierarchy (keywords, operators, literals, punctuation)
  Parsing/                    Parser, ParsingGrammar, ParsingNode (CST and AST node types)
  SemanticAnalysis/           SemanticAnalysiser, ScopeNode, Symbol, ErrorData
  CodeGen/                    CodeGeneration, CodeLibrary (operator to opcode map)
  CishSmallProjects/          sample .cish programs
  TestSharpLabIl/Il.txt       IL written by the xunit test, for pasting into SharpLab
CishRunner/                   console runner described above
LexerTest/                    xunit project with one smoke test that runs the pipeline on Test.cish
```

The xunit test locates files relative to the solution, so it runs from any checkout location. It has no assertions; it passes if the pipeline does not throw.
=======
# CishCompiler
 
A compiler for **Cish**, a custom C-family language, written in C#. Cish compiles to
.NET CIL, which means compiled programs run on the .NET runtime and can be inspected
with standard IL decompilation tools — making the full pipeline, from source text to
executable IL, observable end to end.
 
## Language
 
Cish is deliberately small. It resembles C# with a stricter, more regular grammar
(designed to keep parsing unambiguous) and a reduced feature set:
 
**Supported:** variables, arithmetic and boolean expressions, `if` / `while` control
flow, and console input/output.
 
**Out of scope (by design):** classes and user-defined functions. The goal of the
project is a complete, working pipeline over a small language — not a large language
with an incomplete pipeline.
 
### Example
 
<!-- TODO: paste a real, working Cish program here (10–15 lines).
     The GuessingGame test program is a good candidate — a program with
     input, a loop, and a conditional shows the whole language at once. -->
 
```
[real Cish code sample goes here]
```
 
## Compiler pipeline
 
Source text moves through five stages:
 
1. **Lexer** — tokenizes the source
2. **Parser** — builds a syntax tree from the token stream
3. **AST construction** — abstracts the parse tree into a semantic tree
4. **Semantic analysis** — type and validity checks over the AST
5. **Code generation** — emits .NET CIL
Each stage is covered by unit tests, and end-to-end tests compile and execute
sample programs (including a number-guessing game) to verify observable behavior,
not just internal structure.
 
## Building and running
 
<!-- TODO: replace with your actual commands / project names -->
 
```bash
dotnet build
dotnet test
# compile a Cish source file:
[actual invocation goes here]
```
 
## Status
 
Active pipeline complete for the supported feature set (2025–2026). Possible future
directions: functions, additional types, and IL-level optimization passes.
 
## Why CIL as the target?
 
Targeting CIL instead of a toy VM means the output is real: it runs on a production
runtime, benefits from the JIT, and can be round-tripped through decompilers to see
exactly what the code generator produced. It also made the code generator honest —
the .NET runtime rejects malformed IL loudly.
 

