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
        var result = BinarySearch<int>.Search(arr, 5);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public void WhenSearchingForANonExistingElement_ThenNegativeOneIsReturned()
    {
        // Arrange
        var arr = new int[] { -5, 5, 11, 30, 30, 221, 6018 };

        // Act
        var result = BinarySearch<int>.Search(arr, 999);

        // Assert
        Assert.Equal(-1, result);
    }

    [Theory]
    [InlineData(new int[] { -5, 5, 11, 30, 30, 221, 6018 }, 5, 1)]
    [InlineData(new int[] { -5, 5, 11, 30, 30, 221, 6018 }, -5, 0)]
    [InlineData(new int[] { -5, 5, 11, 30, 30, 221, 6018 }, 6018, 6)]
    public void WhenSearchingForAnExistingElement_ThenElementIndexIsReturned(int[] arr, int target, int expectedIndex)
    {
        // Act
        var result = BinarySearch<int>.Search(arr, target);

        // Assert
        Assert.Equal(expectedIndex, result);
    }
}
