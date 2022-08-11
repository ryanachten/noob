using System;
using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// There are three types of edits that can be performed on strings: insert a character,
/// remove a character, or replace a character.Given two strings, write a function to check if they are
/// one edit (or zero edits) away.
/// </summary>
public class OneAway
{
    [Theory]
    [InlineData("pale", "ple", true)]
    [InlineData("pales", "pale", true)]
    [InlineData("pale", "bale", true)]
    [InlineData("pale", "bake", false)]
    public void WhenCheckingIfStringIsOneAway_ThenCorrectResultIsReturned(string current, string target, bool expectedResult)
    {
        // Act
        bool result;
        if(current.Length == target.Length)
        {
            var swaps = 0;
            for (int i = 0; i < Math.Min(current.Length, target.Length); i++)
            {
                if (current[i] != target[i])
                {
                    swaps++;
                }
            }
            result = swaps == 1;
        } else
        {
            result = Math.Abs(current.Length - target.Length) == 1;
        }

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
