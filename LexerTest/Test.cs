using CishCompiler.Lexing;
using CishCompiler.Parsing;
using CishCompiler.SemanticAnalysis;

namespace LexerTest
{
    public class Test
    {
        [Fact]
        public void TestFile()
        {
            // Correct the file extension spelling error from "cish" to "cs"
            string[] codeLines = File.ReadAllLines("C:\\Users\\Tex\\Documents\\Visual Studio 2022\\Projects\\CishCompiler\\CishCompiler\\CishSmallProjects\\Test.cish");
            var lexedNodes = Lexer.TokenizeInputCode(codeLines);
            ;
            var ast = Parser.ParseFile(lexedNodes);
            ;
            var semanticErrors = SemanticAnalysiser.Analyze(ast);
            ;
        }

    }
}