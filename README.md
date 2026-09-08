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
 
