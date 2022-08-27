using System;
using Xunit;

namespace noob.UnitTests.Exercises.CtCI.DynamicProgramming;

/// <summary>
/// A magic index in an array A [ 0 ••• n -1] is defined to be an index such that A[ i] =
/// i.Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in
/// array A.
/// </summary>
public class MagicIndex
{
    [Theory]
    [InlineData(new object[] { new int[] { 0 }, 0 })]
    [InlineData(new object[] { new int[] { 1 }, -1 })]
    [InlineData(new object[] { new int[] { 3, 3, 3, 3 }, 3 })]
    public void WhenIndexMatchesValue_ThenMagicIndexIsReturned(int[] vals, int expectedResult)
    {
        var index1 = BruteForceFindMagicIndex(vals, 0);
        var index2 = BinarySearchMagicIndex(vals, 0, vals.Length - 1);
        Assert.Equal(expectedResult, index1);
        Assert.Equal(expectedResult, index2);
    }

    private int BruteForceFindMagicIndex(int[] vals, int index)
    {
        if (vals[index] == index) return index;
        if (index + 1 >= vals.Length) return -1;

        return BruteForceFindMagicIndex(vals, index + 1);
    }

    private int BinarySearchMagicIndex(int[] vals, int start, int end)
    {
        if (end < start) return -1;

        var midIndex = (start + end) / 2;
        var midValue = vals[midIndex];
        if (midValue == midIndex) return midIndex;

        var leftIndex = Math.Min(midIndex - 1, midValue);
        var leftValue = BinarySearchMagicIndex(vals, start, leftIndex);
        if (leftValue >= 0)
        {
            return leftValue;
        }

        var rightIndex = Math.Max(midIndex + 1, midValue);
        return BinarySearchMagicIndex(vals, rightIndex, end);
    }
}
