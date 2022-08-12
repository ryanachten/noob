using noob.Models.Queue;
using Xunit;

namespace noob.UnitTests.Models.Queues;

public class GivenAnEmptyQueue
{
    [Fact]
    public void WhenPeekingTheQueue_ThenDefaultIsReturned()
    {
        // Arrange
        var queue = new Queue<int>();

        // Act
        var result = queue.Peek();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void WhenCheckingIfQueueIsEmpty_ThenTrueIsReturned()
    {
        // Arrange
        var queue = new Queue<int>();

        // Act
        var result = queue.IsEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void WhenAddingToQueue_ThenItemIsAddedToTheEndOfQueue()
    {
        // Arrange
        var queue = new Queue<int>();

        // Act
        queue.Enqueue(1);

        // Assert
        Assert.Equal(1, queue.Peek());
    }
}
