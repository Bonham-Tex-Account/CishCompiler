using CishCompiler.Tokens;

namespace CishCompiler.Tokens
{
    public class LineEndToken : Token
    {
        public LineEndToken(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }

        public override string RegexPattern => ";";
    }
}