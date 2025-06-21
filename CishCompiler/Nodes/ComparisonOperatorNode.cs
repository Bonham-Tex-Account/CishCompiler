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
    public class IComparisonOperatorNode : ITokenNode
    {
        public IComparisonOperatorNode() : base()
        {
        }
        public IComparisonOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class EqualOperatorNode : IComparisonOperatorNode
    {
        public EqualOperatorNode() : base()
        {
        }
        public EqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class NotEqualOperatorNode : IComparisonOperatorNode
    {
        public NotEqualOperatorNode() : base()
        {
        }
        public NotEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class GreaterThanOperatorNode : IComparisonOperatorNode
    {
        public GreaterThanOperatorNode() : base()
        {
        }

        public GreaterThanOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class LessThanOperatorNode : IComparisonOperatorNode
    {
        public LessThanOperatorNode() : base()
        {
        }

        public LessThanOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class GreaterThanOrEqualOperatorNode : IComparisonOperatorNode
    {
        public GreaterThanOrEqualOperatorNode() : base()
        {
        }

        public GreaterThanOrEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class LessThanOrEqualOperatorNode : IComparisonOperatorNode
    {
        public LessThanOrEqualOperatorNode() : base()
        {
        }

        public LessThanOrEqualOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class AndAndOperatorNode : IComparisonOperatorNode
    {
        public AndAndOperatorNode() : base()
        {
        }

        public AndAndOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OrOrOperatorNode : IComparisonOperatorNode
    {
        public OrOrOperatorNode() : base()
        {
        }

        public OrOrOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
}
