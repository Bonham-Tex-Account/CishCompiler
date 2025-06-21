using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Nodes
{
    public class IPunctuationNode : ITokenNode
    {
        public IPunctuationNode() : base()
        {
        }

        public IPunctuationNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class SpaceNode : IPunctuationNode
    {
        public SpaceNode() : base()
        {
        }

        public SpaceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CommaNode : IPunctuationNode
    {
        public CommaNode() : base()
        {
        }

        public CommaNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class EndLineNode : IPunctuationNode
    {
        

        public EndLineNode() : base()
        {
        }

        public EndLineNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OpenParenthesisNode : IPunctuationNode
    {
        public OpenParenthesisNode() : base()
        {
        }

        public OpenParenthesisNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CloseParenthesisNode : IPunctuationNode
    {
        public CloseParenthesisNode() : base()
        {
        }

        public CloseParenthesisNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OpenBraceNode : IPunctuationNode
    {
        public OpenBraceNode() : base()
        {
        }

        public OpenBraceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CloseBraceNode : IPunctuationNode
    {
        public CloseBraceNode() : base()
        {
        }

        public CloseBraceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CommentNode : IPunctuationNode
    {
        public CommentNode() : base()
        {
        }

        public CommentNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }

}
