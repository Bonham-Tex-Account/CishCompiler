using CishCompiler.Lexing;

namespace CishCompiler.Nodes
{
    /*
            MAINKeyword,
            IFKeyword,
            IFELSEKeyword,
            ELSEKeyword,
            FORKeyword,
            RETURNKeyword,
            CLASSKeyword,
            VARKeyword,
            BREAKKeyword,
            CONTINUEKeyword,
            GOTOKeyword,
            WHILEKeyword,
            INPUTKeyword,
            OUTPUTKeyword,
            FNCKeyword,
    */
    public interface IKeywordNode : ITerminalNode
    {
    }
    public class MAINKeyWordNode : IKeywordNode
    {
        public MAINKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
          
        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
        public Lexer.TokenType tokenType { get; set; }

    }

    public class IFKeyWordNode : IKeywordNode
    {
        public IFKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;
            
        }

        public ReadOnlyMemory<char> Value { get; set ; }
        public int LineNumber { get ; set ; }
        public int TokenNumber { get; set; }
       
    }
    public class IFELSEKeyWordNode : IKeywordNode
    {
        public IFELSEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class ELSEKeyWordNode : IKeywordNode
    {
        public ELSEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class FORKeyWordNode : IKeywordNode
    {
        public FORKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class RETURNKeyWordNode : IKeywordNode
    {
        public RETURNKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class CLASSKeyWordNode : IKeywordNode
    {
        public CLASSKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class VARKeyWordNode : IKeywordNode
    {
        public VARKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class BREAKKeyWordNode : IKeywordNode
    {
        public BREAKKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class CONTINUEKeyWordNode : IKeywordNode
    {
        public CONTINUEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class GOTOKeyWordNode : IKeywordNode
    {
        public GOTOKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class WHILEKeyWordNode : IKeywordNode
    {
        public WHILEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class INPUTKeyWordNode : IKeywordNode
    {
        public INPUTKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class OUTPUTKeyWordNode : IKeywordNode
    {
        public OUTPUTKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            TokenNumber = tokenNumber;

        }

        public ReadOnlyMemory<char> Value { get; set; }
        public int LineNumber { get; set; }
        public int TokenNumber { get; set; }
    }
    public class FNCKeyWordNode : IKeywordNode
    {
        public FNCKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber)
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
