using Xunit;

namespace noob.UnitTests.Exercises.CtCI.DynamicProgramming;

/// <summary>
/// A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
/// steps at a time. Implement a method to count how many possible ways the child can run up the
/// stairs.
/// </summary>
public class TripleStep
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 4)] // 111, 12, 21, 3
    [InlineData(4, 7)] // 1111, 112, 211, 121, 22, 13, 31
    public void WhenRunningUpStairs_ThenPossibleNumberOfWaysIsReturned(int n, int expectedResult)
    {
        var result1 = RunningUpStairs(n);
        var result2 = RunningUpStairs(n, new int?[n + 1]);

        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult, result2);
    }

    /// <summary>
    /// Non-memoized implementation - O(3^n) runtime
    /// </summary>
    private int RunningUpStairs(int n)
    {
        if (n < 0) return 0;
        if (n == 0) return 1;

        return RunningUpStairs(n - 1) + RunningUpStairs(n - 2) + RunningUpStairs(n - 3);
    }

    /// <summary>
    /// Memoized implementation - O(n) runtime
    /// </summary>
    private int RunningUpStairs(int n, int?[] memo)
    {
        if (n < 0) return 0;
        if (n == 0) return 1;

        if (memo[n] == null)
        {
            memo[n] = RunningUpStairs(n - 1, memo) + RunningUpStairs(n - 2, memo) + RunningUpStairs(n - 3, memo);
        }

        return (int)memo[n]!;
    }
}
