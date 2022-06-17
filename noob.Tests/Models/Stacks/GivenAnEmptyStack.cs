using noob.Models.Stack;
using Xunit;

namespace noob.UnitTests.Models.Stacks;

public class GivenAnEmptyStack
{
    [Fact]
    public void WhenPeekingTheStack_ThenNullIsReturned()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        var result = stack.Peek();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void WhenPoppingTheStack_ThenNullIsReturned()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        var result = stack.Pop();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void WhenCheckingIfStackIsEmpty_ThenTrueIsReturned()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        var result = stack.IsEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void WhenPushingToTheStack_ThenTheItemIsAddedToTheTopOfTheStack()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        stack.Push(1).Push(2);

        // Assert
        Assert.False(stack.IsEmpty());
        Assert.Equal(2, stack.Peek());
    }
}
