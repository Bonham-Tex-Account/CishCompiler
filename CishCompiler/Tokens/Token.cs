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
        public string Value { get; private set; } // convert to span if needed for performance
        public int LineNumber { get; private set; }

        public abstract string RegexPattern { get; }


        public Token(string value, int lineNumber)
        {
            Value = value;
            LineNumber = lineNumber;

        }
        public bool IsRegexMatch(string input)
        {
            if (input == null || RegexPattern == null)
                throw new ArgumentNullException("Input and pattern cannot be null.");

            return Regex.IsMatch(input, RegexPattern);
        }

        public override string ToString()
        {
            return $"{Value} (Line: {LineNumber})";
        }
    }
}
