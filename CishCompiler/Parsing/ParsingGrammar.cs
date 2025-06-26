using CishCompiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Parsing
{
    public class ParsingGrammar
    {
        public static readonly Dictionary<Type, List<List<Func<ParsingNode>>>> GrammarRules = new Dictionary<Type, List<List<Func<ParsingNode>>>>
        {

            [typeof(Expression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>>{()=>new ExpandExpression(),()=> new Expression()},
                new List<Func<ParsingNode>>{()=> new ExpandExpression()},
            },
            [typeof(ExpandExpression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>> { ()=> new MAINKeyWordNode(),()=> new OpenBraceNode(),()=>new Expression(),()=> new CloseBraceNode() },
                new List<Func<ParsingNode>> { ()=>new ObjectNode(), ()=>new IdentifierNode(), ()=>new AssignmentNode(), ()=>new ValueExpression(), ()=>new EndLineNode()},
                new List<Func<ParsingNode>> { ()=>new IdentifierNode(), ()=>new AssignmentOperatorNode(), ()=>new ValueExpression(), ()=>new EndLineNode()},
                new List<Func<ParsingNode>> { ()=> new IFKeyWordNode(), ()=> new CompExpression(),()=> new OpenBraceNode(),()=>new Expression(),()=>new CloseBraceNode()},

            },
            [typeof(ValueExpression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>> {()=> new NoEXValueExpression(),()=>new ArrhythmicOperatorNode(),()=> new ValueExpression()},
                new List<Func<ParsingNode>> {()=> new NoEXValueExpression()}


            },
            [typeof(NoEXValueExpression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>> {()=> new OpenParenthesisNode(),()=> new ValueExpression(),()=> new CloseParenthesisNode()},
                new List<Func<ParsingNode>> {()=> new ValueNode()},
                new List<Func<ParsingNode>> {()=> new IdentifierNode()}

            },
            [typeof(CompExpression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>> { ()=>new ValueExpression(),()=>new ComparisonOperatorNode(),()=> new ValueExpression()},
                new List<Func<ParsingNode>> { ()=> new IdentifierNode()}

            }
        };



    }
}
