using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CishCompiler.Parsing
{
    public abstract class ParsingNode
    {
    }

    public abstract class INonTerminalNode : ParsingNode
    {
        public List<ParsingNode> Children { get; set; }

        public INonTerminalNode()
        {
            Children = new List<ParsingNode>();
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
