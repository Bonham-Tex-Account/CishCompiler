using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Nodes
{
    public interface IPunctuationNode : ITerminalNode
    {
    }
    public class SpaceNode : ITerminalNode
    {
        public SpaceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class CommaNode : IPunctuationNode
    {
        public CommaNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class EndLineNode : IPunctuationNode
    {
        public EndLineNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class OpenParenthesisNode : IPunctuationNode
    {
        public OpenParenthesisNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class CloseParenthesisNode : IPunctuationNode
    {
        public CloseParenthesisNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class OpenBraceNode : IPunctuationNode
    {
        public OpenBraceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class CloseBraceNode : IPunctuationNode
    {
        public CloseBraceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class  CommentNode:IPunctuationNode
    {
        public CommentNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }

}
