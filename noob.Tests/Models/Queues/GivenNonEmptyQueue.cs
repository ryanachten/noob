using noob.Models.Queue;
using Xunit;

namespace noob.UnitTests.Models.Queues;

public class GivenNonEmptyQueue
{
    [Fact]
    public void WhenPeekingTheQueue_ThenFirstItemIsReturned()
    {
        // Arrange
        var queue = new Queue<int>().Add(1).Add(2).Add(3);

        // Act
        var result = queue.Peek();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void WhenCheckingIfQueueIsEmpty_ThenFalseIsReturned()
    {
        // Arrange
        var queue = new Queue<int>().Add(1).Add(2).Add(3);

        // Act
        var result = queue.IsEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void WhenRemovingFromQueue_ThenTheFirstItemIsRemoved()
    {
        // Arrange
        var queue = new Queue<int>().Add(1).Add(2).Add(3);

        // Act
        queue.Remove();

        // Assert
        Assert.Equal(2, queue.Peek());
    }
}
