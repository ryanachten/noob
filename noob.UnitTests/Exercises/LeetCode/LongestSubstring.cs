using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class LongestSubstring
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData(" ", 1)]
    [InlineData("au", 2)]
    [InlineData("abba", 2)]
    public void WhenDeterminingLongestSubstring_ThenLengthWithoutRepeatingCharactersIsReturned(string str, int expectedResult)
    {
        var result1 = BruteForceLengthOfLongestSubstring(str);
        var result2 = LengthOfLongestSubstring(str);

        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult, result2);
    }

    public int BruteForceLengthOfLongestSubstring(string s)
    {
        if (s.Length <= 1) return s.Length;

        var longestSubstrLength = 1;
        for (var i = 0; i < s.Length; i++)
        {
            var usedCharacters = new HashSet<char>
            {
                s[i]
            };

            for (var j = i + 1; j < s.Length; j++)
            {
                if (usedCharacters.Contains(s[j]))
                {
                    break;
                }
                else
                {
                    usedCharacters.Add(s[j]);
                    var subStrLength = usedCharacters.Count;
                    if (subStrLength > longestSubstrLength)
                    {
                        longestSubstrLength = subStrLength;
                    }
                }

            }
        }
        return longestSubstrLength;
    }

    /// <summary>
    /// We optimize the brute force solution by using a hasmap to store
    /// the previously checked characters and their positions
    /// </summary>
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length <= 1) return s.Length;

        var charPositions = new Dictionary<char, int>();

        var start = 0;
        var maxSubStrLength = 0;
        for (var end = 0; end < s.Length; end++)
        {
            var currentChar = s[end];
            // If the character exists in hash, update substr start pointer
            // to where we last found the current character
            // however, we only do this if the new start pointer is greater
            // than what it currently is
            if (charPositions.ContainsKey(currentChar)
                && charPositions[currentChar] + 1 > start)
            {
                start = charPositions[currentChar] + 1;
            }

            charPositions[currentChar] = end;

            var currentSubStrLength = end - start + 1;
            if (currentSubStrLength > maxSubStrLength)
            {
                maxSubStrLength = currentSubStrLength;
            }
        }
        return maxSubStrLength;
    }
}
