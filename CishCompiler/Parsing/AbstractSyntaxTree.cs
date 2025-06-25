using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CishCompiler.Parsing
{
    public class AbstractSyntaxTree
    {
        public ASTNode Root;
        public AbstractSyntaxTree(ASTNode Root) { this.Root = Root; }
    }
}
