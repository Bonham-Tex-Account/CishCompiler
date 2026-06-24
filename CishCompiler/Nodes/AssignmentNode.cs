namespace CishCompiler.Nodes
{
    public class AssignmentNode : TokenNode
    {
        public AssignmentNode(): base()       
        {
        }
        public AssignmentNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class AssignmentOperatorNode : AssignmentNode
    {
        public AssignmentOperatorNode() : base()
        {
        }

        public AssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class PlusAssignmentOperatorNode : AssignmentNode
    {
        public PlusAssignmentOperatorNode() : base()
        {
        }

        public PlusAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MinusAssignmentOperatorNode : AssignmentNode
    {
        public MinusAssignmentOperatorNode() : base()
        {
        }

        public MinusAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class DivideAssignmentOperatorNode : AssignmentNode
    {
        public DivideAssignmentOperatorNode() : base()
        {
        }

        public DivideAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MultiplyAssignmentOperatorNode : AssignmentNode
    {
        public MultiplyAssignmentOperatorNode() : base()
        {
        }

        public MultiplyAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class AndAssignmentOperatorNode : AssignmentNode
    {
        public AndAssignmentOperatorNode():base()
        {
        }

        public AndAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OrAssignmentOperatorNode : AssignmentNode
    {
        public OrAssignmentOperatorNode() : base()
        {
        }
        public OrAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }

}
