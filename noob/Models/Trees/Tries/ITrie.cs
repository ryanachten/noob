namespace noob.Models.Trees.Tries;

/// <summary>
/// Interface for trie implementations which provide a better space runtime
/// than the simpler implementation <see cref="SimpleTrie"/>
/// </summary>
public interface ITrie
{
    /// <summary>
    /// Adds a string to a trie
    /// </summary>
    /// <param name="str"></param>
    public ITrie Add(string str);

    /// <summary>
    /// Returns whether the trie contains a given string 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    bool Contains(string str);

    /// <summary>
    /// Trie iterator using preorder traversal 
    /// </summary>
    /// <param name="node">Node to be processed</param>
    /// <param name="builder">StringBuilder to collect items</param>
    /// <returns>StringBuilder with containing trie characters</returns>
    StringBuilder Items(ITrie node, StringBuilder builder);
}
