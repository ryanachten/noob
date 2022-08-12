using System;
using System.Linq;
using System.Text;
using Xunit;

namespace noob.UnitTests.Exercises.HackerRank;

public class CaesarCipher
{
    [Fact]
    public void WhenEncodingString_ThenStringIsCorrectlyRotated()
    {
        var input = "middle-Outz";
        var output = Cipher(input, 2);

        Assert.Equal("okffng-Qwvb", output);
    }

    private readonly static char[] _lowercaseCharacters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private readonly static char[] _uppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static string Cipher(string s, int k)
    {
        var result = new StringBuilder();
        var lowerCaseStr = s.ToLower();
        for (var i = 0; i < s.Length; i++)
        {
            var character = s[i];
            var lowerCaseChar = lowerCaseStr[i];
            var currentIndex = Array.IndexOf(_lowercaseCharacters, lowerCaseChar);
            var newIndex = currentIndex + k;
            if(newIndex > 25)
            {
                newIndex %= 26;
            }

            if (_uppercaseCharacters.Contains(character))
            {
                result.Append(_uppercaseCharacters[newIndex]);
            } else if (_lowercaseCharacters.Contains(character))
            {
                result.Append(_lowercaseCharacters[newIndex]);
            } else
            {
                result.Append(character);
            }
        }
        return result.ToString();
    }
}
