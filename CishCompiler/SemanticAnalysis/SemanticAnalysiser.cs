using CishCompiler.Nodes;
using CishCompiler.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.SemanticAnalysis
{
    public class SemanticAnalysiser
    {
        public static List<ErrorData> Analyze(AbstractSyntaxTree tree)
        {
            var RootScope = new ScopeNode(null);
            int scopeNum = 0;
            GetSymbols(tree.Root, RootScope);
            void GetSymbols(ASTNode currNode, ScopeNode currScope)
            {
                if (currNode.Children.Count == 0)
                {
                    return;
                }
                var tempScope = currScope;
                if (currNode.Node is KeywordNode)
                {
                    tempScope = new ScopeNode(currScope);
                    currScope.ChildScopes.Add(tempScope);
                }
                if (currNode.Children[0].Node is ObjectNode typeNode)
                {

                    currScope.symbols.Add(new Symbol(currNode.Children[1].Value, typeNode.Value, scopeNum));
                    scopeNum++;
                }
                for (int i = 0; i < currNode.Children.Count; i++)
                {
                    GetSymbols(currNode.Children[i], tempScope);
                }
            }
            scopeNum = 0;
            var errors = GetErrors(tree);
            List<ErrorData> GetErrors(AbstractSyntaxTree tree)
            {
                var errors = new List<ErrorData>();
                CheckNode(tree.Root, RootScope);
                void CheckNode(ASTNode currNode, ScopeNode currScope)
                {
                    if (currNode.Children.Count == 0)
                    {
                        return;
                    }
                    int currScopeIndex = 0;
                    for (int i = 0; i < currNode.Children.Count; i++)
                    {
                        if (currNode.Children[i].Node is KeywordNode)
                        {
                            CheckNode(currNode.Children[i], currScope.ChildScopes[i]);
                            currScopeIndex++;
                        }
                        else if (currNode.Children[i].Node is ArrhythmicOperatorNode
                            || currNode.Children[i].Node is AssignmentNode
                            || currNode.Children[i].Node is ComparisonOperatorNode)// only these will need both sides to match types
                        {
                            CheckExpression(currNode.Children[i], currScope);
                        }
                        else
                        {
                            CheckNode(currNode.Children[i], currScope);
                        }
                    }
                    ReadOnlyMemory<char> CheckExpression(ASTNode currNode, ScopeNode currScope)
                    {
                        int tempStartIndex = 0;
                        if (currNode.Children[0].Node is ObjectNode)
                        {
                            tempStartIndex = 1; // skip the first node if it's an object
                            var temp = CheckTypes(currNode.Children[tempStartIndex], currNode.Children[tempStartIndex + 1], currScope);
                            scopeNum++;
                            return temp;
                        }
                        else
                        {
                            var temp = CheckTypes(currNode.Children[tempStartIndex], currNode.Children[tempStartIndex + 1], currScope);
                            return temp;
                        }
                    }
                    ReadOnlyMemory<char> CheckTypes(ASTNode left, ASTNode right, ScopeNode scope)
                    {
                        ReadOnlyMemory<char> leftType = GetType(left, scope);
                        ReadOnlyMemory<char> rightType = GetType(right, scope);
                        if (!leftType.Span.SequenceEqual(rightType.Span))
                        {
                            errors.Add(new ErrorData(left.LineNumber, left.TokenNumber, $"Type mismatch: '{left.Value}' is of type '{leftType}' but '{right.Value}' is of type '{rightType}'."));
                            return ReadOnlyMemory<char>.Empty; // return empty memory to indicate error
                        }
                        else
                        {
                            return leftType;
                        }
                        
                    }
                    bool CheckScope(ASTNode node, int scope, ScopeNode? scopeNode)
                    {
                        var temp = GetSymbol(scopeNode, node.Value);
                        while (scopeNode != null && temp == null)
                        {
                            scopeNode = scopeNode.ParentScope;
                            temp = GetSymbol(scopeNode, node.Value);
                        }
                        if (scopeNode == null || temp == null || scope < temp.ScopeNum)
                        {
                            errors.Add(new ErrorData(node.LineNumber, node.TokenNumber, $"Symbol '{node.Value}' not found in scope {scope}."));
                            return false;
                        }
                        return true;
                    }
                    ReadOnlyMemory<char> GetType(ASTNode node, ScopeNode scope)
                    {
                        if (node.Node is IdentifierNode)
                        {
                            var temp = ReadOnlyMemory<char>.Empty;
                            if (CheckScope(node, scopeNum, scope))
                            {
                                var tempomp = GetSymbol(scope, node.Value);
                                if (tempomp != null)
                                {
                                    temp = tempomp.Type;
                                }
                            }
                            return temp;
                        }
                        else if (node.Node is NumberLiteralNode)
                        {
                            return "Int".AsMemory();
                        }
                        else if (node.Node is StringLiteralNode)
                        {
                            return "String".AsMemory();
                        }
                        else
                        {
                            return CheckExpression(node, scope);
                        }
                    }
                }
                return errors;
            }
            return errors;

        }
        static Symbol? GetSymbol(ScopeNode? scope, ReadOnlyMemory<char> name)
        {

            if (scope == null)
            {
                return null;
            }
            foreach (var symbol in scope.symbols)
            {
                if (symbol.Name.Span.SequenceEqual(name.Span))
                {
                    return symbol;
                }
            }
            return null;
        }


    }
}
