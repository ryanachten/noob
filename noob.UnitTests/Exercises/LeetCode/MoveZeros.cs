using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class MoveZeros
{
    [Theory]
    [InlineData(new object[] { new int[] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0 }, new int[] { 4, 2, 4, 3, 5, 1, 0, 0, 0, 0 } })]
    [InlineData(new object[] { new int[] { -58305, -22022, 0, 0, 0, 0, 0, -76070, 42820, 48119, 0, 95708, -91393, 60044, 0, -34562, 0, -88974 }, new int[] { -58305, -22022, -76070, 42820, 48119, 95708, -91393, 60044, -34562, -88974, 0, 0, 0, 0, 0, 0, 0, 0 } })]
    public void WhenMovingZeroes_ThenZeroesAreMovedToTheBack(int[] arr, int[] expectedResult)
    {
        MoveZeroes(arr);
        Assert.Equal(expectedResult, arr);
    }

    public void MoveZeroes(int[] nums)
    {

        if (nums.Length == 1) return;

        var j = 1;
        for (var i = 0; i < nums.Length; i++)
        {

            if (nums[i] == 0)
            {
                // If j is pointing to a zero, increment it until it's not
                while (nums[j] == 0)
                {
                    // If we've reached the end of the array, we're done here
                    if (j + 1 == nums.Length) break;
                    j++;
                }

                // Swap the zero number, with the non-zero number
                (nums[i], nums[j]) = (nums[j], nums[i]);

                // If we've reached the end of the array, we're done here
                if (j + 1 == nums.Length) break;
            }
            // If j is lower than i, update it to be one ahead
            else if (j <= i)
            {
                j = i + 1;
            }
        }
    }
}
