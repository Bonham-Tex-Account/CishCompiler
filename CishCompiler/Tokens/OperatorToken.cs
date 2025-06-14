using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CishCompiler.Tokens
{
    public class OperatorToken : Token
    {
        public OperatorToken(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }

        public override string RegexPattern => "([!@*/><=+\\-&^])(?:=|\\1)?";

       
    }
}
