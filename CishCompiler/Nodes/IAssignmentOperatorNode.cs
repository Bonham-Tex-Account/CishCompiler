namespace CishCompiler.Nodes
{
    public interface IAssignmentOperatorNode : ITerminalNode
    {
    }
    public class AssignmentOperatorNode : IAssignmentOperatorNode
    {
        public AssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class PlusAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public PlusAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class MinusAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public MinusAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class DivideAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public DivideAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class MultiplyAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public MultiplyAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class AndAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public AndAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class OrAssignmentOperatorNode : IAssignmentOperatorNode
    {
        public OrAssignmentOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
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
