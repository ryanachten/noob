using System;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class TwoSum
{
    [Theory]
    [InlineData(new object[] { new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 } })]
    [InlineData(new object[] { new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 } })]
    [InlineData(new object[] { new int[] {3, 3 }, 6, new int[] { 0, 1 } })]
    public void WhenFindingSumOfTarget_ThenIntegersComprisingSumAreFound(int[] nums, int target, int[] expectedResult)
    {
        var result1 = SpaceOptimizedTwoSum(nums, target);
        var result2 = RuntimeOptimizedTwoSum(nums, target);

        Assert.Equal(expectedResult, result1);
        Assert.Equivalent(expectedResult, result2);
    }

    public int[] SpaceOptimizedTwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }
        return Array.Empty<int>();
    }

    public int[] RuntimeOptimizedTwoSum(int[] nums, int target)
    {
        var parsedValues = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var value = nums[i];
            var remainder = target - value;
            if (parsedValues.ContainsKey(remainder))
            {
                return new int[] { i, parsedValues[remainder] };
            }
            else
            {
                parsedValues[value] = i;
            }
        }
        return Array.Empty<int>();
    }
}
