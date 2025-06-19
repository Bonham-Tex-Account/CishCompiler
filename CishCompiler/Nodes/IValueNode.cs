namespace CishCompiler.Nodes
{
    public interface IValueNode : ITerminalNode
    {
    }
    public class NumberLiteralNode : IValueNode
    {
        public NumberLiteralNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
        }
        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class StringLiteralNode : IValueNode
    {
        public StringLiteralNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
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
