using noob.Models.LinkedList;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.LinkedLists;

/// <summary>
/// Write code to remove duplicates from an unsorted linked list.
/// How would you solve this problem if a temporary buffer is not allowed?
/// </summary>
public class RemoveDups
{
    public static IEnumerable<object[]> Lists =>
        new List<object[]>
        {
            new object[] {
                new DoublyLinkedList<int>(1).Append(1).Append(2).Append(3),
                new DoublyLinkedList<int>(1).Append(2).Append(3),
            },
            new object[] {
                new DoublyLinkedList<int>(1).Append(2).Append(3).Append(1),
                new DoublyLinkedList<int>(1).Append(2).Append(3),
            },
            new object[] {
                new DoublyLinkedList<int>(1).Append(3).Append(2).Append(2).Append(3).Append(1),
                new DoublyLinkedList<int>(1).Append(2).Append(3),
            },
        };

    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenRemovingDuplicatesWithNoBuffer_ThenDuplicatesAreRemoved(DoublyLinkedList<int> list, DoublyLinkedList<int> expectedResult)
    {
        // Act
        var node = list.Head;
        while (node != null)
        {
            // Check all previous nodes if the current node's data already exists
            var prevNode = node.Previous;
            while (prevNode != null)
            {
                if(node.Data == prevNode.Data)
                {
                    list.Delete(node.Data);
                    break;
                }

                prevNode = prevNode.Previous;
            }

            node = node.Next;
        }

        // Assert
        Assert.Equal(expectedResult.Items().Count(), list.Items().Count());
    }
}
