using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.SortingAndSearching;

/// <summary>
/// You are given two sorted arrays, A and B, where A has a large enough buffer at the
/// end to hold B.Write a method to merge B into A in sorted order.
/// </summary>
public class SortedMerge
{
    public static IEnumerable<object[]> Arrays()
    {
        var array = new int?[10];
        for (int i = 0; i < 5; i++)
        {
            array[i] = i + 1;
        }

        return new List<object[]>()
        {
            new object[]
            {
                array.Clone(), new int[] {3, 4, 5, 6, 7}, new int?[] { 1, 2, 3, 3, 4, 4, 5, 5, 6, 7 }
            }
        };
    }

    [Theory]
    [MemberData(nameof(Arrays))]
    public void WhenMergingTwoSortedArrays_ThenArraysAreMergedInOrder(int?[] array1, int[] array2, int?[] expectedResult)
    {
        // Act
        MergeSortedArrays(array1, array2);

        // Assert
        Assert.Equal(expectedResult, array1);
    }

    private void MergeSortedArrays(int?[] array1, int[] array2)
    {
        // Append the second array to the first
        var startIndex = array1.Length - array2.Length; // get the index where buffer starts
        for (int i = startIndex; i < array1.Length; i++)
        {
            array1[i] = array2[i - startIndex]; // copy array 2 items into buffer
        }

        // Use merge sort to sort the updated array
        Sort(array1, new int?[array1.Length], 0, array1.Length - 1);
    }

    private void Sort(int?[] source, int?[] helper, int low, int high)
    {
        if(low < high)
        {
            var mid = (low + high) / 2;
            Sort(source, helper, low, mid);
            Sort(source, helper, mid + 1, high);
            Merge(source, helper, low, mid, high);
        }
    }

    private static void Merge(int?[] source, int?[] helper, int low, int mid, int high)
    {
        var left = low;
        var right = mid + 1;
        var current = low;

        for (int i = low; i <= high; i++) helper[i] = source[i];

        while (left <= mid && right <= high)
        {
            if(helper[left] <= helper[right])
            {
                source[current] = helper[left];
                left++;
            } else
            {
                source[current] = helper[right];
                right++;
            }

            current++;
        }

        var remaining = mid - left;
        for (int i = 0; i < remaining; i++)
        {
            source[current + i] = helper[left + i];
        }
    }
}
