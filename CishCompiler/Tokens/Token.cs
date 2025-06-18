using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CishCompiler.Lexer;

namespace CishCompiler.Tokens
{
    public  class Token
    {
        public ReadOnlyMemory<char> Value { get; private set; } // convert to span if needed for performance
        public int LineNumber { get; private set; }
        public int TokenNumber { get; private set; }

        public TokenType tokenType { get; private set; }


        public Token( ReadOnlyMemory<char> value, int lineNumber, int tokenNumber,TokenType tokenType)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
            this.tokenType = tokenType;
        }
        public static bool IsRegexMatch(ReadOnlySpan<char> input,string regexPattern)
        {
            if (input == null || regexPattern == null)
                throw new ArgumentNullException("Input and pattern cannot be null.");

            return Regex.IsMatch(input, regexPattern);
        }
        

        public override string ToString()
        {
            return $"{Value} (Line: {LineNumber}) (Token: {TokenNumber})";
        }
    }
}
