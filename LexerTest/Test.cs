using CishCompiler.Lexing;
using CishCompiler.Parsing;
using CishCompiler.SemanticAnalysis;
using CishCompiler.CodeGen;
namespace LexerTest
{
    public class Test
    {
        [Fact]
        public void TestFile()
        {
            // Correct the file extension spelling error from "cish" to "cs"
            string[] codeLines = File.ReadAllLines(Path.Combine(RepoRoot(), "CishCompiler", "CishSmallProjects", "Test.cish"));
            //string[] codeLines = File.ReadAllLines(Path.Combine(RepoRoot(), "CishCompiler", "CishSmallProjects", "GuessingGame.cish"));
            var lexedNodes = Lexer.TokenizeInputCode(codeLines);
            ;
            var ast = Parser.ParseFile(lexedNodes);
            ;
            var semanticErrors = SemanticAnalysiser.Analyze(ast);
            ;
            var codeLinesGenerated = CodeGeneration.GenerateMainMethod(ast.Root);
            ;
            File.WriteAllLines(Path.Combine(RepoRoot(), "CishCompiler", "TestSharpLabIl", "Il.txt"), codeLinesGenerated);

        }

        static string RepoRoot()
        {
            DirectoryInfo? dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null)
            {
                if (File.Exists(Path.Combine(dir.FullName, "CishCompiler.sln")))
                {
                    return dir.FullName;
                }
                dir = dir.Parent;
            }
            throw new DirectoryNotFoundException("CishCompiler.sln not found above " + AppContext.BaseDirectory);
        }
    }
}