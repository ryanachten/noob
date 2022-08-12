using noob.Models.Stack;
using Xunit;

namespace noob.UnitTests.Exercises.StacksAndQueues;

/// <summary>
/// Implement a MyQueue class which implements a queue using two stacks.
/// </summary>
public class QueueViaStacks
{
    public class MyQueue<T> where T : struct
    {
        private T? _firstValue = null;
        private readonly Stack<T> _data = new();
        private readonly Stack<T> _temp = new();

        public MyQueue<T> Add(T item)
        {
            _data.Push(item);
            if(_firstValue == null)
            {
                _firstValue = item;
            }

            return this;
        }

        public T? Remove()
        {
            if (_data.IsEmpty()) return null;

            T? firstValue = null;
            while(firstValue == null)
            {
                var currentValue = _data.Pop();
                if (currentValue != null)
                {
                    // If the stack is empty, we've found the first value
                    // we don't want to add this to the temp stack as it needs to be removed
                    if (_data.IsEmpty())
                    {
                        firstValue = currentValue;
                        _firstValue = _temp.Peek();
                    } else
                    {
                        _temp.Push(currentValue.Value);
                    }
                }
            }

            while (!_temp.IsEmpty())
            {
                var value = _temp.Pop();
                if(value != null)
                {
                    _data.Push((T)value);
                }
            }

            return firstValue;
        }

        public T? Peek() => _firstValue;
    }

    [Fact]
    public void WhenAddingToQueueViaStack_ThenQueueIsUpdatedCorrectly()
    {
        // Arrange
        var queue = new MyQueue<int>();
        
        // Act
        queue.Add(1).Add(2).Add(3);

        // Assert
        Assert.Equal(1, queue.Peek());
    }

    [Fact]
    public void WhenRemovingFromQueueViaStack_ThenQueueIsUpdatedCorrectly()
    {
        // Arrange
        var queue = new MyQueue<int>();
        queue.Add(1).Add(2).Add(3).Add(4);

        // Act
        var result1 = queue.Remove();
        var result2 = queue.Remove();

        // Assert
        Assert.Equal(1, result1);
        Assert.Equal(2, result2);
        Assert.Equal(3, queue.Peek());
    }
}
