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
        enum TokenType
        {
            Keyword,
            Operator,
            Value,
            Error,
            Function,
            Object,
            Variable
        }
        static Dictionary<TokenType, string> possibleTokens = new Dictionary<TokenType, string>() 
        { 
            { TokenType.Keyword,  "\\b(?:MAIN|IFELSE|IF|ELSE|FOR|RETURN|CLASS|VAR\\?|BREAK|CONTINUE|GOTO|WHILE|THEN|INPUT|OUTPUT|FNC)\\b"},
            { TokenType.Object, "\b[A-Z][a-z]*\b" },
            { TokenType.Function, "\\b[A-Z][a-z]*\\b\\(" },
            { TokenType.Operator, "([!@*/><=+\\-&^])(?:=|\\1)?" }, 
            { TokenType.Value, "\\b\\d+(\\.\\d+)?\\b|\"([^\"]*)\"" }, 
            { TokenType.Variable,  "\\b[a-z]+\\b" }, 
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
            if (Token.IsRegexMatch(token.Span, possibleTokens[TokenType.Keyword]))
            {
                return new KeywordToken(token, lineNum, tokenNum);
            }
            else if (Token.IsRegexMatch(token.Span, possibleTokens[TokenType.Operator]))
            {
                return new OperatorToken(token, lineNum, tokenNum);
            }
            else if (Token.IsRegexMatch(token.Span, possibleTokens[TokenType.Value]))
            {
                return new ValueToken(token, lineNum, tokenNum);
            }
            else if (Token.IsRegexMatch(token.Span, possibleTokens[TokenType.Function]))
            {
                return new FunctionToken(token, lineNum, tokenNum);
            }
            else if (Token.IsRegexMatch(token.Span, possibleTokens[TokenType.Object]))
            {
                return new ObjectToken(token, lineNum, tokenNum);
            }
            else if (Token.IsRegexMatch(token.Span, possibleTokens[TokenType.Variable]))
            {
                return new VariableToken(token, lineNum, tokenNum);
            }
            else if (Token.IsRegexMatch(token.Span, possibleTokens[TokenType.Error]))
            {
                return new ErrorToken(token, lineNum, tokenNum);
            }

            throw new Exception($"Token {token} is not recognized as a valid token type.");
        }
    }
}
