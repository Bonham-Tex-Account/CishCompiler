using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class CloseParenToken: Token
    {
        public CloseParenToken(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
        public override string RegexPattern => "\\)";
    }
    
    
}
