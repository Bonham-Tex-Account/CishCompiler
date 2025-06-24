using CishCompiler.Parsing;

public class ParseTree
{
    public RootNode RootNode { get; set; }
    public ParseTree(RootNode rootNode)
    {
        RootNode = rootNode;
    }
}
