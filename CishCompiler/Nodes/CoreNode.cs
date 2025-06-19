namespace CishCompiler.Nodes
{
    public class IdentifierNode : ITerminalNode
    {
        public IdentifierNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class ObjectNode : ITerminalNode
    {
        public ObjectNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class FunctionNode : ITerminalNode
    {
        public FunctionNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class ErrorNode : ITerminalNode
    {
        public ErrorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
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
