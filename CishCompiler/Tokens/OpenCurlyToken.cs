using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class OpenCurlyToken: Token
    {
        public OpenCurlyToken(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
        public override string RegexPattern => "\\{";
    }
}
