using noob.Algorithms.Searching;
using Xunit;

namespace noob.UnitTests.Algorithms.Searching;

public class BinarySearchTests
{
    [Fact]
    public void WhenSearchingForAnUnsortedArray_ThenNegativeOneIsReturned()
    {
        // Arrange
        var arr = new int[] { 5, 221, 30, -5, 6018, 11, 30 };

        // Act
        var result1 = BinarySearch<int>.SearchRecursive(arr, 5);
        var result2 = BinarySearch<int>.SearchIterative(arr, 5);

        // Assert
        Assert.Equal(-1, result1);
        Assert.Equal(-1, result2);
    }

    [Fact]
    public void WhenSearchingForANonExistingElement_ThenNegativeOneIsReturned()
    {
        // Arrange
        var arr = new int[] { -5, 5, 11, 30, 30, 221, 6018 };

        // Act
        var result1 = BinarySearch<int>.SearchRecursive(arr, 999);
        var result2 = BinarySearch<int>.SearchIterative(arr, 999);


        // Assert
        Assert.Equal(-1, result1);
        Assert.Equal(-1, result2);
    }

    [Theory]
    [InlineData(new int[] { -5, 5, 11, 30, 30, 221, 6018 }, 5, 1)]
    [InlineData(new int[] { -5, 5, 11, 30, 30, 221, 6018 }, -5, 0)]
    [InlineData(new int[] { -5, 5, 11, 30, 30, 221, 6018 }, 6018, 6)]
    public void WhenSearchingForAnExistingElement_ThenElementIndexIsReturned(int[] arr, int target, int expectedIndex)
    {
        // Act
        var result1 = BinarySearch<int>.SearchRecursive(arr, target);
        var result2 = BinarySearch<int>.SearchIterative(arr, target);
        var result3 = SimpleBinarySearch(arr, target);

        // Assert
        Assert.Equal(expectedIndex, result1);
        Assert.Equal(expectedIndex, result2);
        Assert.Equal(expectedIndex, result3);
    }

    /// <summary>
    /// Minimal implementation of binary search
    /// </summary>
    private static int SimpleBinarySearch(int[] arr, int target)
    {
        var left = 0;
        var right = arr.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (arr[mid] == target) return mid;

            if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
}
