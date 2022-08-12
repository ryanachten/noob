using noob.Models.Stack;
using Xunit;

namespace noob.UnitTests.Models.Stacks;

public class GivenNonEmptyStack
{
    [Fact]
    public void WhenPeekingTheStack_ThenTheLatestItemIsReturned()
    {
        // Arrange
        var stack = new Stack<int>().Push(1).Push(2).Push(3);

        // Act
        var result = stack.Peek();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void WhenPoppingTheStack_ThenLatestItemIsReturnedAndRemoved()
    {
        // Arrange
        var stack = new Stack<int>().Push(1).Push(2).Push(3);

        // Act
        var result = stack.Pop();

        // Assert
        Assert.Equal(3, result);
        Assert.Equal(2, stack.Peek());
    }

    [Fact]
    public void WhenCheckingIfStackIsEmpty_ThenFalseIsReturned()
    {
        // Arrange
        var stack = new Stack<int>().Push(1).Push(2).Push(3);

        // Act
        var result = stack.IsEmpty();

        // Assert
        Assert.False(result);
    }
}
