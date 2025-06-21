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
        public static  List<ParseTree> ParseTokens(List<ITokenNode> tokenList)
        {
            throw new NotImplementedException("This method is not implemented yet. Please implement the parsing logic based on the grammar rules defined in ParsingGrammar.");
        }
        static IParsingNode ParseSingleExpression(IParsingNode currNode,List<ITokenNode> tokenList,int currentLocation)
        {
            if(currNode is INonTerminalNode ntNode)
            {
                var currNodeGrammar = ParsingGrammar.GrammarRules[currNode.GetType()];
                foreach (var possGrammar in currNodeGrammar)
                {
                    var tempChildren = new List<IParsingNode>();
                    foreach (var node in possGrammar)
                    {
                        if (tokenList[currentLocation]is SpaceNode)
                        {
                            currentLocation++;
                            continue;
                        }
                        var simplifiedNode = ParseSingleExpression(node.Invoke(), tokenList, currentLocation);
                        if(simplifiedNode!=null)
                        {
                           tempChildren.Add(simplifiedNode);
                        }
                        else 
                        {   // If any node in the grammar fails to parse, we skip this grammar rule
                            tempChildren.Clear();
                            break;
                        }
                    }
                    if(tempChildren.Count == possGrammar.Count)
                    {
                        ntNode.Children = tempChildren;
                        return ntNode; // Successfully parsed this grammar rule
                    }
                }
            }
            if(currNode is ITokenNode tNode)
            {
                return tokenList[currentLocation];              
            }
            throw new Exception("Invalid node type encountered during parsing.");
        }
    }

}
public class ParseTree
{

}
