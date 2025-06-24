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
        public static readonly Dictionary<Type, List<List<Func<IParsingNode>>>> GrammarRules = new Dictionary<Type, List<List<Func<IParsingNode>>>>
        {
            [typeof(Expression)] = new List<List<Func<IParsingNode>>>
            {
                new List<Func<IParsingNode>> { ()=>new ObjectNode(), ()=>new IdentifierNode(), ()=>new AssignmentNode(), ()=>new ValueExpression(), ()=>new EndLineNode()},
                new List<Func<IParsingNode>> { ()=>new IdentifierNode(), ()=>new AssignmentOperatorNode(), ()=>new ValueExpression(), ()=>new EndLineNode()},
                new List<Func<IParsingNode>> { ()=> new IFKeyWordNode(), ()=> new CompExpression(),()=> new OpenBraceNode(),()=>new Expression(),()=>new CloseBraceNode()},


            },
            [typeof(ValueExpression)] = new List<List<Func<IParsingNode>>>
            {
                new List<Func<IParsingNode>> {()=> new NoEXValueExpression(),()=>new ArrhythmicOperatorNode(),()=> new ValueExpression()},
                new List<Func<IParsingNode>> {()=> new NoEXValueExpression()}


            },
            [typeof(NoEXValueExpression)] = new List<List<Func<IParsingNode>>>
            {
                new List<Func<IParsingNode>> {()=> new OpenParenthesisNode(),()=> new ValueExpression(),()=> new CloseParenthesisNode()},
                new List<Func<IParsingNode>> {()=> new ValueNode()},
                new List<Func<IParsingNode>> {()=> new IdentifierNode()}

            },
            [typeof(CompExpression)] = new List<List<Func<IParsingNode>>>
            {
                new List<Func<IParsingNode>> { ()=>new ValueExpression(),()=>new ComparisonOperatorNode(),()=> new ValueExpression()},
                new List<Func<IParsingNode>> { ()=> new IdentifierNode()}

            }
        };



    }
}
