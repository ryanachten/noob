using noob.Models.LinkedList;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LinkedLists;

/// <summary>
/// Implement an algorithm to delete a node in the middle (i.e., any node but
/// the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
/// that node.
/// </summary>
public class DeleteMiddleNode
{
    public static IEnumerable<object[]> Lists =>
    new List<object[]>
    {
            new object[] {
                new SinglyLinkedList<char>('a').Append('b').Append('c').Append('d').Append('e').Append('f'),
                'c',
                new SinglyLinkedList<char>('a').Append('b').Append('d').Append('e').Append('f'),
            }
    };

    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenDeletingMiddleNode_ThenMiddleNodeIsDeleted(SinglyLinkedList<char> list, char target, SinglyLinkedList<char> expectedResult)
    {
        // Act
        // - check the current node's next node to see if it matches the target
        // if it does, orphan it from the list
        var node = list.Head;
        while (node.Next != null)
        {
            if (node.Next.Data == target)
            {
                node.Next = node.Next.Next;
                break;
            }
            node = node.Next;
        }

        // Assert
        Assert.Equal(expectedResult.ToFormattedString(), list.ToFormattedString());
    }
}
