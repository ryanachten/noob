using noob.Algorithms.Sorting;
using Xunit;

namespace noob.UnitTests.Algorithms.Sorting;

public class QuickSortTests : BaseSortTests
{
    [Theory]
    [MemberData(nameof(UnsortedArrays))]
    public void WhenSortingAnArray_ThenAnArrayIsSorted(int[] sourceArray, int[] expectedResult)
    {
        // Act
        var comparison = (int a, int b) =>
        {
            if (a == b) return 0;
            return a > b ? 1 : -1;
        };
        var result1 = QuickSort<int>.Sort(sourceArray, comparison);
        var result2 = SimpleQuickSort(sourceArray, 0, sourceArray.Length - 1);

        // Assert
        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult, result2);
    }

    private int[] SimpleQuickSort(int[] arr, int left, int right)
    {
        var index = Partition(arr, left, right);

        if (left < index - 1) SimpleQuickSort(arr, left, index - 1);
        if (index < right) SimpleQuickSort(arr, right, index);

        return arr;
    }

    private static int Partition(int[] arr, int left, int right)
    {
        var mid = (left + right) / 2;
        while (left <= right)
        {
            while (arr[left] < arr[mid]) left++; // increase left pointer until it is no longer lower than mid
            while (arr[right] > arr[mid]) right--; // increase right pointer until it is no longer higher than mid

            // If the pointers are still in the right order, wrap their values
            if (left <= right)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
                left++;
                right--;
            }
        }

        // Return the left pointer as the new index
        return left;
    }
}
