using CishCompiler.Nodes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CishCompiler.Lexing
{
    public partial class Lexer
    {
        static Dictionary<string, Func<int, int, ReadOnlyMemory<char>, INode>> possibleTokens = new Dictionary<string, Func<int, int, ReadOnlyMemory<char>, INode>>()
        {
            ["\\bMAIN\\b"] = (LineNumber, TokenNumber, Value) => new MAINKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bIF\\b"]= (LineNumber, TokenNumber, Value) => new IFKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bIFELSE\\b"] = (LineNumber, TokenNumber, Value) => new IFELSEKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bELSE\\b"] = (LineNumber, TokenNumber, Value) => new ELSEKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bFOR\\b"] = (LineNumber, TokenNumber, Value) => new FORKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bRETURN\\b"] = (LineNumber, TokenNumber, Value) => new RETURNKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bCLASS\\b"] = (LineNumber, TokenNumber, Value) => new CLASSKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bVAR\\b"] = (LineNumber, TokenNumber, Value) => new VARKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bBREAK\\b"] = (LineNumber, TokenNumber, Value) => new BREAKKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bCONTINUE\\b"] = (LineNumber, TokenNumber, Value) => new CONTINUEKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bGOTO\\b"] = (LineNumber, TokenNumber, Value) => new GOTOKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bWHILE\\b"] = (LineNumber, TokenNumber, Value) => new WHILEKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bINPUT\\b"] = (LineNumber, TokenNumber, Value) => new INPUTKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bOUTPUT\\b"] = (LineNumber, TokenNumber, Value) => new OUTPUTKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\bFNC\\b"] = (LineNumber, TokenNumber, Value) => new FNCKeyWordNode(Value, LineNumber, TokenNumber),
            ["\\b[A-Z][a-z]*\\b"] = (LineNumber, TokenNumber, Value) => new ObjectNode(Value, LineNumber, TokenNumber),
            ["\\b[ ]\\b"] = (LineNumber, TokenNumber, Value) => new SpaceNode(Value, LineNumber, TokenNumber),
            ["\\b[A-Z][a-z]*\\b\\("] = (LineNumber, TokenNumber, Value) => new FunctionNode(Value, LineNumber, TokenNumber),
            ["\\+"] = (LineNumber, TokenNumber, Value) => new PlusOperatorNode(Value, LineNumber, TokenNumber),
            ["-"] = (LineNumber, TokenNumber, Value) => new MinusOperatorNode(Value, LineNumber, TokenNumber),
            ["/"] = (LineNumber, TokenNumber, Value) => new DivideOperatorNode(Value, LineNumber, TokenNumber),
            ["\\*"] = (LineNumber, TokenNumber, Value) => new MultiplyOperatorNode(Value, LineNumber, TokenNumber),
            ["&"] = (LineNumber, TokenNumber, Value) => new AndOperatorNode(Value, LineNumber, TokenNumber),
            ["\\|"] = (LineNumber, TokenNumber, Value) => new OrOperatorNode(Value, LineNumber, TokenNumber),
            ["!"] = (LineNumber, TokenNumber, Value) => new NotOperatorNode(Value, LineNumber, TokenNumber),
            ["\\+="] = (LineNumber, TokenNumber, Value) => new PlusAssignmentOperatorNode(Value, LineNumber, TokenNumber),
            ["-="] = (LineNumber, TokenNumber, Value) => new MinusAssignmentOperatorNode(Value, LineNumber, TokenNumber),
            ["/="] = (LineNumber, TokenNumber, Value) => new DivideAssignmentOperatorNode(Value, LineNumber, TokenNumber),
            ["\\*="] = (LineNumber, TokenNumber, Value) => new MultiplyAssignmentOperatorNode(Value, LineNumber, TokenNumber),
            ["&="] = (LineNumber, TokenNumber, Value) => new AndAssignmentOperatorNode(Value, LineNumber,TokenNumber),
            ["\\|="] = (LineNumber, TokenNum,value) => new OrAssignmentOperatorNode(value,LineNumber,TokenNum),
            ["=="] = (LineNumber, TokenNumber, Value) => new EqualOperatorNode(Value, LineNumber, TokenNumber),
            ["!="] = (LineNumber, TokenNumber, Value) => new NotEqualOperatorNode(Value, LineNumber, TokenNumber),
            [">"] = (LineNumber, TokenNumber, Value) => new GreaterThanOperatorNode(Value, LineNumber, TokenNumber),
            ["<"] = (LineNumber, TokenNumber, Value) => new LessThanOperatorNode(Value, LineNumber, TokenNumber),
            [">="] = (LineNumber, TokenNumber, Value) => new GreaterThanOrEqualOperatorNode(Value, LineNumber, TokenNumber),
            ["<="] = (LineNumber, TokenNumber, Value) => new LessThanOrEqualOperatorNode(Value, LineNumber, TokenNumber),
            ["\\d+(\\.\\d+)?"] = (LineNumber, TokenNumber, Value) => new NumberLiteralNode(Value, LineNumber, TokenNumber),
            ["&&"] = (LineNumber, TokenNumber, Value) => new AndAndOperatorNode(Value, LineNumber, TokenNumber),
            ["\\|\\|"] = (LineNumber, TokenNumber, Value) => new OrOrOperatorNode(Value, LineNumber, TokenNumber),
            [","] = (LineNumber, TokenNumber, Value) => new CommaNode(Value, LineNumber, TokenNumber),
            ["//.*"] = (LineNumber, TokenNumber, Value) => new CommentNode(Value, LineNumber, TokenNumber),
            ["\"[^\"]*\""] = (LineNumber, TokenNumber, Value) => new StringLiteralNode(Value, LineNumber, TokenNumber),
            ["^[a-z.]+$"] = (LineNumber, TokenNumber, Value) => new IdentifierNode(Value, LineNumber, TokenNumber),
            ["\\("] = (LineNumber, TokenNumber, Value) => new OpenParenthesisNode(Value, LineNumber, TokenNumber),
            [";"] = (LineNumber, TokenNumber, Value) => new EndLineNode(Value, LineNumber, TokenNumber),
            ["\\)"] = (LineNumber, TokenNumber, Value) => new CloseParenthesisNode(Value, LineNumber, TokenNumber),
            ["="] = (LineNumber, TokenNumber, Value) => new AssignmentOperatorNode(Value, LineNumber, TokenNumber),
            ["{"] = (LineNumber, TokenNumber, Value) => new OpenBraceNode(Value, LineNumber, TokenNumber),
            ["}"] = (LineNumber, TokenNumber, Value) => new CloseBraceNode(Value, LineNumber, TokenNumber),
            [".+"] = (LineNumber, TokenNumber, Value) => new ErrorNode(Value, LineNumber, TokenNumber)


           

        };
        public static List<INode> TokenizeInputCode(string[] codeLines)
        {
            StringBuilder currToken = new StringBuilder();
            List<INode> tokens = new List<INode>();
            int tokenNum = 0;
            for (int i = 0; i < codeLines.Length; i++)
            {
                tokenNum = 0; // Reset token number for each line
                for (int j = 0; j < codeLines[i].Length; j++)
                {
                    if (codeLines[i][j] == ' ' && currToken.Length > 0)
                    {
                        tokens.Add(GetToken(currToken.ToString().AsMemory(), i, tokenNum));
                        currToken.Clear();
                        tokenNum += 2;
                        tokens.Add(new SpaceNode(" ".AsMemory(), i, tokenNum));
                    }
                    else
                    {
                        currToken.Append(codeLines[i][j]);
                    }
                }
                if (currToken.Length > 0)
                {
                    tokens.Add(GetToken(currToken.ToString().AsMemory(), i, tokenNum));
                }
            }
            return tokens;
        }
        static INode GetToken(ReadOnlyMemory<char> token, int lineNum, int tokenNum)
        {
            foreach (var possibleToken in possibleTokens)
            {
                if (Regex.IsMatch(token.Span, possibleToken.Key))
                {
                   return possibleToken.Value(lineNum, tokenNum, token);
                }
            }
            throw new Exception($"Token {token} is not recognized as a valid token type.");
        }
    }
}
