
namespace CishCompiler.Nodes
{
    public class IArrhythmicOperatorNode : ITokenNode
    {
        public IArrhythmicOperatorNode() : base()
        {
        }

        public IArrhythmicOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class PlusOperatorNode : IArrhythmicOperatorNode
    {
        public PlusOperatorNode() : base()
        {
        }

        public PlusOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MinusOperatorNode : IArrhythmicOperatorNode
    {
        public MinusOperatorNode() : base()
        {
        }

        public MinusOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class DivideOperatorNode : IArrhythmicOperatorNode
    {
        public DivideOperatorNode() : base()
        {
        }

        public DivideOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MultiplyOperatorNode : IArrhythmicOperatorNode
    {
        public MultiplyOperatorNode() : base()
        {
        }
        public MultiplyOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class AndOperatorNode : IArrhythmicOperatorNode
    {
        public AndOperatorNode() : base()
        {
        }

        public AndOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OrOperatorNode : IArrhythmicOperatorNode
    {
        public OrOperatorNode() : base()
        {
        }
        public OrOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class NotOperatorNode : IArrhythmicOperatorNode
    {
        public NotOperatorNode() : base()
        {
        }
        public NotOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }

}
