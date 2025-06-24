using CishCompiler.Lexing;
using System.Security.Cryptography.X509Certificates;

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
    public class KeywordNode : TokenNode
    {
        public KeywordNode() : base() { }
        public KeywordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MAINKeyWordNode : KeywordNode
    {
        public MAINKeyWordNode() : base()
        {
        }
        public MAINKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {

        }
    }

    public class IFKeyWordNode : KeywordNode
    {
        public IFKeyWordNode() : base() { }
        public IFKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {

        }

        
    }
    public class IFELSEKeyWordNode : KeywordNode
    {
        public IFELSEKeyWordNode() : base() { }

        public IFELSEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class ELSEKeyWordNode : KeywordNode
    {
        public ELSEKeyWordNode() : base() { }

        public ELSEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class FORKeyWordNode : KeywordNode
    {
        public FORKeyWordNode() : base()
        {
        }

        public FORKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class RETURNKeyWordNode : KeywordNode
    {
        public RETURNKeyWordNode() : base()
        {
        }

        public RETURNKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CLASSKeyWordNode : KeywordNode
    {
        public CLASSKeyWordNode() : base()
        {
        }

        public CLASSKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class VARKeyWordNode : KeywordNode
    {
        public VARKeyWordNode() : base()
        {
        }

        public VARKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class BREAKKeyWordNode : KeywordNode
    {
        public BREAKKeyWordNode() : base()
        {
        }

        public BREAKKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CONTINUEKeyWordNode : KeywordNode
    {
        public CONTINUEKeyWordNode() : base()
        {
        }

        public CONTINUEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class GOTOKeyWordNode : KeywordNode
    {
        public GOTOKeyWordNode() : base()
        {
        }

        public GOTOKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class WHILEKeyWordNode : KeywordNode
    {
        public WHILEKeyWordNode() : base()
        {
        }

        public WHILEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class INPUTKeyWordNode : KeywordNode
    {
        public INPUTKeyWordNode() : base()
        {
        }

        public INPUTKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OUTPUTKeyWordNode : KeywordNode
    {
        public OUTPUTKeyWordNode() : base()
        {
        }

        public OUTPUTKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class FNCKeyWordNode : KeywordNode
    {
        public FNCKeyWordNode() : base()
        {
        }

        public FNCKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
}
