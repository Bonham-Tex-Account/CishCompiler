
namespace CishCompiler.Nodes
{
    public class ArrhythmicOperatorNode : TokenNode
    {
        public ArrhythmicOperatorNode() : base()
        {
            Tier = 1; // Default tier for arrhythmic operators
        }
        public int Tier; // Default tie for arrhythmic operators
        public ArrhythmicOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
            Tier = 1; // Default tier for arrhythmic operators
        }
    }

    public class PlusOperatorNode : ArrhythmicOperatorNode
    {
        public PlusOperatorNode() : base()
        {
        }
        
        public PlusOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MinusOperatorNode : ArrhythmicOperatorNode
    {
        public MinusOperatorNode() : base()
        {
        }

        public MinusOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class DivideOperatorNode : ArrhythmicOperatorNode
    {
        public DivideOperatorNode() : base()
        {
            Tier = 2; // Override tier for divide operator
        }
        
        public DivideOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
            Tier = 2; // Override tier for divide operator
        }
    }
    public class MultiplyOperatorNode : ArrhythmicOperatorNode
    {
        public MultiplyOperatorNode() : base()
        {
            Tier = 2; // Override tier for multiply operator
        }
        
        public MultiplyOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
            Tier = 2; // Override tier for divide operator
        }
    }
    public class AndOperatorNode : ArrhythmicOperatorNode
    {
        public AndOperatorNode() : base()
        {
            Tier = 3; // Override tier for and operator
        }
       
        public AndOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
            Tier = 3; // Override tier for divide operator
        }
    }
    public class OrOperatorNode : ArrhythmicOperatorNode
    {
        public OrOperatorNode() : base()
        {
            Tier = 3; // Override tier for or operator
        }
       
        public OrOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
            Tier = 3; // Override tier for divide operator
        }
    }
    public class NotOperatorNode : ArrhythmicOperatorNode
    {
        public NotOperatorNode() : base()
        {
        }
        public NotOperatorNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }

}
