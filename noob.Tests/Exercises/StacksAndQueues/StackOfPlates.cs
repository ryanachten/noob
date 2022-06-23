using noob.Models;
using noob.Models.Stack;
using Xunit;

namespace noob.UnitTests.Exercises.StacksAndQueues;

/// <summary>
/// Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
/// Therefore, in real life, we would likely start a new stack when the previous stack exceeds some
/// threshold.Implement a data structure SetOfStacks that mimics this. SetO-fStacks should be
/// composed of several stacks and should create a new stack once the previous one exceeds capacity.
/// SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack
/// (that is, pop () should return the same values as it would if there were just a single stack).
/// Implement a function popAt(int index) which performs a pop operation on a specific sub-stack.
/// </summary>
public class StackOfPlates
{
    public class SetOfStacks<T> where T : struct
    {
        private readonly int _threshold;
        public readonly ArrayList<Stack<T>> Stacks = new(3);
        public int Count { get; private set; } = 0;
        private Stack<T> CurrentStack => Stacks.Data[Stacks.Count - 1];

        public SetOfStacks(int threshold)
        {
            _threshold = threshold;
            Stacks.Add(new Stack<T>());
        }

        public SetOfStacks<T> Push(T data)
        {
            if(Count + 1 > _threshold * Stacks.Count)
            {
                Stacks.Add(new Stack<T>());
            }
            CurrentStack.Push(data);
            Count++;

            return this;
        }

        public T? Pop()
        {
            if (Count <= 0) return null;

            var result = CurrentStack.Pop();

            // if the current stack is empty and it's not the last stack
            // remove the current stack
            if (result == null && Stacks.Count > 1)
            {
                Stacks.Delete(Stacks.Count - 1);
                result = CurrentStack.Pop();
            }

            Count--;

            return result;
        }

        public T? PopAt(int index)
        {
            if (index > Stacks.Count - 1) return null;

            var stack = Stacks.Data[index];

            Count--;

            return stack.Pop();
        }
    }

    [Fact]
    public void WhenAddingElements_ThenStackHasCorrectNumberOfItems()
    {
        // Arrange
        var stacks = new SetOfStacks<int>(10);

        // Act
        stacks.Push(1).Push(2).Push(3);

        // Assert
        Assert.Equal(3, stacks.Count);
        Assert.Equal(1, stacks.Stacks.Count);
        Assert.Equal(3, stacks.Stacks.Data[0].Peek());
    }

    [Fact]
    public void WhenAddingElementsOverThreshold_ThenStackHasCorrectNumberOfItems()
    {
        // Arrange
        var stacks = new SetOfStacks<int>(2);

        // Act
        stacks.Push(1).Push(2).Push(3);

        // Assert
        Assert.Equal(3, stacks.Count);
        Assert.Equal(2, stacks.Stacks.Count);
        Assert.Equal(2, stacks.Stacks.Data[0].Peek());
        Assert.Equal(3, stacks.Stacks.Data[1].Peek());
    }

    [Fact]
    public void WhenRemovingElements_ThenStackHasCorrectNumberOfItems()
    {
        // Arrange
        var stacks = new SetOfStacks<int>(2);
        stacks.Push(1).Push(2).Push(3);

        // Act
        var result1 = stacks.Pop();
        var result2 = stacks.Pop();

        // Assert
        Assert.Equal(3, result1);
        Assert.Equal(2, result2);
        Assert.Equal(1, stacks.Count);
        Assert.Equal(1, stacks.Stacks.Count);
        Assert.Equal(1, stacks.Stacks.Data[0].Peek());
    }

    [Fact]
    public void WhenRemovingElementsAtIndex_ThenCorrectStackIsUpdated()
    {
        // Arrange
        var stacks = new SetOfStacks<int>(3);
        stacks
            .Push(1).Push(2).Push(3)
            .Push(4).Push(5).Push(6)
            .Push(7).Push(8).Push(9);

        // Act
        var result1 = stacks.PopAt(0);
        var result2 = stacks.PopAt(1);
        var result3 = stacks.PopAt(2);
        var result4 = stacks.PopAt(4);

        // Assert
        Assert.Equal(6, stacks.Count);
        Assert.Equal(3, stacks.Stacks.Count);
        Assert.Equal(3, result1);
        Assert.Equal(6, result2);
        Assert.Equal(9, result3);
        Assert.Null(result4);
        Assert.Equal(2, stacks.Stacks.Data[0].Peek());
        Assert.Equal(5, stacks.Stacks.Data[1].Peek());
        Assert.Equal(8, stacks.Stacks.Data[2].Peek());
    }
}
