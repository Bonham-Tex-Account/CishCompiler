using CishCompiler.Nodes;
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
    public class ASTNode : TokenNode
    {
        public List<ASTNode> Children;
        public ParsingNode Node;
        public ASTNode() : base()
        {
            Children = new List<ASTNode>();
            Node= new BodyNode();
        }       
        public ASTNode(TokenNode node) : base(node.Value, node.LineNumber, node.TokenNumber)
        {
            Children = new List<ASTNode>();
            this.Node = node;
        }
    }
    public class BodyNode : TokenNode
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
    public class  ExpandedExpression: INonTerminalNode
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
