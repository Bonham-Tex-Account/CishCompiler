using CishCompiler.Parsing;

public class ComplexSyntaxTree
{
    public RootNode RootNode { get; set; }
    public ComplexSyntaxTree(RootNode rootNode)
    {
        RootNode = rootNode;
    }
}
