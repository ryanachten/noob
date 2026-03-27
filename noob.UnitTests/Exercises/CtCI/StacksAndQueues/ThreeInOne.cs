using Xunit;

namespace noob.UnitTests.Exercises.StacksAndQueues;

/// <summary>
/// Describe how you could use a single array to implement three stacks.
/// </summary>
public class ThreeInOne
{
    /// <param name="stackIndex">
    /// Unique index of the stack
    /// </param>
    /// <param name="data">
    /// Data store for all stacks
    /// </param>
    private class Stack<T>(int stackIndex, T?[] data) where T : struct
    {

        /// <summary>
        /// Total number of stacks
        /// </summary>
        private readonly int _numberOfStacks = 3;

        /// <summary>
        /// Capacity for partition
        /// </summary>
        private int Capacity => data.Length / _numberOfStacks;

        /// <summary>
        /// Top index for partition
        /// </summary>
        private int TopIndex => Capacity * stackIndex + Count - 1;

        /// <summary>
        /// Number of items in the stack
        /// </summary>
        private int Count { get; set; } = 0;

        /// <summary>
        /// Top item in the stack
        /// </summary>
        public T? Top
        {
            get => data[TopIndex];
            set => data[TopIndex] = value;
        }

        public T? Pop()
        {
            if (Top == null) return null;

            T? item = Top;
            Top = null;
            Count--;

            return item;
        }

        public Stack<T> Push(T item)
        {
            data[TopIndex + 1] = item;
            Count++;

            return this;
        }
    }

    [Fact]
    public void WhenAddingSingleItemsToStack_ThenArrayIsUpdatedCorrectly()
    {
        // Arrange
        var data = new int?[3];
        var stack1 = new Stack<int>(0, data);
        var stack2 = new Stack<int>(1, data);
        var stack3 = new Stack<int>(2, data);

        // Act
        stack1.Push(1);
        stack2.Push(2);
        stack3.Push(3);

        // Assert
        Assert.Equal([1, 2, 3], data);
    }

    [Fact]
    public void WhenAddingMultipleItemsToStack_ThenArrayIsUpdatedCorrectly()
    {
        // Arrange
        var data = new int?[6];
        var stack1 = new Stack<int>(0, data);
        var stack2 = new Stack<int>(1, data);
        var stack3 = new Stack<int>(2, data);

        // Act
        stack1.Push(1).Push(2);
        stack2.Push(2).Push(3);
        stack3.Push(3).Push(4);

        // Assert
        Assert.Equal([1, 2, 2, 3, 3, 4], data);
    }

    [Fact]
    public void WhenRemovingSingleItemsFromStack_ThenArrayIsUpdatedCorrectly()
    {
        // Arrange
        var data = new int?[6];
        var stack1 = new Stack<int>(0, data);
        var stack2 = new Stack<int>(1, data);
        var stack3 = new Stack<int>(2, data);
        stack1.Push(1).Push(2);
        stack2.Push(2).Push(3);
        stack3.Push(3).Push(4);

        // Act
        var popped1 = stack1.Pop();
        var popped2 = stack2.Pop();
        var popped3 = stack3.Pop();

        // Assert
        Assert.Equal([1, null, 2, null, 3, null], data);
        Assert.Equal(2, popped1);
        Assert.Equal(3, popped2);
        Assert.Equal(4, popped3);
    }

    [Fact]
    public void WhenRemovingMultipleItemsFromStack_ThenArrayIsUpdatedCorrectly()
    {
        // Arrange
        var data = new int?[6];
        var stack1 = new Stack<int>(0, data);
        var stack2 = new Stack<int>(1, data);
        var stack3 = new Stack<int>(2, data);
        stack1.Push(1).Push(2);
        stack2.Push(2).Push(3);
        stack3.Push(3).Push(4);

        // Act
        stack1.Pop();
        stack2.Pop();
        stack3.Pop();
        var popped1 = stack1.Pop();
        var popped2 = stack2.Pop();
        var popped3 = stack3.Pop();

        // Assert
        Assert.Equal([null, null, null, null, null, null], data);
        Assert.Equal(1, popped1);
        Assert.Equal(2, popped2);
        Assert.Equal(3, popped3);
    }
}
