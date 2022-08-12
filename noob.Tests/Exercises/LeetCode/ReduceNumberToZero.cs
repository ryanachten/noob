using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class ReduceNumberToZero
{
    [Theory]
    [InlineData(14, 6)]
    [InlineData(8, 4)]
    public void WhenReducingNumberToZero_ThenNumberOfStepsToReduceIsReturned(int num, int expectedResult)
    {
        var result = NumberOfSteps(num);
        Assert.Equal(expectedResult, result);
    }

    public int NumberOfSteps(int num)
    {
        var steps = 0;
        while (num > 0)
        {
            num = DivideOrSubtract(num);
            steps++;
        }
        return steps;
    }

    public static int DivideOrSubtract(int num)
    {
        if (num % 2 == 0)
        {
            return num / 2;
        }
        return num - 1;
    }
}
