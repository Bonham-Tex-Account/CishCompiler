using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class KeywordToken: Token
    {
        public override string RegexPattern => throw new NotImplementedException("Get the Regex from GPT to be Lazy");
        public KeywordToken(string value, int lineNumber) : base(value, lineNumber)
        {

        }
    }
}
