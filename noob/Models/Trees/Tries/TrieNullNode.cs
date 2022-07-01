namespace noob.Models.Trees.Tries;

public class TrieNullNode : BaseTrieNode, ITrie
{
    private bool _terminating = false;

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
        // Recursive call on child using substring
        return new TrieHasOneNode(str, _terminating);
    }

    
    public bool Contains(string str) {
        
        // If end of string, return terminating value
        if (string.IsNullOrEmpty(str)) return _terminating;

        // NullNode can't store data, so return false if not end of string
        return false;
    }
}
