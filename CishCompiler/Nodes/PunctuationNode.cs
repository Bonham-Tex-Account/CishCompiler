using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Nodes
{
    public class PunctuationNode : TokenNode
    {
        public PunctuationNode() : base()
        {
        }

        public PunctuationNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class SpaceNode : PunctuationNode
    {
        public SpaceNode() : base()
        {
        }

        public SpaceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CommaNode : PunctuationNode
    {
        public CommaNode() : base()
        {
        }

        public CommaNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class EndLineNode : PunctuationNode
    {
        

        public EndLineNode() : base()
        {
        }

        public EndLineNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OpenParenthesisNode : PunctuationNode
    {
        public OpenParenthesisNode() : base()
        {
        }

        public OpenParenthesisNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CloseParenthesisNode : PunctuationNode
    {
        public CloseParenthesisNode() : base()
        {
        }

        public CloseParenthesisNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OpenBraceNode : PunctuationNode
    {
        public OpenBraceNode() : base()
        {
        }

        public OpenBraceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CloseBraceNode : PunctuationNode
    {
        public CloseBraceNode() : base()
        {
        }

        public CloseBraceNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CommentNode : PunctuationNode
    {
        public CommentNode() : base()
        {
        }

        public CommentNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }

}
