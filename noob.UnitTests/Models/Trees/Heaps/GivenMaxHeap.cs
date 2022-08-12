using noob.Models.Trees.Heaps;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Models.Trees.Heaps;

public class GivenMaxHeap
{
    [Fact]
    public void WhenInsertingSingleElementToMaxHeap_ThenHeapRootIsSet()
    {
        // Arrange
        var heap = new MinHeap<int, string>(3);

        // Act
        heap.Add(10, "test");

        // Assert
        Assert.Equal(new KeyValuePair<int, string>(10, "test"), heap.Peek());
    }

    [Fact]
    public void WhenInsertingMultipleElementsToMaxHeap_ThenElementsAreAddedInCorrectOrder()
    {
        // Arrange
        var heap = new MinHeap<int, string>(3);

        // Act
        heap.Add(5, "test 1").Add(2, "test 2").Add(3, "test 3").Add(1, "test 4").Add(4, "test 5");

        // Assert
        var expectedKeyOrder = new[] { 5, 4, 3, 2, 1 };
        var expectedValueOrder = new[] { "test 1", "test 5", "test 3", "test 2", "test 4" };

        var index = 0;
        while (heap.Size < 0)
        {
            var result = heap.Pop().GetValueOrDefault();
            Assert.Equal(expectedKeyOrder[index], result.Key);
            Assert.Equal(expectedValueOrder[index], result.Value);
            index++;
        }
    }
}
