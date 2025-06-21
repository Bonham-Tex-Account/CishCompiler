namespace CishCompiler.Nodes
{
    public class IValueNode : ITokenNode
    {
        public IValueNode() : base()
        {
        }

        public IValueNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class NumberLiteralNode : IValueNode
    {
        public NumberLiteralNode() : base()
        {
        }

        public NumberLiteralNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        
    }
    public class StringLiteralNode : IValueNode
    {
        public StringLiteralNode() : base()
        {
        }

        public StringLiteralNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
       
    }
}
