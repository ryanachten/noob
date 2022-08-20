using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class LongestPalindromeSubstring
{
    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("cbbd", "bb")]
    [InlineData("a", "a")]
    [InlineData("ccc", "ccc")]
    public void WhenDeterminingLongestPalindrome_ThenLongestPalindromeSubstringIsReturned(string str, string expectedResult)
    {
        var result = LongestPalindrome(str);
        Assert.Equal(expectedResult, result);
    }

    // Brute force solution - can be improved through dynamic programming
    public string LongestPalindrome(string s)
    {
        if (s.Length == 1) return s;

        // Get the number of character occurences in a string
        var characterIndex = new Dictionary<char, List<int>>();
        for (var i = 0; i < s.Length; i++)
        {
            var currentChar = s[i];
            if (characterIndex.ContainsKey(currentChar))
            {
                characterIndex[currentChar].Add(i);
            }
            else
            {
                characterIndex.Add(currentChar, new List<int> { i });
            }
        }

        // Then iterate through string and find palindromes for characters with more than one occurence
        var longestSubstring = s[0].ToString();
        foreach (var currentChar in characterIndex.Keys)
        {
            var numberOfOccurences = characterIndex[currentChar].Count;
            if (numberOfOccurences > 1)
            {
                for (var j = 0; j < numberOfOccurences - 1; j++)
                {
                    for (var k = j + 1; k < numberOfOccurences; k++)
                    {
                        var startIndex = characterIndex[currentChar].ElementAt(j);
                        var endIndex = characterIndex[currentChar].ElementAt(k);
                        var length = endIndex - startIndex + 1;
                        var substring = s.Substring(startIndex, length);
                        var isPalindrome = IsPalindrome(substring);
                        if (isPalindrome && substring.Length > longestSubstring.Length)
                        {
                            longestSubstring = substring;
                        }
                    }
                }
            }
        }

        return longestSubstring;
    }

    private static bool IsPalindrome(string substring)
    {
        var midpoint = substring.Length / 2;
        for (var i = 0; i < midpoint; i++)
        {
            var charA = substring[i];
            var charB = substring[substring.Length - 1 - i];
            if (charA != charB)
            {
                return false;
            }
        }
        return true;
    }
}
