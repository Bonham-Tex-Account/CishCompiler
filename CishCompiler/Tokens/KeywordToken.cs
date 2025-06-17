using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class KeywordToken: Token
    {
        public KeywordToken(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }

        public override string RegexPattern => throw new NotImplementedException("\\b(?:MAIN|IFELSE|IF|ELSE|FOR|RETURN|CLASS|VAR|BREAK|CONTINUE|GOTO|WHILE|THEN|INPUT|OUTPUT|FNC)\\b");

        
    }
}
