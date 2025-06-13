using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class ObjectToken : Token
    {
        public override string RegexPattern => throw new NotImplementedException();
        public ObjectToken(string value, int lineNumber) : base(value, lineNumber)
        {
        }
    }
}
