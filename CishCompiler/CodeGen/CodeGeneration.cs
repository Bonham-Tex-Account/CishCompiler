using CishCompiler.Nodes;
using CishCompiler.Parsing;
using CishCompiler.SemanticAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CishCompiler.CodeGen
{

    public class CodeGeneration
    {
        static string[] MAINDECLARATION = [
                ".assembly extern mscorlib {}",
                "",
                ".assembly ILExample {}",
                "",
            ".class public auto ansi beforefieldinit C\r\nextends [System.Runtime]System.Object{",
                ".method static void Main() il managed",
                "{",
                "    .entrypoint"
            ];
        static string[] MAINEND = ["    ret", "}","}"];
        static List<Symbol> symbols = new List<Symbol>();
        static List<ComparisonOperatorNode> compOps = new List<ComparisonOperatorNode>();
        static int currConditionalIndex = 0;
        public static List<string> GenerateMainMethod(ASTNode mainNode)
        {
            var codeLines = new List<string>();
            currConditionalIndex = 0;
            //Generate the main method header
            codeLines.AddRange(MAINDECLARATION);
            codeLines.Add("    .maxstack " + GetStackSize(mainNode));
            symbols = GetLocals();
            compOps = GetConditionals(mainNode);
            codeLines.AddRange(GetLocalCode(symbols, compOps));
            codeLines.AddRange(GenerateIL(mainNode));
            codeLines.AddRange(MAINEND);
            return codeLines;
        }
        public static List<string> GenerateIL(ASTNode currNode)
        {
            List<string> ilCode = new List<string>();
            if (currNode.Node is ArrhythmicOperatorNode node)
            {
                return GenerateOperationCode(currNode);
            }
            else if (currNode.Node is AssignmentOperatorNode)
            {
                return GenerateAssignmentCode(currNode);
            }
            else if (currNode.Node is IFKeyWordNode)
            {
                return GenerateIfCode(currNode);
            }
            else if (currNode.Node is OUTPUTKeyWordNode)
            {
                List<string> operationCode = new List<string>();
                operationCode.Add("//Output");
                operationCode.AddRange(GetOperand(currNode, 0));
                operationCode.Add("call void [mscorlib]System.Console::WriteLine(string)");
                return operationCode;
            }
            else if (currNode.Node is INPUTKeyWordNode)
            {
                List<string> operationCode = new List<string>();
                operationCode.Add("//Input");
                operationCode.Add("call string [mscorlib]System.Console::ReadLine()");
                operationCode.Add("//Store Input");
                operationCode.Add(GetVar(currNode.Children[0]));
                return operationCode;
            }
            else if (currNode.Node is WHILEKeyWordNode)
            {
                List<string> operationCode = new List<string>();
                var tempitionalIndex = currConditionalIndex;
                operationCode.Add("while" + tempitionalIndex + ":");
                operationCode.AddRange(GenerateIfCode(currNode));
                operationCode.Insert(operationCode.Count - 1, "br.s while" + tempitionalIndex);
                return operationCode;
            }
            else
            {
                foreach (var child in currNode.Children)
                {
                    var childCode = GenerateIL(child);
                    ilCode.AddRange(childCode);
                }
            }



            return ilCode;
        }
        static List<string> GetLocalCode(List<Symbol> locals, List<ComparisonOperatorNode> conditionals)
        {
            var localList = new List<string>();
            localList.Add(".locals init (");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < locals.Count; i++)
            {
                sb.Clear();
                sb.Append($"[{i}] ");
                if (locals[i].Type.ToString() == "Int")
                {
                    sb.Append("int32 ");
                }
                else if (locals[i].Type.ToString() == "String")
                {
                    sb.Append("string ");
                }
                else
                {

                }
                sb.Append(locals[i].Name.ToString());
                if (i != locals.Count - 1 || conditionals.Count != 0)
                {
                    sb.Append(",");
                }
                localList.Add(sb.ToString());
            }
            for (int i = 0; i < conditionals.Count; i++)
            {
                sb.Clear();
                sb.Append($"[{i + locals.Count}] ");
                sb.Append("bool");
                if (i != conditionals.Count - 1)
                {
                    sb.Append(",");
                }
                localList.Add(sb.ToString());
            }
            localList.Add(")");
            return localList;
        }
        static List<ComparisonOperatorNode> GetConditionals(ASTNode root)
        {
            var condList = new List<ComparisonOperatorNode>();
            void TraverseTree(ASTNode node)
            {
                foreach (var item in node.Children)
                {
                    if (item.Node is ComparisonOperatorNode cNode)
                    {
                        condList.Add(cNode);
                    }
                    else
                    {
                        TraverseTree(item);
                    }
                }
            }
            TraverseTree(root);
            return condList;
        }
        static List<Symbol> GetLocals()
        {
            var scopeRoot = SemanticAnalysiser.Root;
            void TraverseScope(ScopeNode scope, List<Symbol> locals)
            {
                foreach (var symbol in scope.symbols)
                {
                    locals.Add(symbol);
                }
                foreach (var childScope in scope.ChildScopes)
                {
                    TraverseScope(childScope, locals);
                }
            }
            var locals = new List<Symbol>();
            if (scopeRoot != null)
            {
                TraverseScope(scopeRoot, locals);
            }
            return locals;
        }
        static int GetStackSize(ASTNode astNode)
        {
            if (astNode.Node is ComparisonOperatorNode || astNode.Node is AssignmentNode || astNode.Node is ArrhythmicOperatorNode)
            {
                return 2; // Comparison and assignment operators require two operands
            }
            if (astNode.Node is ValueNode || astNode.Node is IdentifierNode)
            {
                return 1; // Leaf nodes (like literals) require one stack slot
            }
            int stackSize = 0;
            foreach (var child in astNode.Children)
            {
                var temp = GetStackSize(child);
                if (stackSize < temp)
                {
                    stackSize = temp;
                }
            }
            return stackSize;
        }

        static List<string> GenerateIfCode(ASTNode currNode)
        {
            List<string> operationCode = new List<string>();
            var tempitionalIndex = currConditionalIndex;
            currConditionalIndex++;
            operationCode.Add("//If or While");
            operationCode.AddRange(GenerateOperationCode(currNode.Children[0]));
            operationCode.Add("brfalse.s if" + tempitionalIndex);
            operationCode.Add("//InnerCode");
            for (int i = 1; i < currNode.Children.Count; i++)
            {
                operationCode.AddRange(GenerateIL(currNode.Children[i]));
            }
            operationCode.Add("if" + tempitionalIndex + ":");
            return operationCode;
        }
        static List<string> GenerateAssignmentCode(ASTNode node)
        {
            List<string> operationCode = new List<string>();
            int index = 0;
            if (node.Children[0].Node is ObjectNode)
            {
                index = 1; // Skip the first node if it's an object
            }

            operationCode.Add("//Value");
            operationCode.AddRange(GetOperand(node, index + 1));
            operationCode.Add("//Assignment");
            operationCode.Add(GetVar(node.Children[index]));
            return operationCode;
        }
        static string GetOperator(ASTNode node)
        {
            return CodeLibrary.Library[node.Value.ToString()];
        }
        static string GetVar(ASTNode node)
        {
            string identifier = "";
            void TraverseScope(ScopeNode scope, ref string identifier)
            {
                if (node.Node is IdentifierNode identifierNode)
                {
                    for (int i = 0; i < symbols.Count; i++)
                    {
                        if (symbols[i].Name.Span.SequenceEqual(identifierNode.Value.Span))
                        {
                            identifier = "stloc." + i; // Assuming the identifier is a local variable
                        }
                    }

                    foreach (var childScope in scope.ChildScopes)
                    {
                        TraverseScope(childScope, ref identifier);
                    }
                }
            }
            if (SemanticAnalysiser.Root != null)
            {
                TraverseScope(SemanticAnalysiser.Root, ref identifier);
            }
            return identifier;
        }
        static List<string> GenerateOperationCode(ASTNode node)
        {
            List<string> operationCode = new List<string>();
            int index = 0;
            operationCode.Add("//Operation");
            operationCode.AddRange(GetOperand(node, index));
            operationCode.AddRange(GetOperand(node, index + 1));
            operationCode.Add(GetOperator(node));
            return operationCode;
        }
        static string GetValue(ParsingNode valueNode)
        {
            if (valueNode is NumberLiteralNode numberNode)
            {
                return "ldc.i4." + numberNode.Value.ToString(); // Assuming the value is a number literal
            }
            else if (valueNode is StringLiteralNode stringNode)
            {
                return "ldstr " + stringNode.Value.ToString(); // Assuming the value is a string literal
            }
            else
            {
                throw new NotSupportedException("Unsupported value node type.");
            }
        }
        static string GetIdentifier(TokenNode identifierNode)
        {
            string identifier = "";
            void TraverseScope(ScopeNode scope, ref string identifier)
            {

                for (int i = 0; i < symbols.Count; i++)
                {
                    if (symbols[i].Name.Span.SequenceEqual(identifierNode.Value.Span))
                    {
                        identifier = "ldloc." + i; // Assuming the identifier is a local variable
                    }
                }

                foreach (var childScope in scope.ChildScopes)
                {
                    TraverseScope(childScope, ref identifier);
                }
            }
            if (SemanticAnalysiser.Root != null)
            {
                TraverseScope(SemanticAnalysiser.Root, ref identifier);
            }
            return identifier;
        }
        static List<string> GetOperand(ASTNode node, int index)
        {
            if (node.Children[index].Node is ValueNode)
            {
                var temp = new List<string>();
                temp.Add(GetValue(node.Children[index].Node));
                return temp;
            }
            else if (node.Children[index].Node is IdentifierNode idNode)
            {
                var temp = new List<string>();
                temp.Add(GetIdentifier(idNode));
                return temp;
            }
            else if (node.Children[index].Node is ArrhythmicOperatorNode aNode)
            {
                return GenerateOperationCode(node.Children[index]);
            }
            else
            {
                throw new NotSupportedException("Unsupported left operand type.");
            }
        }
    }

}
