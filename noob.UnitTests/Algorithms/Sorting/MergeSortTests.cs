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
        var result = MergeSort<int>.Sort(sourceArray);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
