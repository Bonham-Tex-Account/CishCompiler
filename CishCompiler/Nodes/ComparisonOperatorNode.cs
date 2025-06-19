namespace CishCompiler.Nodes
{
    /*
            EqualOperator,
            NotEqualOperator,
            GreaterThanOperator,
            LessThanOperator,
            GreaterThanOrEqualOperator,
            LessThanOrEqualOperator,
            AndAndOperator,
            OrOrOperator,
    */
    public interface IComparisonOperatorNode : ITerminalNode
    {
    }
    public class EqualOperatorNode : IComparisonOperatorNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public EqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        
    }
    public class NotEqualOperatorNode : IComparisonOperatorNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public NotEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
    }
    public class GreaterThanOperatorNode : IComparisonOperatorNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public GreaterThanOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
    }
    public class LessThanOperatorNode : IComparisonOperatorNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public LessThanOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
    }
    public class GreaterThanOrEqualOperatorNode : IComparisonOperatorNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public GreaterThanOrEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
    }
    public class LessThanOrEqualOperatorNode : IComparisonOperatorNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public LessThanOrEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
    }
    public class AndAndOperatorNode : IComparisonOperatorNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public AndAndOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
    }
    public class OrOrOperatorNode : IComparisonOperatorNode
    {
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public OrOrOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
    }
}
