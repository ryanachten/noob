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
        var comparison = (int a, int b) => {
            if(a == b) return 0;
            return a > b ? 1 : -1;
        };
        var result = QuickSort<int>.Sort(sourceArray, comparison);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
