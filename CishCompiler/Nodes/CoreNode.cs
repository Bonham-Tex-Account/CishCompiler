
namespace CishCompiler.Nodes
{
    public class IdentifierNode : ITokenNode
    {
        public IdentifierNode() : base()
        {
        }

        public IdentifierNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class ObjectNode : ITokenNode
    {
        public ObjectNode() : base()
        {
        }

        public ObjectNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class FunctionNode : ITokenNode
    {
        public FunctionNode() : base()
        {
        }

        public FunctionNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class ErrorNode : ITokenNode
    {
        public ErrorNode() : base()
        {
        }

        public ErrorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
}
