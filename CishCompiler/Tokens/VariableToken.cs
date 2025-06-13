using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class VariableToken : Token
    {
        public override string RegexPattern => throw new NotImplementedException();
        public VariableToken(string value, int lineNumber) : base(value, lineNumber)
        {
        }

        
    }
}
