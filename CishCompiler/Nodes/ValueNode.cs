namespace CishCompiler.Nodes
{
    public class ValueNode : TokenNode
    {
        public ValueNode() : base()
        {
        }

        public ValueNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class NumberLiteralNode : ValueNode
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
    public class StringLiteralNode : ValueNode
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
