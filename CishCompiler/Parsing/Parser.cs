using CishCompiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Parsing
{
    public class Parser
    {
        public static ParseTree ParseTokens(List<TokenNode> tokenList)
        {
            var tree = new ParseTree(new RootNode());
            int currentLocation = 0;
            while (currentLocation < tokenList.Count)
            {
                var tempTree = ParseSingleExpression(new Expression(), tokenList, currentLocation);
                // will do error checking here
                tree.RootNode.Children.Add(tempTree.lowerNode);
                currentLocation = (tempTree.changeInLocation);
            }


            return tree;
        }
        static (ParsingNode lowerNode, int changeInLocation) ParseSingleExpression(ParsingNode currNode, List<TokenNode> tokenList, int currentLocation = 0)
        {
            if (currNode is INonTerminalNode ntNode)
            {
                var currNodeGrammar = ParsingGrammar.GrammarRules[currNode.GetType()];
                ;
                

                for (int currGrammar = 0; currGrammar < currNodeGrammar.Count; currGrammar++)
                {
                    //for each production
                    var tempChildren = new List<ParsingNode>();
                    int tempLocation = currentLocation
                    ;
                    for (int tokenInGrammar = 0; tokenInGrammar < currNodeGrammar[currGrammar].Count; tokenInGrammar++)
                    {
                        //for each node in production
                        if (tokenList[tempLocation] is SpaceNode)
                        {
                            tempLocation++;

                        }
                        var nextState = ParseSingleExpression(currNodeGrammar[currGrammar][tokenInGrammar].Invoke(), tokenList, tempLocation);

                        if (nextState.lowerNode != null)
                        {
                            tempChildren.Add(nextState.lowerNode);
                            tempLocation = nextState.changeInLocation;

                        }
                        else
                        {   // If any node in the grammar fails to parse, we skip this grammar rule
                            tempChildren.Clear();
                            break;
                        }
                    }
                    if (tempChildren.Count == currNodeGrammar[currGrammar].Count)
                    {
                        ntNode.Children = tempChildren;
                        if (currNode is Expression)
                        {
                            return (ntNode, tempLocation);
                        }
                        return (ntNode, tempLocation); // Successfully parsed this grammar rule
                    }

                }
            }
            //correct node type 
            if (currNode.GetType().IsAssignableFrom(tokenList[currentLocation].GetType()))
            {
                return (tokenList[currentLocation], currentLocation+1);
            }
            else
            {
                return (null, 0); // Failed to parse this node
            }

        }
    }

}
