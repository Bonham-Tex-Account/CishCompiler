using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CishCompiler.Parsing
{
    public abstract class IParsingNode
    {
    }

    public abstract class INonTerminalNode : IParsingNode
    {
        public List<IParsingNode> Children { get; set; }

        public INonTerminalNode()
        {
            Children = new List<IParsingNode>();
        }
    }
    public class RootNode : INonTerminalNode
    {
    }
    public class Expression : INonTerminalNode
    {

    }
    public class ValueExpression : INonTerminalNode
    {

    }
    public class NoEXValueExpression : INonTerminalNode
    {

    }
    public class CompExpression : INonTerminalNode
    {

    }
}
