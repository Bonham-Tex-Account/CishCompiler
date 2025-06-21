namespace CishCompiler.Nodes
{
    public class IAssignmentOperatorNode : ITokenNode
    {
        public IAssignmentOperatorNode(): base()       
        {
        }
        public IAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class AssignmentOperatorNode : IAssignmentOperatorNode
    {
        public AssignmentOperatorNode() : base()
        {
        }

        public AssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class PlusAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public PlusAssignmentOperatorNode() : base()
        {
        }

        public PlusAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MinusAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public MinusAssignmentOperatorNode() : base()
        {
        }

        public MinusAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class DivideAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public DivideAssignmentOperatorNode() : base()
        {
        }

        public DivideAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MultiplyAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public MultiplyAssignmentOperatorNode() : base()
        {
        }

        public MultiplyAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class AndAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public AndAssignmentOperatorNode():base()
        {
        }

        public AndAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OrAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public OrAssignmentOperatorNode() : base()
        {
        }
        public OrAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }

}
