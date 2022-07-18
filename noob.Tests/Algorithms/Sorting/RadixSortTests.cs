using noob.Algorithms.Sorting;
using Xunit;

namespace noob.UnitTests.Algorithms.Sorting;

public class RaadixSortTests : BaseSortTests
{
    [Theory]
    [MemberData(nameof(UnsortedArrays))]
    public void WhenSortingAnArray_ThenAnArrayIsSorted(int[] sourceArray, int[] expectedResult)
    {
        // Act
        RadixSort.Sort(sourceArray);

        // Assert
        Assert.Equal(expectedResult, sourceArray);
    }
}
