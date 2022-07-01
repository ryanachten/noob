namespace noob.Models.Trees.Tries;

public class InvalidCharacterException : ArgumentException
{
    public InvalidCharacterException(char invalidCharacter) : base($"String contains a letter which is not a lowercase English letter '{invalidCharacter}'") { }
}
