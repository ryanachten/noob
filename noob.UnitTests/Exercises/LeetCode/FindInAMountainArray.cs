using System;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class FindInAMountainArray
{
    [Theory]
    [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5, 3, 1 }, 3, 2 })]
    [InlineData(new object[] { new int[] { 0, 1, 2, 4, 2, 1 }, 3, -1 })]
    [InlineData(new object[] { new int[] { 1, 5, 2 }, 2, 2 })]
    [InlineData(new object[] { new int[] { 1, 2, 5, 1 }, 1, 0 })]
    [InlineData(new object[] { new int[] { 3, 5, 3, 2, 0 }, 0, 4 })]
    public void WhenFindingTargetInMountainArray_ThenIndexIsReturned(
        int[] arr, int target, int expectedResult)
    {
        var mountain = new MountainArray(arr);
        var result = FindInMountainArray(target, mountain);
        Assert.Equal(expectedResult, result);
    }

    // A mountain array is one where elements strictly increase until the highest element (peak)
    // then strictly decrease. Elements will appear first on the up slope and duplicates on the down slope
    public int FindInMountainArray(int target, MountainArray mountainArr)
    {
        var maxIndex = mountainArr.Length() - 1;

        // First, find the peak in the mountain array
        var peak = FindPeak(mountainArr, 0, maxIndex, maxIndex);

        // Get occurrence in lower half - if this exists, we don't need to look at upper half
        var lowerHalfIndex = SearchLower(mountainArr, target, 0, peak, maxIndex);
        if (lowerHalfIndex != -1)
        {
            return lowerHalfIndex;
        }
        // If the value doesn't exist in the lower half, then look in the upper half
        return SearchUpper(mountainArr, target, peak, maxIndex, maxIndex);
    }

    public int FindPeak(MountainArray mountainArr, int low, int high, int maxIndex)
    {
        if (low > high) return -1;

        var mid = (low + high) / 2;
        var midVal = mountainArr.Get(mid);
        var leftVal = mid - 1 >= 0 ? mountainArr.Get(mid - 1) : int.MinValue;
        var rightVal = mid + 1 <= maxIndex ? mountainArr.Get(mid + 1) : int.MaxValue;

        // if mid point is greater than the val either side, we've found the peak
        if (midVal > leftVal && midVal > rightVal)
        {
            return mid;
        }
        // if mid point is greater than left but not right, we're on upward slope - go right
        else if (midVal > leftVal && midVal < rightVal)
        {
            return FindPeak(mountainArr, mid + 1, high, maxIndex);
        }
        // if mid point is greater than right but not left, we're on downward slope - go left
        return FindPeak(mountainArr, low, mid - 1, maxIndex);
    }


    // Normal binary search
    public static int SearchLower(MountainArray mountainArr, int target, int low, int high, int maxIndex)
    {
        if (low > high) return -1;

        var midIndex = (low + high) / 2;
        var midVal = mountainArr.Get(midIndex);
        if (midVal == target) return midIndex;

        if (midVal < target)
        {
            return SearchLower(mountainArr, target, midIndex + 1, high, maxIndex);
        }
        return SearchLower(mountainArr, target, low, midIndex - 1, maxIndex);
    }

    // Reverse binary search
    public static int SearchUpper(MountainArray mountainArr, int target, int low, int high, int maxIndex)
    {
        if (low > high) return -1;

        var midIndex = (low + high) / 2;
        var midVal = mountainArr.Get(midIndex);
        if (midVal == target) return midIndex;

        if (midVal > target)
        {
            return SearchUpper(mountainArr, target, midIndex + 1, high, maxIndex);
        }
        return SearchUpper(mountainArr, target, low, midIndex - 1, maxIndex);
    }

    public class MountainArray
    {
        private int _referenceCount = 0;
        private readonly int[] _arr;

        public MountainArray(int[] arr)
        {
            _arr = arr;
        }
        public int Get(int index)
        {
            if (_referenceCount++ > 100)
            {
                throw new Exception("References exceeded 100");
            }
            return _arr[index];
        }
        public int Length()
        {
            if (_referenceCount++ > 100)
            {
                throw new Exception("References exceeded 100");
            }
            return _arr.Length;
        }
    }
}
