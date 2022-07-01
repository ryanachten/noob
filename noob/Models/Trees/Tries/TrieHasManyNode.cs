namespace noob.Models.Trees.Tries;

public class TrieHasManyNode : BaseTrieNode, ITrie
{
    /// <summary>
    /// Nullable array of children, representing characters of the alphabet
    /// </summary>
    private readonly ITrie?[] _children = new ITrie?[26];
    private bool _terminating;

    /// <summary>
    /// Constructs a trie node with many children from a <see cref="TrieHasOneNode"/>
    /// </summary>
    /// <param name="str">string value being added</param>
    /// <param name="value">value of the old node</param>
    /// <param name="child">child of the old node</param>
    public TrieHasManyNode(string str, bool terminating, char value, ITrie child)
    {
        _terminating = terminating;

        var charIndex = GetCharIndex(value);
        if (!IsCharEnglishLetter(charIndex))
        {
            throw new InvalidCharacterException(str[0]);
        }

        _children[charIndex] = child;

        Add(str);
    }

    public ITrie Add(string str)
    {
        // If string is empty, the current node is a null node
        if (str == string.Empty)
        {
            _terminating = true;
            return this;
        }

        var charIndex = GetCharIndex(str[0]);
        if (!IsCharEnglishLetter(charIndex))
        {
            throw new InvalidCharacterException(str[0]);
        }

        // If the entry for first character doesn't exist yet, create a node for it
        if (_children[charIndex] == null)
        {
            _children[charIndex] = new TrieNullNode();
        }

        // Recursive call on child using substring
        _children[charIndex] = _children[charIndex]?.Add(str[1..]);

        return this;
    }

    public bool Contains(string str)
    {
        // If we're at the end of the string, we've found the word in the trie
        // only if the branch terminates at the correct position
        if (string.IsNullOrEmpty(str)) return _terminating;

        var charIndex = GetCharIndex(str[0]);
        if (!IsCharEnglishLetter(charIndex)) return false;

        // If the character is missing, then the string is not present in trie
        if (_children[charIndex] == null) return false;

        // Call recursively to child nodes with substring of query
        return _children[charIndex]!.Contains(str[1..]);
    }
}
