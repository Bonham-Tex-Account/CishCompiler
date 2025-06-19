using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CishCompiler.Lexing.Lexer;

namespace CishCompiler.Nodes
{
    public interface INode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
       // public static string regexPattern { get; } 
    }
}
