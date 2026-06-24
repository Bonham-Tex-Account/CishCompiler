using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.CodeGen
{
    public class CodeLibrary
    {
        public static Dictionary<string, string> Library = new Dictionary<string, string>
        {
            { "==", "ceq" },
            {"+","add" },
            { "-","sub"},
            { "!=","ceq        // pushes 1 if equal, 0 if not equal\r\nldc.i4.0   // push 0\r\nceq        // pushes 1 if previous result was 0 → means \"not equal\""},
            {">","cgt" },
            { "<","clt"}

        };
    }
}
