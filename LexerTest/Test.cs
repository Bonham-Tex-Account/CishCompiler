
using CishCompiler;
using CishCompiler.Tokens;

namespace LexerTest
{
    public class Test
    {
        [Fact]
        public void TestFile()
        {
            // Correct the file extension spelling error from "cish" to "cs"
            string[] codeLines = File.ReadAllLines("C:\\Users\\Tex\\Documents\\Visual Studio 2022\\Projects\\CishCompiler\\CishCompiler\\CishSmallProjects\\Test.cish");
            var temp =Lexer.TokenizeInputCode(codeLines);
            ;
        }
        [Theory]
        [InlineData("C:\\Users\\Tex\\Documents\\Visual Studio 2022\\Projects\\CishCompiler\\CishCompiler\\CishSmallProjects\\Test.cish",typeof(ObjectToken),typeof(IdentifierToken),typeof(NonAssignmentOperatorToken),typeof(ValueToken),typeof(LineEndToken))]
        public void TestTokenization(string filepath, params Type[] types)
        {
            string[] codeLines = File.ReadAllLines(filepath);
            var tokens = Lexer.TokenizeInputCode(codeLines);
            Assert.NotEmpty(tokens);
            
        }
    }
}