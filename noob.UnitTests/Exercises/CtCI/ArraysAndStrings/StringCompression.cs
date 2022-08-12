using noob.Models;
using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// Implement a method to perform basic string compression using the counts
/// of repeated characters.For example, the string aabcccccaaa would become a2blc5a3.If the
/// "compressed" string would not become smaller than the original string, your method should return
/// the original string. You can assume the string has only uppercase and lowercase letters(a - z).
/// </summary>
public class StringCompression
{
    [Theory]
    [InlineData("aabcccccaaa", "a2b1c5a3")]
    [InlineData("aabcccccaab", "a2b1c5a2b1")]
    [InlineData("abcdefbhijklmno", "abcdefbhijklmno")]
    public void WhenCompressingString_ThenShortestStringIsReturned(string target, string expectedResult)
    {
        // Arrange
        var list = new ArrayList<string>(target.Length);
        var characters = target.ToCharArray();

        // Act
        var maxIndex = characters.Length - 1;
        for (int i = 0; i <= maxIndex;)
        {
            var j = i + 1 > maxIndex ? maxIndex : i + 1;
            while (characters[j] == characters[i])
            {
                j++;
                if (j > maxIndex)
                {
                    break;
                }
            }
            list.Add(target[i..j]);
            i = j;
        }

        string compressedStr = string.Empty;
        for (int i = 0; i < list.Count; i++)
        {
            var str = list.Data[i];
            var character = str[0];
            compressedStr += $"{character}{str.Length}";
        }

        var result = compressedStr.Length < target.Length ? compressedStr : target;

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
