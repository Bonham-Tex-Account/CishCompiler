using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    class ValueToken : Token
    {
        public override string RegexPattern => "\\b\\d+(\\.\\d+)?\\b|\"([^\"]*)\"";
        public ValueToken(string value, int lineNumber) : base(value, lineNumber)
        {
        }
    }
}
