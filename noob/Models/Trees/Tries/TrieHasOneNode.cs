namespace noob.Models.Trees.Tries;

public class TrieHasOneNode : BaseTrieNode, ITrie
{
    private readonly char _value;
    private bool _terminating;
    private ITrie _child;

    /// <summary>
    /// Constructs a trie node with one childs from a <see cref="TrieNullNode"/>
    /// </summary>
    /// <param name="str">string value being added</param>
    /// <param name="terminating">Terminating value of the old node</param>
    /// <exception cref="InvalidCharacterException"></exception>
    public TrieHasOneNode(string str, bool terminating)
    {
        var charIndex = GetCharIndex(str[0]);
        if (!IsCharEnglishLetter(charIndex))
        {
            throw new InvalidCharacterException(str[0]);
        }

        _terminating = terminating;
        _value = str[0];
        _child = new TrieNullNode().Add(str[1..]);
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

        // If the first character of a string equals the stored value
        if(str[0] == _value)
        {
            _child = _child.Add(str[1..]);
            return this;
        }

        return new TrieHasManyNode(str, _terminating, _value, _child);
    }

    public bool Contains(string str)
    {
        if (string.IsNullOrEmpty(str)) return _terminating;

        // If the value of the node equals first char, recursively check descendents for matches
        if (_value == str[0]) {
            return _child.Contains(str[1..]);
        };

        // otherwise, it's not a match
        return false;
    }

    public StringBuilder Items(ITrie node, StringBuilder builder)
    {
        builder.Add(_value);
        return _child.Items(_child, builder);
    }
}
