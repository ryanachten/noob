using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// Assume you have a method isSubstring which checks if one word is a substring
/// of another. Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one
/// call to isSubstring (e.g., "waterbottle" is a rotation of "erbottlewat").
/// </summary>
public class StringRotation
{
    [Theory]
    [InlineData("waterbottle", "erbottlewat", true)]
    [InlineData("tlewaterbot", "waterbottle", true)]
    [InlineData("boterwattle", "waterbozzle", false)]
    [InlineData("waterbottle", "meow", false)]
    public void WhenCheckingIfOneStringIsARotation_ThenARotationIsDetermined(string st1, string st2, bool expectedResult)
    {
        // Act
        // Assumption: the substrings must be contiguous to be considered a "rotation"
        /// we want to:
        /// - iterate through st2 until we find the starting index of the rotation based on the first two chars of st1
        /// - keep iterating through st2 until we reach the start index, or a character doesn't match st1
        var index = GetRotationIndex(st1, st2);
        var result = HasMatchingRotationString(st1, st2, index);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }

    private static int? GetRotationIndex(string st1, string st2)
    {
        int? rotationStartIndex = null;
        for (int i = 0; i < st2.Length; i++)
        {
            var nextIndex = i + 1 > st2.Length - 1 ? 0 : i + 1;
            if (st1[0] == st2[i] && st1[1] == st2[nextIndex])
            {
                rotationStartIndex = i;
                break;
            }
        }
        return rotationStartIndex;
    }

    private static bool HasMatchingRotationString(string st1, string st2, int? rotationStartIndex)
    {
        var result = false;

        if(rotationStartIndex != null)
        {
            var st1Start = 0;
            var st2Start = (int)rotationStartIndex;
            while (st1[st1Start] == st2[st2Start])
            {
                st1Start++;
                st2Start++;

                if (st2Start > st2.Length - 1)
                {
                    st2Start = 0;
                }

                // Keep going until we've either reached the end of the st1
                // or the start of the st2 rotation
                if (st1Start == st1.Length - 1 || st2Start == rotationStartIndex)
                {
                    break;
                }
            }

            // If we've traversed the entire rotation, then the strings are a match
            if(st1Start == st1.Length - 1)
            {
                result = true;
            }
        }

        return result;
    }
}
