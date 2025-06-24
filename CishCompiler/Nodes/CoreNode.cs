
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
