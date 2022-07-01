namespace noob.Models.Trees.Tries;

public abstract class BaseTrieNode
{
    // Scale character index to range starting at 'a'
    protected static int GetCharIndex(char c) => c - 'a';

    // If the char value is lower than 0 or exceeds 26, it's a non-English letter
    protected static bool IsCharEnglishLetter(int charIndex) => charIndex >= 0 && charIndex <= 26;
}
