using CishCompiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CishCompiler.Parsing
{
    public class Parser
    {
        public static AbstractSyntaxTree ParseFile(List<TokenNode> tokenList)
        {
            var tree = ParseTokensToCST(tokenList);
            FixCST(tree);
            return ConvertToAST(tree);           
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
            if (currNode is ErrorNode node)
            {
                throw new Exception("Token: " + node.Value + "Line: " + node.LineNumber + "Token: " + node.TokenNumber);
            }
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
                        if (tempLocation >= tokenList.Count)
                        {
                            //if we run out of tokens, we can't parse this grammar rule
                            tempChildren.Clear();
                            break;
                        }
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


        }
        static AbstractSyntaxTree ConvertToAST(ComplexSyntaxTree tree)
        {
            var astRoot = ConvertToASTRec(tree.RootNode.Children[0]);
            var ast = new AbstractSyntaxTree(astRoot);
            return ast;
        }
        static ASTNode ConvertToASTRec(ParsingNode node)
        {
            if (node is TokenNode tokNode)
            {
                return new ASTNode(tokNode);
            }
            if (node is Expression exNode)
            {

                if (exNode.Children.Count == 2)
                {
                    // noexnode , exnode
                    var tempNode = new ASTNode();
                    tempNode.Children.Add(ConvertToASTRec(exNode.Children[0]));// no exnode guaranteed end
                    tempNode.Children.AddRange(ConvertToASTRec(exNode.Children[1]).Children); // exnode no end
                    return tempNode;
                }
                else
                {
                    // noexnode

                    var tempNode = new ASTNode();
                    tempNode.Children.Add(ConvertToASTRec(exNode.Children[0])); // no exnode guaranteed end
                    return tempNode;
                }
            }
            if (node is ExpandedExpression preExNode)
            {
                if (preExNode.Children[0] is MAINKeyWordNode mainNode)
                {
                    var temp = new ASTNode(ConvertToASTRec(mainNode));
                    temp.Children = ConvertToASTRec(preExNode.Children[2]).Children;
                    return temp;
                }
                if (preExNode.Children[0] is ObjectNode objNode)
                {
                    var tempNode = new ASTNode(ConvertToASTRec(preExNode.Children[2]));
                    tempNode.Children.Add(ConvertToASTRec(objNode));
                    tempNode.Children.Add(ConvertToASTRec(preExNode.Children[1]));
                    tempNode.Children.Add(ConvertToASTRec(preExNode.Children[3]));
                    return tempNode;
                }
                if (preExNode.Children[0] is IdentifierNode idNode)
                {
                    var tempNode = new ASTNode(ConvertToASTRec(preExNode.Children[1]));
                    tempNode.Children.Add(ConvertToASTRec(idNode));
                    tempNode.Children.Add(ConvertToASTRec(preExNode.Children[2]));
                    return tempNode;
                }
            }
            if (node is ValueExpression valNode)
            {
                if (valNode.Children.Count == 3)
                {
                    var tempNode = new ASTNode((TokenNode)valNode.Children[1]);
                    tempNode.Children.Add(ConvertToASTRec(valNode.Children[0]));
                    tempNode.Children.Add(ConvertToASTRec(valNode.Children[2]));
                    return tempNode;
                }
                else
                {
                    return new ASTNode(ConvertToASTRec(valNode.Children[0]));
                }
            }
            if (node is NoEXValueExpression noExValNode)
            {
                if (noExValNode.Children.Count == 3)
                {


                    return new ASTNode((TokenNode)noExValNode.Children[1]);
                }
                else
                {
                    return new ASTNode(ConvertToASTRec(noExValNode.Children[0]));
                }
            }
            throw new Exception("Node type not recognized for AST conversion: " + node.GetType().Name);
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
                        valueNode.Children[1] = rightChild.Children[1];
                        leftChild.Children.Add(rightChild.Children.First());
                        rightChild.Children.RemoveRange(0, 2);
                        valueNode.Children[2] = rightChild.Children.First();
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
