using noob.Models.Stack;
using Xunit;

namespace noob.UnitTests.Exercises.StacksAndQueues;

/// <summary>
/// Write a program to sort a stack such that the smallest items are on the top. You can use
/// an additional temporary stack, but you may not copy the elements into any other data structure
/// (such as an array). The stack supports the following operations: push, pop, peek, and is Empty.
/// </summary>
public class SortStack
{

    [Fact]
    public void WhenSortingStack_ThenStackIsSorted()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1).Push(6).Push(2).Push(10).Push(5);

        // Act
        var sorted = Sort(stack);

        // Assert
        Assert.Equal(1, sorted.Pop());
        Assert.Equal(2, sorted.Pop());
        Assert.Equal(5, sorted.Pop());
        Assert.Equal(6, sorted.Pop());
        Assert.Equal(10, sorted.Pop());
    }

    private static Stack<int> Sort(Stack<int> stack)
    {
        var sorted = new Stack<int>();

        while (!stack.IsEmpty())
        {
            var item = stack.Pop();

            var lastItem = sorted.Peek();
            // If sorted stack is empty, just add the item
            if(lastItem == null)
            {
                sorted.Push((int)item!);
            
            // If new item is smaller than previous
            // append it to the sorted stack
            } else if(item < lastItem)
            {
                sorted.Push((int)item);
            
            // If new item is greater than previous,
            } else
            {
                // dig through stack until we find the proper location
                var numberOfItemsPopped = 0;
                while(sorted.Peek() < item && !sorted.IsEmpty())
                {
                    // use stack as temp storage while sort things out
                    stack.Push((int)sorted.Pop()!);
                    numberOfItemsPopped++;
                }
                
                // then add the new item in correct order
                sorted.Push((int)item!);
                
                // then add the other items back again
                for (int i = 0; i < numberOfItemsPopped; i++)
                {
                    sorted.Push((int)stack.Pop()!);
                }
            }
        }

        return sorted;
    }
}
