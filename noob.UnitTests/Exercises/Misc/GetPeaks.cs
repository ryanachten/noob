using Xunit;

namespace noob.UnitTests.Exercises.Misc;

public class GetPeaks
{
    [Theory]
    [InlineData(new object[] { new int[] { }, 0 })]
    [InlineData(new object[] { new int[] { 1, 2 }, 0 })]
    [InlineData(new object[] { new int[] { 2, 2, 1, 2, 2 }, 0 })]
    [InlineData(new object[] { new int[] { 0, 4, 2, 9, 2, 3, 5, 0 }, 3 })]
    public void GivenPeaksInAGraph_ThenNumberOfPeaksIsReturned(int[] arr, int expectedResult)
    {
        var actual = GetNumberOfPeaks(arr);
        Assert.Equal(expectedResult, actual);
    }

    private static int GetNumberOfPeaks(int[] arr)
    {
        if (arr.Length < 3) return 0;

        var peaks = 0;
        for (int i = 1; i < arr.Length - 1; i++)
        {
            var current = arr[i];
            var previous = arr[i - 1];
            var next = arr[i + 1];
            if (current > previous && current > next)
            {
                peaks++;
            }
        }
        return peaks;
    }
}
