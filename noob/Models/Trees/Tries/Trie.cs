namespace noob.Models.Trees.Tries;

public class Trie : ITrie
{
    public ITrie? Root { get; private set; }

    public ITrie Add(string str)
    {
        if (Root == null)
        {
            Root = new TrieNullNode();
        }

        Root = Root.Add(str);
        return Root;
    }

    public bool Contains(string str) => Root?.Contains(str) ?? false;

    public StringBuilder? Items() => Root?.Items(Root, new StringBuilder(6));

    public StringBuilder Items(ITrie node, StringBuilder builder) => node.Items(node, builder);
}
