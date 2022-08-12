using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace noob.UnitTests.Exercises.HackerRank;

public class MaxMin
{
    [Theory]
    [InlineData(new object[] { new int[] { 1, 4, 7, 2 }, 2, 1 })]
    public void WhenProvidedAnArray_ThenMinUnfairnessIsReturned(int[] arr, int k, int expectedResult)
    {
        var result = maxMin(k, arr.ToList());
        Assert.Equal(expectedResult, result);
    }

    public static int maxMin(int k, List<int> arr)
    {
        var sortedArr = arr.OrderBy(x => x);
        var minDeviation = int.MaxValue;
        for (int i = 0; i + k - 1 < arr.Count; i++)
        {
            var j = i + k - 1;
            var deviation = sortedArr.ElementAt(j) - sortedArr.ElementAt(i);
            minDeviation = Math.Min(deviation, minDeviation);
        }
        return minDeviation;
    }
}
