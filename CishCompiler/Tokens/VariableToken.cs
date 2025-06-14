using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class VariableToken : Token
    {
        public override string RegexPattern => "\\b[a-z]+\\b";
        public VariableToken(string value, int lineNumber) : base(value, lineNumber)
        {
        }

        
    }
}
