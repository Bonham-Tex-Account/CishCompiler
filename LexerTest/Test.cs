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
            string[] codeLines = File.ReadAllLines("C:\\Users\\Tex\\OneDrive\\Documents\\Visual Studio 2022\\Projects\\CompilerCamp\\CishCompiler\\CishSmallProjects\\Test.cish");//Test file
            //string[] codeLines = File.ReadAllLines("C:\\Users\\Tex\\OneDrive\\Documents\\Visual Studio 2022\\Projects\\CompilerCamp\\CishCompiler\\CishSmallProjects\\GuessingGame.cish");//guessing Game
            var lexedNodes = Lexer.TokenizeInputCode(codeLines);
            ;
            var ast = Parser.ParseFile(lexedNodes);
            ;
            var semanticErrors = SemanticAnalysiser.Analyze(ast);
            ;
            var codeLinesGenerated = CodeGeneration.GenerateMainMethod(ast.Root);
            ;
            File.WriteAllLines("C:\\Users\\Tex\\OneDrive\\Documents\\Visual Studio 2022\\Projects\\CompilerCamp\\CishCompiler\\TestSharpLabIl\\Il.txt", codeLinesGenerated);

        }

    }
}