using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// Given two strings, write a method to decide if one is a permutation of the other.
/// </summary>
public class CheckPermutation
{
    [Theory]
    [InlineData("meow", "woem", true)]
    [InlineData("meow", "woof", false)]

    public void WhenCheckingPermutations_ThenPermutationResultIsReturned(string str1, string str2, bool expectedResult)
    {
        // Act
        var result = Permutate(str1, str2, 0, str1.Length - 1);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    private bool Permutate(string currentStr, string targetStr, int start, int end)
    {
        // Permutation has been reached
        if (start == end)
        {
            return currentStr == targetStr;
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                currentStr = Swap(currentStr, start, i);
                var hasMatch = Permutate(currentStr, targetStr, start + 1, end);
                if (hasMatch)
                {
                    return true;
                }
                currentStr = Swap(currentStr, start, i);
            }
        }
        return false;
    }

    private static string Swap(string str, int i, int j)
    {
        var characters = str.ToCharArray();
        (characters[j], characters[i]) = (characters[i], characters[j]);
        return new string(characters);
    }
}
