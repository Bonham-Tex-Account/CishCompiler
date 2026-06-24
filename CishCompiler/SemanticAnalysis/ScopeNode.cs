using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.SemanticAnalysis
{
    public class ScopeNode
    {
        public List<Symbol> symbols;
        public ScopeNode? ParentScope;
        public List<ScopeNode> ChildScopes;
        
        public ScopeNode(ScopeNode? parent)
        {
            ChildScopes = new List<ScopeNode>();
            symbols = new List<Symbol>();
            ParentScope = parent;
        }
    }
}
