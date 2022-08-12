using System.Text.RegularExpressions;
using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// Write a method to replace all spaces in a string with '%20'. You may assume that the string
/// has sufficient space at the end to hold the additional characters, and that you are given the "true"
/// length of the string. (Note: If implementing in Java, please use a character array so that you can
// perform this operation in place.)
/// </summary>
public class URLify
{
    [Theory]
    [InlineData("Mr John Smith  ", "Mr%20John%20Smith")]
    public void WhenEncodingStringUsingRegExp_ThenUrlEncodedStringIsReturned(string str, string expectedStr)
    {
        // Arrange
        var regExp = new Regex(@"\s+");

        // Act
        var result = regExp.Replace(str.Trim(), "%20");

        // Assert
        Assert.Equal(expectedStr, result);
    }
}
