using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public abstract class Token
    {
        public ReadOnlyMemory<char> Value { get; private set; } // convert to span if needed for performance
        public int LineNumber { get; private set; }
        public int TokenNumber { get; private set; }

        public abstract string RegexPattern { get; }


        public Token( ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
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
