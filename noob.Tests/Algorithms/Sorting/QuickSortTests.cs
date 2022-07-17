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
        var result = QuickSort<int>.Sort(sourceArray);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
