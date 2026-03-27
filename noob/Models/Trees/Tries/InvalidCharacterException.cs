namespace noob.Models.Trees.Tries;

public class InvalidCharacterException(char invalidCharacter) : ArgumentException($"String contains a letter which is not a lowercase English letter '{invalidCharacter}'")
{
}
