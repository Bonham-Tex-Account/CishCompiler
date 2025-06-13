using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class FunctionToken : Token
    {
        public override string RegexPattern => throw new NotImplementedException();
        public FunctionToken(string value, int lineNumber) : base(value, lineNumber)
        {
        }
    }
}
