using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class MedianOfTwoSortedArrays
{
    [Theory]
    [InlineData(new object[] { new int[] { 1, 3 }, new int[] { 2 }, 2.0 })]
    [InlineData(new object[] { new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5 })]
    [InlineData(new object[] { new int[] { 1, 4 }, new int[] { 2, 3, 5, 6 }, 3.5 })]
    [InlineData(new object[] { new int[] { 1 }, new int[] { 2, 3, 4, 5, 6 }, 3.5 })]
    public void WhenFindingMedianOfTwoArrays_ThenAvgMedianIsFound(int[] arr1, int[] arr2, double expectedResult)
    {
        var result1 = BruteForceFindMedianSortedArrays(arr1, arr2);
        var result2 = FindKthFindMedianSortedArrays(arr1, arr2);

        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult, result2);
    }

    public double BruteForceFindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var combinedArrayLength = nums1.Length + nums2.Length;
        var mergedList = new List<int>(combinedArrayLength);
        mergedList.AddRange(nums1);
        mergedList.AddRange(nums2);
        mergedList.Sort(); // will use introsort with worst case of O(n log n)

        // If we have an uneven number, then there's only one median number
        if (combinedArrayLength % 2 != 0)
        {
            var index = combinedArrayLength / 2;
            return mergedList.ElementAt(index);
        }

        // If a number is even, we have two medians
        // we get the two medians and average them
        var upperIndex = combinedArrayLength / 2;
        var upperBound = mergedList.ElementAt(upperIndex);
        var lowerBound = mergedList.ElementAt(upperIndex - 1);

        return (lowerBound + upperBound) / 2.0;
    }

    /// <summary>
    /// Space optimized solution using binary search
    /// Actually seems to have a slower runtime than brute force solution
    /// </summary>
    public double FindKthFindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var combinedLength = nums1.Length + nums2.Length;

        // If combined length is even, we have two medians so we need to avg them
        var midpoint = combinedLength / 2;
        if (combinedLength % 2 == 0)
        {
            var lowerBound = FindKthElement(nums1, 0, nums2, 0, midpoint);
            var upperBound = FindKthElement(nums1, 0, nums2, 0, midpoint + 1);
            return (lowerBound + upperBound) / 2.0;
        }

        // If odd, we only have one median so find it it
        return FindKthElement(nums1, 0, nums2, 0, midpoint + 1);
    }

    /// <summary>
    /// Recursively find Kth element in two arrays
    /// </summary>
    private int FindKthElement(int[] a, int aIndex, int[] b, int bIndex, int k)
    {
        // If we've exceeded one array's length, then continue with the other
        if (aIndex >= a.Length) return b[bIndex + k - 1];
        if (bIndex >= b.Length) return a[aIndex + k - 1];

        // If we're finding the first element, then return min of a and b
        if (k == 1)
        {
            return Math.Min(a[aIndex], b[bIndex]);
        }

        // Compute midpoints based on current index
        var aMid = aIndex + k / 2 - 1;
        var bMid = bIndex + k / 2 - 1;

        // Get value based on midpoints, fallback to max val if exceeding array length
        var aVal = aMid >= a.Length ? int.MaxValue : a[aMid];
        var bVal = bMid >= b.Length ? int.MaxValue : b[bMid];

        var newK = k - k / 2; // half k to reduce number of items we're look at

        // Throw away half of the array based on which value is greater
        if (aVal < bVal)
        {
            return FindKthElement(a, aMid + 1, b, bIndex, newK);
        }
        return FindKthElement(a, aIndex, b, bMid + 1, newK);
    }
}