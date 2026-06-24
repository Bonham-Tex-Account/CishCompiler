using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.SemanticAnalysis
{
    public class Symbol
    {
        public ReadOnlyMemory<char> Name;
        public ReadOnlyMemory<char> Type;
        public int ScopeNum;
        public Symbol(ReadOnlyMemory<char> name, ReadOnlyMemory<char> type,int scopeNum)
        {
            Name = name;
            Type = type;
            ScopeNum = scopeNum;
        }
    }
}
