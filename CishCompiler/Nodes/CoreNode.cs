
namespace CishCompiler.Nodes
{
    public class IdentifierNode : TokenNode
    {
        public IdentifierNode() : base()
        {
        }

        public IdentifierNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class IntegerNode : ObjectNode
    {
        public IntegerNode() : base()
        {
        }
        public IntegerNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class StringNode : ObjectNode
    {
        public StringNode() : base()
        {
        }
        public StringNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class ObjectNode : TokenNode
    {
        public ObjectNode() : base()
        {
        }

        public ObjectNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class FunctionNode : TokenNode
    {
        public FunctionNode() : base()
        {
        }

        public FunctionNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class ErrorNode : TokenNode
    {
        public ErrorNode() : base()
        {
        }

        public ErrorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
}
