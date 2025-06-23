using CishCompiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new List<Func<IParsingNode>> { ()=>new ObjectNode(), ()=>new IdentifierNode(), ()=>new AssignmentOperatorNode(), ()=>new ValueExpression(), ()=>new EndLineNode()},
                new List<Func<IParsingNode>> { ()=>new IdentifierNode(), ()=>new AssignmentOperatorNode(), ()=>new ValueExpression(), ()=>new EndLineNode()}


            },
            [typeof(ValueExpression)] = new List<List<Func<IParsingNode>>>
            {

                new List<Func<IParsingNode>> {()=> new NoEXValueExpression()},
                new List<Func<IParsingNode>> {()=> new NoEXValueExpression(),()=>new IArrhythmicOperatorNode(),()=> new ValueExpression()}

            },
            [typeof(NoEXValueExpression)] = new List<List<Func<IParsingNode>>>
            {
                new List<Func<IParsingNode>> {()=> new IValueNode()},
                new List<Func<IParsingNode>> {()=> new IdentifierNode()},
                new List<Func<IParsingNode>> {()=> new OpenParenthesisNode(),()=> new ValueExpression(),()=> new OpenParenthesisNode()},
            }

        };



    }
}
