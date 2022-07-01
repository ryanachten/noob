namespace noob.Models.Trees.Tries;

/// <summary>
/// Simple implementation of trie node with poor space runtime
/// - see <see cref="ITrie"/> implementations for better space runtime implementations
/// </summary>
public class SimpleTrie
{
    /// <summary>
    /// Indicates whether the node is a (*) / null node
    /// </summary>
    private bool _terminiating = false;

    /// <summary>
    /// Nullable array of children, representing characters of the alphabet
    /// </summary>
    private readonly SimpleTrie?[] _children = new SimpleTrie?[26];

    /// <summary>
    /// Recursively add characters of a string into trie nodes
    /// </summary>
    /// <param name="str">Lower-case string of English characters</param>
    /// <exception cref="ArgumentException">Thrown for invalid lower-case English characters</exception>
    public void Add(string str)
    {
        // If string is empty, the current node is a null node
        if(str == string.Empty)
        {
            _terminiating = true;
            return;
        }

        var charIndex = GetCharIndex(str[0]);
        if (!IsCharEnglishLetter(charIndex))
        {
            throw new ArgumentException($"String contains a letter which is not a lowercase English letter '{str[0]}'");
        }

        // If the entry for first character doesn't exist yet, create a node for it
        if(_children[charIndex] == null)
        {
            _children[charIndex] = new SimpleTrie();
        }
        // Recursive call on child using substring
        _children[charIndex]?.Add(str[1..]);
    }

    public bool Contains(string str)
    {
        // If we're at the end of the string, we've found the word in the trie
        // only if the branch terminates at the correct position
        if (string.IsNullOrEmpty(str)) return _terminiating;

        var charIndex = GetCharIndex(str[0]);
        if (!IsCharEnglishLetter(charIndex))
        {
            return false;
        }

        // If the character is missing, then the string is not present in trie
        if (_children[charIndex] == null)
        {
            return false;
        }

        // Call recursively to child nodes with substring of query
        return _children[charIndex]!.Contains(str[1..]);
    }

    // Scale character index to range starting at 'a'
    private static int GetCharIndex(char c) => c - 'a';

    // If the char value is lower than 0 or exceeds 26, it's a non-English letter
    private static bool IsCharEnglishLetter(int charIndex) => charIndex > 0 && charIndex <= 26;
}
