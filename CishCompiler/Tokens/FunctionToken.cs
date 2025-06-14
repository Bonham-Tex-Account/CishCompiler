using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class FunctionToken : Token
    {
        public override string RegexPattern => "\\b[A-Z][a-z]*\\b\\(";
        public FunctionToken(string value, int lineNumber) : base(value, lineNumber)
        {
        }
    }
}
