using noob.Models;
using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// Implement an algorithm to determine if a string has all unique characters.
/// What if you cannot use additional data structures?
/// </summary>
public class IsUnique
{
    [Theory]
    [InlineData("abcdefgh", false)]
    [InlineData("aabbccddee", true)]
    [InlineData("aabcdefgh", true)]
    public void WhenDeterminingIfCharactersAreUnique_ThenReturnsUniqueness(string str, bool expectedResult)
    {
        // Arrange
        var characters = new HashTable<char, char>();
        var containsDuplicates = false;

        // Act
        foreach (var character in str)
        {
            if (characters.GetValue(character) == default)
            {
                characters.Add(character, character);
            }
            else
            {
                containsDuplicates = true;
                return;
            }
        }

        // Assert
        Assert.Equal(expectedResult, containsDuplicates);
    }
}
