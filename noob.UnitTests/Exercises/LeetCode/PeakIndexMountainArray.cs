using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class PeakIndexMountainArray
{
    [Theory]
    [InlineData(new object[] { new int[] { 0, 1, 0 }, 1 })]
    [InlineData(new object[] { new int[] { 0, 2, 1, 0 }, 1 })]
    [InlineData(new object[] { new int[] { 0, 10, 5, 2 }, 1 })]
    [InlineData(new object[] { new int[] { 3, 5, 3, 2, 0 }, 1 })]
    public void WhenFindingPeakInMountainArray_ThenHighestNumberIsReturned(int[] arr, int expectedResult)
    {
        var result = PeakIndexInMountainArray(arr);
        Assert.Equal(expectedResult, result);
    }

    public int PeakIndexInMountainArray(int[] arr)
    {
        return Search(arr, 0, arr.Length - 1);
    }

    public int Search(int[] arr, int low, int high)
    {
        if (low > high) return -1;

        var mid = (low + high) / 2;
        var midVal = arr[mid];
        var leftVal = mid - 1 >= 0 ? arr[mid - 1] : int.MinValue;
        var rightVal = mid + 1 <= arr.Length - 1 ? arr[mid + 1] : int.MaxValue;

        // if mid point is greater than the val either side, we've found the peak
        if (midVal > leftVal && midVal > rightVal)
        {
            return mid;
        }
        // if mid point is greater than left but not right, we're on upward slope - go right
        else if (midVal > leftVal && midVal < rightVal)
        {
            return Search(arr, mid + 1, high);
        }
        // if mid point is greater than right but not left, we're on downward slope - go left
        return Search(arr, low, mid - 1);
    }
}
