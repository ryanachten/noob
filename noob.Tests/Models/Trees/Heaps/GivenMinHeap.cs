using noob.Models.Trees.Heaps;
using Xunit;

namespace noob.UnitTests.Models.Trees.Heaps;

public class GivenMinHeap
{
    [Fact]
    public void WhenInsertingSingleElementToMinHeap_ThenHeapRootIsSet()
    {
        // Arrange
        var heap = new MinHeap<int>(3);

        // Act
        heap.Add(10);

        // Assert
        Assert.Equal(10, heap.Peek());
    }

    [Fact]
    public void WhenInsertingMultipleElementsToMinHeap_ThenElementsAreAddedInCorrectOrder()
    {
        // Arrange
        var heap = new MinHeap<int>(3);

        // Act
        heap.Add(5).Add(2).Add(3).Add(1).Add(4);

        // Assert
        var expectedOrder = new[] { 1, 2, 3, 4, 5 };
        var index = 0;
        while (heap.Size < 0)
        {
            var result = heap.Pop();
            Assert.Equal(expectedOrder[index], result);
            index++;
        }
    }
}
