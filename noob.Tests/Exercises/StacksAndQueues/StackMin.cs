using noob.Models.Stack;
using Xunit;

namespace noob.UnitTests.Exercises.StacksAndQueues;

/// <summary>
/// How would you design a stack which, in addition to push and pop, has a function min
/// which returns the minimum element? Push, pop and min should all operate in 0(1) time.
/// </summary>
public class StackMin
{
    public class Stack
    {
        public StackNode<int>? Top { get; set; }
        private StackNode<int>? _min = null;

        public int? Pop()
        {
            if(Top == null) return null;
            
            var item = Top;
            Top = item.Next;

            if(_min == item)
            {
                UpdateMin();
            }

            return item.Data;
        }

        public Stack Push(int data)
        {
            var node = new StackNode<int>(data)
            {
                Next = Top
            };
            Top = node;
            
            if(_min == null || _min.Data > node.Data)
            {
                _min = node;
            }

            return this;
        }

        public int? Min() => _min?.Data;

        private void UpdateMin()
        {
            var min = Top;
            var node = Top;
            while (node != null)
            {
                if(node.Data < min?.Data)
                {
                    min = node;
                }

                node = node.Next;
            }

            _min = min;
        }
    }

    [Fact]
    public void WhenAddingToStack_ThenMinShouldBeCorrectlyUpdated()
    {
        // Arrange
        var stack = new Stack();
        stack.Push(3).Push(2).Push(1).Push(10).Push(3);

        // Act
        var result = stack.Min();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void WhenRemovingFromStack_ThenMinShouldBeCorrectlyUpdated()
    {
        // Arrange
        var stack = new Stack();
        stack.Push(3).Push(8).Push(10).Push(2).Push(1);
        stack.Pop();
        stack.Pop();

        // Act
        var result = stack.Min();

        // Assert
        Assert.Equal(3, result);
    }
}
