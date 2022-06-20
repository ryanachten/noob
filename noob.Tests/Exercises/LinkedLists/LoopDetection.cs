using noob.Models;
using noob.Models.LinkedList;
using Xunit;

namespace noob.UnitTests.Exercises.LinkedLists;

/// <summary>
/// Given a circular linked list, implement an algorithm that returns the node at the 
/// beginning of the loop.
/// </summary>
public class LoopDetection
{
    public static System.Collections.Generic.IEnumerable<object[]> CircularLists()
    {
        var list = new DoublyLinkedList<char>('A').Append('B').Append('C').Append('D').Append('E');
        var repeatedNode = list?.Head?.Next?.Next; // Node C

        if (list?.Head?.Next?.Next?.Next?.Next != null)
        {
            list.Head!.Next!.Next!.Next!.Next!.Next = repeatedNode;
        }

        return new System.Collections.Generic.List<object[]>
        {
            new object[] {
                list!,
                repeatedNode!
            }
        };
    }

    [Theory]
    [MemberData(nameof(CircularLists))]
    public void WhenStartOfCircularList_ThenCircularListNodeIsReturned(
        DoublyLinkedList<char> list, LinkedListNode<char> expectedNode
    )
    {
        // Act
        /// Not sure we can store the node's we've checked in a linked list
        /// since the links are cicular and result in infinite loops
        /// to avoid this, we can store these in an array instead 
        var history = new ArrayList<LinkedListNode<char>>(3);
        var node = list.Head;
        LinkedListNode<char>? circularNode = null;
        while (node != null && circularNode == null)
        {
            for (int i = 0; i < history.Count; i++)
            {
                var existingNode = history.Data[i];
                if (existingNode == node)
                {
                    circularNode = existingNode;
                    break;
                }
            }
            history.Add(node);

            node = node.Next;
        }

        // Assert
        Assert.Equal(expectedNode, circularNode);
    }
}
