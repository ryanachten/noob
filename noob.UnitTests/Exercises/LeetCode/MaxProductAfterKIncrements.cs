using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class MaxProductAfterKIncrements
{
    [Theory]
    [InlineData(new object[] { new[] { 0, 4 }, 5, 20 })]
    [InlineData(new object[] { new[] { 6, 3, 3, 2 }, 2, 216 })]
    [InlineData(new object[] { new[] { 24, 5, 64, 53, 26, 38 }, 54, 180820950 })]
    public void WhenFindingMaxAfterIncrements_ThenMaxSumProductIsReturned(int[] nums, int k, int expectedResult)
    {
        var result = MaximumProduct(nums, k);
        Assert.Equal(expectedResult, result);
    }

    public int MaximumProduct(int[] nums, int k)
    {
        var queue = new PriorityQueue<int, int>();

        // Add numbers with a priority equal to own value
        foreach (var num in nums) queue.Enqueue(num, num);

        // For each iteration of k
        // dequeue smallest number and increment it, before adding it back to the queue
        // this ensures we're always incrementing the smallest number in the array
        while (k != 0)
        {
            var min = queue.Dequeue();
            min++;
            queue.Enqueue(min, min);
            k--;
        }

        // Finally, we multiply the resulting numbers together, using a modulo to keep in range
        var total = 1.0;
        while (queue.Count != 0)
        {
            total = (total * queue.Dequeue()) % 1000000007;
        }
        return (int)total;
    }
}
