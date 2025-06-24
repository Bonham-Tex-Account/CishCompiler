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
    public class ComparisonOperatorNode : TokenNode
    {
        public ComparisonOperatorNode() : base()
        {
        }
        public ComparisonOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class EqualOperatorNode : ComparisonOperatorNode
    {
        public EqualOperatorNode() : base()
        {
        }
        public EqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class NotEqualOperatorNode : ComparisonOperatorNode
    {
        public NotEqualOperatorNode() : base()
        {
        }
        public NotEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class GreaterThanOperatorNode : ComparisonOperatorNode
    {
        public GreaterThanOperatorNode() : base()
        {
        }

        public GreaterThanOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class LessThanOperatorNode : ComparisonOperatorNode
    {
        public LessThanOperatorNode() : base()
        {
        }

        public LessThanOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class GreaterThanOrEqualOperatorNode : ComparisonOperatorNode
    {
        public GreaterThanOrEqualOperatorNode() : base()
        {
        }

        public GreaterThanOrEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class LessThanOrEqualOperatorNode : ComparisonOperatorNode
    {
        public LessThanOrEqualOperatorNode() : base()
        {
        }

        public LessThanOrEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class AndAndOperatorNode : ComparisonOperatorNode
    {
        public AndAndOperatorNode() : base()
        {
        }

        public AndAndOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OrOrOperatorNode : ComparisonOperatorNode
    {
        public OrOrOperatorNode() : base()
        {
        }

        public OrOrOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
}
