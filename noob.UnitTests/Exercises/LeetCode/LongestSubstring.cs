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
    public void WhenDeterminingLongestSubstring_ThenLengthWithoutRepeatingCharactersIsReturned(string str, int expectedResult)
    {
        var result = LengthOfLongestSubstring(str);
        Assert.Equal(expectedResult, result);
    }

    // TODO: this solution can be improved
    public int LengthOfLongestSubstring(string s)
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
                } else
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
}
