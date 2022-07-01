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
}
