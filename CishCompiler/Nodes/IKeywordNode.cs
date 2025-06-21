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
    public class IKeywordNode : ITokenNode
    {
        public IKeywordNode() : base() { }
        public IKeywordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class MAINKeyWordNode : IKeywordNode
    {
        public MAINKeyWordNode() : base()
        {
        }
        public MAINKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {

        }
    }

    public class IFKeyWordNode : IKeywordNode
    {
        public IFKeyWordNode() : base() { }
        public IFKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {

        }

        
    }
    public class IFELSEKeyWordNode : IKeywordNode
    {
        public IFELSEKeyWordNode() : base() { }

        public IFELSEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class ELSEKeyWordNode : IKeywordNode
    {
        public ELSEKeyWordNode() : base() { }

        public ELSEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class FORKeyWordNode : IKeywordNode
    {
        public FORKeyWordNode() : base()
        {
        }

        public FORKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class RETURNKeyWordNode : IKeywordNode
    {
        public RETURNKeyWordNode() : base()
        {
        }

        public RETURNKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CLASSKeyWordNode : IKeywordNode
    {
        public CLASSKeyWordNode() : base()
        {
        }

        public CLASSKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class VARKeyWordNode : IKeywordNode
    {
        public VARKeyWordNode() : base()
        {
        }

        public VARKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class BREAKKeyWordNode : IKeywordNode
    {
        public BREAKKeyWordNode() : base()
        {
        }

        public BREAKKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class CONTINUEKeyWordNode : IKeywordNode
    {
        public CONTINUEKeyWordNode() : base()
        {
        }

        public CONTINUEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class GOTOKeyWordNode : IKeywordNode
    {
        public GOTOKeyWordNode() : base()
        {
        }

        public GOTOKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class WHILEKeyWordNode : IKeywordNode
    {
        public WHILEKeyWordNode() : base()
        {
        }

        public WHILEKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class INPUTKeyWordNode : IKeywordNode
    {
        public INPUTKeyWordNode() : base()
        {
        }

        public INPUTKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class OUTPUTKeyWordNode : IKeywordNode
    {
        public OUTPUTKeyWordNode() : base()
        {
        }

        public OUTPUTKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
    public class FNCKeyWordNode : IKeywordNode
    {
        public FNCKeyWordNode() : base()
        {
        }

        public FNCKeyWordNode(ReadOnlyMemory<char> value, int lineNumber, int tokenNumber) : base(value, lineNumber, tokenNumber)
        {
        }
    }
}
