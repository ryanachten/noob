using noob.Algorithms.Sorting;
using Xunit;

namespace noob.UnitTests.Algorithms.Sorting;

public class BubbleSortTests : BaseSortTests
{
    [Theory]
    [MemberData(nameof(UnsortedArrays))]
    public void WhenSortingAnArray_ThenAnArrayIsSorted(int[] sourceArray, int[] expectedResult)
    {
        // Act
        var result = BubbleSort.Sort(sourceArray);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
