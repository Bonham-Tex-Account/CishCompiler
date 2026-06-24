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
                new List<Func<ParsingNode>>{()=>new ExpandedExpression(),()=> new Expression()},
                new List<Func<ParsingNode>>{()=> new ExpandedExpression()},
            },
            [typeof(ExpandedExpression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>> { ()=> new MAINKeyWordNode(),()=> new OpenBraceNode(),()=>new Expression(),()=> new CloseBraceNode() },
                new List<Func<ParsingNode>> { ()=> new FNCKeyWordNode(),()=>new ObjectNode(),()=> new FunctionNode(),()=>new CloseParenthesisNode(),()=>new OpenBraceNode(),()=>new Expression(),()=> new RETURNKeyWordNode(),()=>new ValueExpression(),()=>new EndLineNode(),()=> new CloseBraceNode()},
                new List<Func<ParsingNode>> { ()=> new CLASSKeyWordNode(),()=> new ObjectNode(),()=>new OpenBraceNode(),()=>new Expression(),()=> new CloseBraceNode()},
                new List<Func<ParsingNode>> { ()=> new ObjectNode(), ()=>new IdentifierNode(), ()=>new AssignmentNode(), ()=>new ValueExpression(), ()=>new EndLineNode()},
                new List<Func<ParsingNode>> { ()=> new IdentifierNode(), ()=>new AssignmentOperatorNode(), ()=>new ValueExpression(), ()=>new EndLineNode()},

                new List<Func<ParsingNode>> { ()=> new IFKeyWordNode(), ()=> new CompExpression(),()=> new OpenBraceNode(),()=>new Expression(),()=>new CloseBraceNode()},
                new List<Func<ParsingNode>> { ()=> new WHILEKeyWordNode(), ()=> new CompExpression(),()=> new OpenBraceNode(),()=>new Expression(),()=>new CloseBraceNode()},
                new List<Func<ParsingNode>> { ()=> new OUTPUTKeyWordNode(), ()=> new ValueExpression(),()=>new EndLineNode()},
                new List<Func<ParsingNode>> { ()=> new INPUTKeyWordNode(), ()=> new ValueExpression(),()=>new EndLineNode()}
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
                new List<Func<ParsingNode>> {()=> new IdentifierNode()},
                new List<Func<ParsingNode>> { ()=> new FunctionNode(),()=>new CloseParenthesisNode()},
            },
            [typeof(CompExpression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>> { ()=>new ValueExpression(),()=>new ComparisonOperatorNode(),()=> new ValueExpression()},
                new List<Func<ParsingNode>> { ()=> new IdentifierNode()}

            },
            [typeof(FunctionExpression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>> {()=> new NoExFunctionExpression(),()=>new FunctionExpression() },
                new List<Func<ParsingNode>> {}

            },
            [typeof(NoExFunctionExpression)] = new List<List<Func<ParsingNode>>>
            {
                new List<Func<ParsingNode>> {()=> new ObjectNode(),()=>new IdentifierNode() },
            },
        };



    }
}
