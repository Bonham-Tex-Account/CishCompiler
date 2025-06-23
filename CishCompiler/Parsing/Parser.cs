using CishCompiler.Nodes;
using CishCompiler.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Parsing
{
    public class Parser
    {
        public static List<ParseTree> ParseTokens(List<ITokenNode> tokenList)
        {
            var tempList = new List<ParseTree>();
            int currentLocation = 0;
            while(currentLocation<tokenList.Count)
            {
                var tempTree = ParseSingleExpression(new Expression(), tokenList,currentLocation);
                // will do error checking here
                tempList.Add(new ParseTree(tempTree.lowerNode));
                currentLocation += tempTree.changeInLocation;
            }
            

            return tempList;
        }
        static (IParsingNode lowerNode, int changeInLocation) ParseSingleExpression(IParsingNode currNode, List<ITokenNode> tokenList, int currentLocation = 0)
        {
            if (currNode is INonTerminalNode ntNode)
            {
                var currNodeGrammar = ParsingGrammar.GrammarRules[currNode.GetType()];
                foreach (var possGrammar in currNodeGrammar)
                {
                    var tempChildren = new List<IParsingNode>();
                    foreach (var node in possGrammar)
                    {
                        if (tokenList[currentLocation] is SpaceNode)
                        {
                            currentLocation++;

                        }
                        var nextState = ParseSingleExpression(node.Invoke(), tokenList, currentLocation);

                        if (nextState.lowerNode != null)
                        {
                            tempChildren.Add(nextState.lowerNode);
                            currentLocation = currentLocation += nextState.changeInLocation;

                        }
                        else
                        {   // If any node in the grammar fails to parse, we skip this grammar rule
                            tempChildren.Clear();
                            break;
                        }
                    }
                    if (tempChildren.Count == possGrammar.Count)
                    {
                        ntNode.Children = tempChildren;
                        if(currNode is Expression)
                        {
                            return (ntNode, currentLocation);
                        }
                        return (ntNode, tempChildren.Count); // Successfully parsed this grammar rule
                    }
                   
                }
            }
            if (currNode is ITokenNode tNode)
            {
                return (tokenList[currentLocation], 1);
            }
            throw new Exception("Invalid node type encountered during parsing.");
        }
    }

}
public class ParseTree
{
    public IParsingNode RootNode { get; set; }
    public ParseTree(IParsingNode rootNode)
    {
        RootNode = rootNode;
    }
}
