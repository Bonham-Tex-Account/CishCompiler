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

        public override string RegexPattern => throw new NotImplementedException("Get the Regex from GPT to be Lazy");//will be done later when I have decided all the keywords

        
    }
}
