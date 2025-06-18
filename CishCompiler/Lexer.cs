using CishCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler
{
    public class Lexer
    {
        public enum TokenType
        {
            Keyword,
            NonAssignmentOperator,
            Function,
            Object,
            Identifier,
            LineEndToken,
            OpenParen,
            CloseParen,
            AssignmentOperator,
            OpenCurly,
            CloseCurly,
            Comment,
            Comma,
            StringLiteral,
            NumbersLiteral,
            Error
        }
        static Dictionary<TokenType, string> possibleTokens = new Dictionary<TokenType, string>()
        {
            { TokenType.Keyword,  "\\b(?:MAIN|IFELSE|IF|ELSE|FOR|RETURN|CLASS|VAR|BREAK|CONTINUE|GOTO|WHILE|THEN|INPUT|OUTPUT|FNC)\\b"},
            { TokenType.Object, "\b[A-Z][a-z]*\b" },
            { TokenType.Function, "\\b[A-Z][a-z]*\\b\\(" },
            { TokenType.NonAssignmentOperator, "([!@*/><=+\\-&^])(?:=|\\1)?" },
            { TokenType.NumbersLiteral, "\\d+(\\.\\d+)?" },
            { TokenType.Comma, "," },
            { TokenType.Comment, "//.*" }, 
            { TokenType.StringLiteral, "[^\"]*" },
            { TokenType.Identifier,  "^[a-z.]+$" },         
            { TokenType.OpenParen,"\\("},
            { TokenType.LineEndToken,";"},           
            { TokenType.CloseParen, "\\)" },
            { TokenType.AssignmentOperator, "=" },
            { TokenType.OpenCurly, "{" },
            { TokenType.CloseCurly, "}" },
            { TokenType.Error, ".+" }

        };
        public static List<Token> TokenizeInputCode(string[] codeLines)
        {
            StringBuilder currToken = new StringBuilder();
            List<Token> tokens = new List<Token>();
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
                        tokenNum++;
                    }
                    else
                    {
                        currToken.Append(codeLines[i][j]);
                    }
                }

            }
            return tokens;
        }
        static Token GetToken(ReadOnlyMemory<char> token, int lineNum, int tokenNum)
        {
            foreach (var possibleToken in possibleTokens)
            {
                if (Token.IsRegexMatch(token.Span, possibleToken.Value))
                {
                    return new Token(token, lineNum, tokenNum, possibleToken.Key);
                }
            }
            throw new Exception($"Token {token} is not recognized as a valid token type.");
        }
    }
}
