using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class RansomNote
{
    [Theory]
    [InlineData("a", "b", false)]
    [InlineData("aa", "ab", false)]
    [InlineData("aa", "aab", true)]
    public void WhenProvidedRansomNoteAndMagazine_ThenRansomNoteCanBeDeterminedFromMagazine(
        string ransomNote, string magazine, bool expectedResult)
    {
        var result = CanConstruct(ransomNote, magazine);
        Assert.Equal(expectedResult, result);
    }

    public bool CanConstruct(string ransomNote, string magazine)
    {
        var availableLetters = new Dictionary<char, int>();
        foreach (var character in magazine)
        {
            if (availableLetters.ContainsKey(character))
            {
                availableLetters[character]++;
            }
            else
            {
                availableLetters[character] = 1;
            }
        }
        foreach (var character in ransomNote)
        {
            if (availableLetters.ContainsKey(character) && availableLetters[character] > 0)
            {
                availableLetters[character]--;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
