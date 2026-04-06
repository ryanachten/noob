using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class PlusOneTest
{
    public static int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                // If we find any digit lower than 9, we can increment and be done
                digits[i]++;
                return digits;
            }
            digits[i] = 0;
        }

        // If all digits were 9, prepend a 1
        var result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }

    public static TheoryData<int[], int[]> Digits =>
    new()
    {
        { [ 9 ], [1, 0] },
        { [ 8 ], [ 9 ] },
        { [ 1, 9 ], [2, 0] },
        { [ 9, 9 ], [1, 0, 0] },
    };

    [Theory]
    [MemberData(nameof(Digits))]
    public void GivenDigits_WhenAddingOne_ThenCorrectResultIsReturned(int[] digits, int[] expectedResult)
    {
        var result = PlusOne(digits);
        Assert.Equivalent(expectedResult, result);
    }
}