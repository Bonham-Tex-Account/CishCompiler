
namespace CishCompiler.Nodes
{
    public class ArrhythmicOperatorNode : TokenNode
    {
        public ArrhythmicOperatorNode() : base()
        {
        }

        public ArrhythmicOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class PlusOperatorNode : ArrhythmicOperatorNode
    {
        public PlusOperatorNode() : base()
        {
        }

        public PlusOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MinusOperatorNode : ArrhythmicOperatorNode
    {
        public MinusOperatorNode() : base()
        {
        }

        public MinusOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class DivideOperatorNode : ArrhythmicOperatorNode
    {
        public DivideOperatorNode() : base()
        {
        }

        public DivideOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MultiplyOperatorNode : ArrhythmicOperatorNode
    {
        public MultiplyOperatorNode() : base()
        {
        }
        public MultiplyOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class AndOperatorNode : ArrhythmicOperatorNode
    {
        public AndOperatorNode() : base()
        {
        }

        public AndOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OrOperatorNode : ArrhythmicOperatorNode
    {
        public OrOperatorNode() : base()
        {
        }
        public OrOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class NotOperatorNode : ArrhythmicOperatorNode
    {
        public NotOperatorNode() : base()
        {
        }
        public NotOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }

}
