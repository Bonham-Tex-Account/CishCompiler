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
        public static void ParseFile(List<TokenNode> tokenList)
        {
            var tree = ParseTokensToCST(tokenList);
            FixCST(tree);
        }
        static ComplexSyntaxTree ParseTokensToCST(List<TokenNode> tokenList)
        {
            var tree = new ComplexSyntaxTree(new RootNode());
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
                return (tokenList[currentLocation], currentLocation + 1);
            }
            else
            {
                return (null, 0); // Failed to parse this node
            }

        }
        static void FixCST(ComplexSyntaxTree tree)
        {
            //fix the CST by rotating nodes if necessary
            RotateIfNecessary(tree.RootNode);
            ;
            
        }
        static AbstractSyntaxTree ConvertToAST(ComplexSyntaxTree tree)
        {
           return new AbstractSyntaxTree(ConvertToASTRec(tree.RootNode));
        }
        static ASTNode ConvertToASTRec(ParsingNode node)
        {
            throw new Exception("Not implemented yet");
        }
        static void RotateIfNecessary(ParsingNode node)
        {
            //will potentially have problems with different symbols in the future
            while (node is ValueExpression valueNode)
            {
                if (valueNode.Children.Count == 3 && valueNode.Children[2] is ValueExpression rightChild)
                {
                    if (rightChild.Children.Count == 3 && ((ArrhythmicOperatorNode)valueNode.Children[1]).Tier >= ((ArrhythmicOperatorNode)rightChild.Children[1]).Tier)
                    {
                        //if time to rotate left
                        INonTerminalNode leftChild = (INonTerminalNode)valueNode.Children[0];
                        leftChild.Children.Add(valueNode.Children[1]);
                        valueNode.Children[1]= rightChild.Children[1];
                        leftChild.Children.Add(rightChild.Children.First());
                        rightChild.Children.RemoveRange(0,2);
                        valueNode.Children[2]= rightChild.Children.First();
                        continue;
                    }
                }
                break;
            }
            if (node is INonTerminalNode nonTerminalNode)
            {
                foreach (var child in nonTerminalNode.Children)
                {
                    RotateIfNecessary(child);
                }
            }
            ;
        }
    }

}
