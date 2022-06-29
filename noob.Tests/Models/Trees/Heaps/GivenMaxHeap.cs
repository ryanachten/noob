using noob.Models.Trees.Heaps;
using Xunit;

namespace noob.UnitTests.Models.Trees.Heaps;

public class GivenMaxHeap
{
    [Fact]
    public void WhenInsertingSingleElementToMaxHeap_ThenHeapRootIsSet()
    {
        // Arrange
        var heap = new MinHeap<int>(3);

        // Act
        heap.Add(10);

        // Assert
        Assert.Equal(10, heap.Peek());
    }

    [Fact]
    public void WhenInsertingMultipleElementsToMaxHeap_ThenElementsAreAddedInCorrectOrder()
    {
        // Arrange
        var heap = new MaxHeap<int>(3);

        // Act
        heap.Add(5).Add(2).Add(3).Add(1).Add(4);

        // Assert
        var expectedOrder = new[] { 5, 4, 3, 2, 1 };
        var index = 0;
        while (heap.Size < 0)
        {
            var result = heap.Pop();
            Assert.Equal(expectedOrder[index], result);
            index++;
        }
    }
}
