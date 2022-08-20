using Xunit;

namespace noob.UnitTests.Exercises.CtCI.DynamicProgramming;

public class NthFibonacci
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(9, 34)]
    [InlineData(14, 377)]
    public void WhenDeterminingNthFibonannci_ThenCorrectResultIsReturned(int n, int expectedResult)
    {
        var result1 = Fibonacci(n);
        var result2 = Fibonacci(n, new int[n + 1]);

        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult, result2);
    }

    /// <summary>
    /// Non-memoized implementation - approx O(2^n) runtime
    /// </summary>
    private int Fibonacci(int i)
    {
        if (i == 0 || i == 1) return i;

        return Fibonacci(i - 1) + Fibonacci(i - 2);
    }

    /// <summary>
    /// Memoized implementation - O(n) runtime
    /// </summary>
    private int Fibonacci(int i, int[] memo)
    {
        if (i == 0 || i == 1) return i;
        if (memo[i] == 0)
        {
            memo[i] = Fibonacci(i - 1, memo) + Fibonacci(i - 2, memo);
        }
        return memo[i];
    }
}
