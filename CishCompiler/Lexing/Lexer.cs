using CishCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Lexing
{
    public class Lexer
    {
        public enum TokenType
        {
            MAINKeyword,
            IFKeyword,
            IFELSEKeyword,
            ELSEKeyword,
            FORKeyword,
            RETURNKeyword,
            CLASSKeyword,
            VARKeyword,
            BREAKKeyword,
            CONTINUEKeyword,
            GOTOKeyword,
            WHILEKeyword,
            INPUTKeyword,
            OUTPUTKeyword,
            FNCKeyword,
            PlusOperator,
            MinusOperator,
            DivideOperator,
            MultiplyOperator,
            AndOperator,
            OrOperator,
            NotOperator,
            PlusAssignmentOperator,
            MinusAssignmentOperator,
            DivideAssignmentOperator,
            MultiplyAssignmentOperator,
            AndAssignmentOperator,
            OrAssignmentOperator,
            EqualOperator,
            NotEqualOperator,
            GreaterThanOperator,
            LessThanOperator,
            GreaterThanOrEqualOperator,
            LessThanOrEqualOperator,
            AndAndOperator,
            OrOrOperator,
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
            Space,
            Error
        }
        static Dictionary<TokenType, string> possibleTokens = new Dictionary<TokenType, string>()
        {
            {TokenType.MAINKeyword, "\\bMAIN\\b" },
            { TokenType.IFKeyword, "\\bIF\\b" },
            { TokenType.IFELSEKeyword, "\\bIFELSE\\b" },
            { TokenType.ELSEKeyword, "\\bELSE\\b" },
            { TokenType.FORKeyword, "\\bFOR\\b" },
            { TokenType.RETURNKeyword, "\\bRETURN\\b" },
            { TokenType.CLASSKeyword, "\\bCLASS\\b" },
            { TokenType.VARKeyword, "\\bVAR\\b" },
            { TokenType.BREAKKeyword, "\\bBREAK\\b" },
            { TokenType.CONTINUEKeyword, "\\bCONTINUE\\b" },
            { TokenType.GOTOKeyword, "\\bGOTO\\b" },
            { TokenType.WHILEKeyword, "\\bWHILE\\b" },
            { TokenType.INPUTKeyword, "\\bINPUT\\b" },
            { TokenType.OUTPUTKeyword, "\\bOUTPUT\\b" },
            { TokenType.FNCKeyword, "\\bFNC\\b" },
            { TokenType.Object, "\b[A-Z][a-z]*\b" },
            { TokenType.Space, "\b[ ]\b" },
            { TokenType.Function, "\\b[A-Z][a-z]*\\b\\(" },
            { TokenType.PlusOperator, "\b+\b" },
            { TokenType.MinusOperator, "\b-\b" },
            { TokenType.DivideOperator, "\b/\b" },
            { TokenType.MultiplyOperator, "\b*\b" },
            { TokenType.AndOperator, "\b&\b" },
            { TokenType.OrOperator, "\b\\|\\|\b" },
            { TokenType.NotOperator, "\b!\b" },
            { TokenType.PlusAssignmentOperator, "\b\\+=\b" },
            { TokenType.MinusAssignmentOperator, "\b-=\b" },
            { TokenType.DivideAssignmentOperator, "\b/=\b" },
            { TokenType.MultiplyAssignmentOperator, "\b\\*=\b" },
            { TokenType.AndAssignmentOperator, "\b&=\b" },
            { TokenType.OrAssignmentOperator, "\b\\|=\b" },
            { TokenType.EqualOperator, "\b==\b" },
            { TokenType.NotEqualOperator, "\b!=\b" },
            { TokenType.GreaterThanOperator, "\b>\b" },
            { TokenType.LessThanOperator, "\b<\b" },
            { TokenType.GreaterThanOrEqualOperator, "\b>=\b" },
            { TokenType.LessThanOrEqualOperator, "\b<=\b" },
            { TokenType.NumbersLiteral, "\\d+(\\.\\d+)?" },
            { TokenType.AndAndOperator, "\b&&\b" },
            { TokenType.OrOrOperator, "\b\\|\\|\b" },
            { TokenType.Comma, "\b,\b" },
            { TokenType.Comment, "//.*" },
            { TokenType.StringLiteral, "[^\"]*" },
            { TokenType.Identifier,  "^[a-z.]+$" },
            { TokenType.OpenParen,"\b\\(\b"},
            { TokenType.LineEndToken,"\b;\b"},
            { TokenType.CloseParen, "\b\\)\b" },
            { TokenType.AssignmentOperator, "\b=\b" },
            { TokenType.OpenCurly, "\b{\b" },
            { TokenType.CloseCurly, "\b}\b" },
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
                        tokenNum += 2;
                        tokens.Add(new Token(" ".AsMemory(), i, tokenNum, TokenType.Space)); // Add space token
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
