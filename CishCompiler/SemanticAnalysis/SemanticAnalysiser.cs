using CishCompiler.Nodes;
using CishCompiler.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CishCompiler.SemanticAnalysis
{
    public class SemanticAnalysiser
    {
        public static List<ErrorData> Analyze(AbstractSyntaxTree tree)
        {
            var RootScope = new ScopeNode(null);
            int scopeNum = 0;
            GetSymbols(tree.Root, RootScope,ref scopeNum);
            
            scopeNum = 1;
            var errors = GetErrors(tree,RootScope, ref scopeNum);
           
            return errors;

        }
        static void GetSymbols(ASTNode currNode, ScopeNode currScope, ref int scopeNum)
        {
            if (currNode.Node is BodyNode)
            {
                scopeNum++;
            }
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

                currScope.symbols.Add(new Symbol(currNode.Children[1].Value, typeNode.Value, 0 + scopeNum));
                scopeNum++;
            }
            for (int i = 0; i < currNode.Children.Count; i++)
            {
                GetSymbols(currNode.Children[i], tempScope,ref scopeNum);
            }
        }
        static List<ErrorData> GetErrors(AbstractSyntaxTree tree,ScopeNode RootScope, ref int scopeNum)
        {
            var errors = new List<ErrorData>();
            CheckNode(tree.Root, RootScope, ref scopeNum,ref errors);
            
            return errors;
        }
        static void CheckNode(ASTNode currNode, ScopeNode currScope, ref int scopeNum,ref List<ErrorData> errorList)
        {

            if (currNode.Children.Count == 0)
            {
                return;
            }
            int currScopeIndex = 0;
            for (int i = 0; i < currNode.Children.Count; i++)
            {
                if (currNode.Children[i].Node is BodyNode)
                {
                    scopeNum++;
                }
                if (currNode.Children[i].Node is KeywordNode)
                {

                    CheckNode(currNode.Children[i], currScope.ChildScopes[i], ref scopeNum,ref errorList);
                    currScopeIndex++;
                }
                else if (currNode.Children[i].Node is ArrhythmicOperatorNode
                    || currNode.Children[i].Node is AssignmentNode
                    || currNode.Children[i].Node is ComparisonOperatorNode)// only these will need both sides to match types
                {
                    CheckExpression(currNode.Children[i], currScope, ref scopeNum, ref errorList);
                }
                else
                {
                    CheckNode(currNode.Children[i], currScope, ref scopeNum, ref errorList);
                }
            }
            
        }
        static ReadOnlyMemory<char> CheckExpression(ASTNode currNode, ScopeNode currScope, ref int scopeNum,ref List<ErrorData> errorList)
        {
            int tempStartIndex = 0;
            if (currNode.Children[0].Node is ObjectNode)
            {
                tempStartIndex = 1; // skip the first node if it's an object
                var temp = CheckTypes(currNode.Children[tempStartIndex], currNode.Children[tempStartIndex + 1], currScope, ref scopeNum, ref errorList);
                scopeNum++;
                return temp;
            }
            else
            {
                var temp = CheckTypes(currNode.Children[tempStartIndex], currNode.Children[tempStartIndex + 1], currScope, ref scopeNum, ref errorList);
                return temp;
            }
        }
        static ReadOnlyMemory<char> CheckTypes(ASTNode left, ASTNode right, ScopeNode scope, ref int scopeNum,ref List<ErrorData> errorList)
        {
            ReadOnlyMemory<char> leftType = GetType(left, scope, ref scopeNum, ref errorList);
            ReadOnlyMemory<char> rightType = GetType(right, scope, ref scopeNum, ref errorList);
            if (!leftType.Span.SequenceEqual(rightType.Span))
            {
                if (leftType.IsEmpty)
                {
                    leftType = "Unknown".AsMemory();
                }
                if (rightType.IsEmpty)
                {
                    rightType = "Unknown".AsMemory();
                }
                errorList.Add(new ErrorData(left.LineNumber, left.TokenNumber, $"Type mismatch: '{left.Value}' is of type '{leftType}' but '{right.Value}' is of type '{rightType}'."));
                return ReadOnlyMemory<char>.Empty; // return empty memory to indicate error
            }
            else
            {
                return leftType;
            }

        }
        static bool CheckScope(ASTNode node, int scope, ScopeNode? scopeNode, ref int scopeNum,ref List<ErrorData> errorList)
        {
            var temp = GetSymbol(scopeNode, node.Value);
            while (scopeNode != null && temp == null)
            {
                scopeNode = scopeNode.ParentScope;
                temp = GetSymbol(scopeNode, node.Value);
            }
            if (scopeNode == null || temp == null || scopeNum < temp.ScopeNum)
            {

                errorList.Add(new ErrorData(node.LineNumber, node.TokenNumber, $"Symbol '{node.Value}' not found in scope {scope}."));
                return false;
            }
            return true;
        }
        static ReadOnlyMemory<char> GetType(ASTNode node, ScopeNode scope, ref int scopeNum,ref List<ErrorData> errorList)
        {
            if (node.Node is IdentifierNode)
            {
                var temp = ReadOnlyMemory<char>.Empty;
                if (CheckScope(node, scopeNum, scope, ref scopeNum, ref errorList))
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
                return CheckExpression(node, scope, ref scopeNum, ref errorList);
            }
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
