using noob.Algorithms.Sorting;
using Xunit;

namespace noob.UnitTests.Algorithms.Sorting;

public class MergeSortTests : BaseSortTests
{
    [Theory]
    [MemberData(nameof(UnsortedArrays))]
    public void WhenSortingAnArray_ThenAnArrayIsSorted(int[] sourceArray, int[] expectedResult)
    {
        // Act
        var result1 = MergeSort<int>.Sort(sourceArray);
        var result2 = SimpleMergeSort(sourceArray, new int[sourceArray.Length], 0, sourceArray.Length - 1);

        // Assert
        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult, result2);
    }

    /// <summary>
    /// Recursively halves the array and sorts subdivisions
    /// before merging the sorted subdivisions back together
    /// </summary>
    private int[] SimpleMergeSort(int[] source, int[] helper, int low, int high)
    {
        if (low < high)
        {
            var mid = (low + high) / 2;
            SimpleMergeSort(source, helper, low, mid);
            SimpleMergeSort(source, helper, mid + 1, high);
            Merge(source, helper, low, mid, high);
        }
        return source;
    }

    private static void Merge(int[] source, int[] helper, int low, int mid, int high)
    {
        for (var i = low; i <= high; i++)
        {
            helper[i] = source[i];
        }

        var left = low;
        var right = mid + 1;
        var current = low;

        // Iterate through helper array, compare two halves
        // copy the smaller element to the source array
        // and move the pointer accordingly
        while (left <= mid && right <= high)
        {
            if (helper[left] <= helper[right])
            {
                source[current] = helper[left];
                left++;
            }
            else
            {
                source[current] = helper[right];
                right++;
            }
            current++;
        }

        // Copy remaining left side of the helper
        // right hald has already been copied at the point
        var remaining = mid - left;
        for (var i = 0; i <= remaining; i++)
        {
            source[current + i] = helper[left + i];
        }
    }
}
