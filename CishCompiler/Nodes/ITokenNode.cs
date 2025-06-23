using CishCompiler.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CishCompiler.Lexing.Lexer;

namespace CishCompiler.Nodes
{
    public abstract class  ITokenNode:IParsingNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
       
        public ITokenNode()
        {
            Value = ReadOnlyMemory<char>.Empty;
            LineNumber = 0;
            TokenNumber = 0;
        }
        public ITokenNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
    }
}
