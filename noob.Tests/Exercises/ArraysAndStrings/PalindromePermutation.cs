using noob.Models;
using System.Text.RegularExpressions;
using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// Given a string, write a function to check if it is a permutation of a palindrome.
/// A palindrome is a word or phrase that is the same forwards and backwards.A permutation
/// is a rearrangement of letters.The palindrome does not need to be limited to just dictionary words.
/// </summary>
public class PalindromePermutation
{
    [Theory]
    [InlineData("Tact Coa", true)]
    [InlineData("Ryan Was Here", false)]
    [InlineData("MeowweoM", true)]
    [InlineData("MeowweoMM", false)]
    public void WhenCheckingIfStringIsPalindromePermutation_ThenCorrectResultIsReturned(string str, bool expectedResult)
    {
        // Arrange
        var regex = new Regex(@"\s+");
        var formattedString = regex.Replace(str.ToLower(), string.Empty);
        var table = new HashTable<char, int>();

        // Act
        foreach (var character in formattedString)
        {
            var count = table.GetValue(character);
            if (count != null)
            {
                table.Add(character, (int)count + 1);
            } else
            {
                table.Add(character, 1);
            }
        }

        var evenChars = 0;
        var oddChars = 0;
        foreach (var character in formattedString)
        {
            if (table.GetValue(character) % 2 == 0)
            {
                evenChars++;
            }
            else
            {
                oddChars++;
            }
        }

        // Assumption:
        // Palindrome must have ALL even number of characters except for max ONE odd number of characters
        var result = oddChars <= 1 && evenChars + oddChars == formattedString.Length;

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
