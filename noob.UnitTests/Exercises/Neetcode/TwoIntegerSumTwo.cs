using Xunit;

namespace noob.UnitTests.Exercises.NeetCode;

public class TwoIntegerSumTwo()
{
    public static TheoryData<int[], int, int[]> Numbers() => new()
    {
        {
            [-5,-3,0,2,4,6,8], 5, [2,7]
        },
        {
            [2,3,4], 6, [1,3]
        },
        {
            [1,2,3,4], 3, [1,2]
        }
    };

    [Theory]
    [MemberData(nameof(Numbers))]
    public void GivenListOfNumbers_WhenFindingSum_ThenIndexesComprisingSumAreReturned(int[] numbers, int target, int[] expectedResult)
    {
        var result = TwoSum(numbers, target);

        Assert.Equivalent(expectedResult, result);
    }

    private static int[] TwoSum(int[] numbers, int target)
    {
        var l = 0;
        var r = numbers.Length - 1;

        while (l < r)
        {
            var sum = numbers[l] + numbers[r];

            // If we've found our match, return
            if (sum == target) {
                return [ l + 1, r + 1 ];
            }
            // If sum is grater than the target, decrement y pointer to reduce value
            else if (sum > target)
            { 
                r--;
            }
            // Otherwise increment x pointer to increase value
            else
            {
                l++;
            }
        }

        return [];
    }
}

