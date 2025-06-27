using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.SemanticAnalysis
{
    public class ErrorData
    {
        public int LineNumber { get; }
        public int TokenNumber { get; }
        public string ErrorMessage { get; }
        public ErrorData(int lineNumber, int tokenNumber, string message)
        {
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
            ErrorMessage = message;
        }

        
    }
}
