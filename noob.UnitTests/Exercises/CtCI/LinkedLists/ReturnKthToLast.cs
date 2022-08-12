using noob.Models.LinkedList;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LinkedLists;

/// <summary>
/// Implement an algorithm to find the kth to last element of a singly linked list
/// </summary>
public class ReturnKthToLast
{
    public static IEnumerable<object[]> Lists =>
    new List<object[]>
    {
            new object[] {
                new SinglyLinkedList<int>(1).Append(1).Append(2).Append(3),
                2,
                2
            },
            new object[] {
                new SinglyLinkedList<int>(1).Append(1).Append(2).Append(3),
                1,
                3
            },
            new object[] {
                new SinglyLinkedList<int>(1).Append(1).Append(2).Append(3),
                4,
                1
            }
    };

    /// <summary>
    /// Initial brute force implementation
    /// </summary>
    /// <param name="list"></param>
    /// <param name="k"></param>
    /// <param name="expectedResult"></param>
    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenFindingTheKthToLastElement_ThenTheKthElementIsReturned(SinglyLinkedList<int> list, int k, int expectedResult)
    {
        // Act
        var node = list.Head;
        var count = 0;
        while (node.Next != null)
        {
            count++;
            node = node.Next;
        }

        node = list.Head;
        for (int i = 0; i <= count - k; i++)
        {
            node = node?.Next;
        }

        var result = node?.Data;

        // Assert
        Assert.Equal(expectedResult, result);
    }

    /// <summary>
    /// Implementation with slightly better time complexity
    /// </summary>
    /// <param name="list"></param>
    /// <param name="k"></param>
    /// <param name="expectedResult"></param>
    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenFindingTheKthToLastElement2_ThenTheKthElementIsReturned(SinglyLinkedList<int> list, int k, int expectedResult)
    {
        // Act
        var node = list.Head;
        int? result = null;
        while (node != null && result == null)
        {
            var nextNode = node.Next;
            for (int i = 1; i <= k; i++)
            {
                // If we've reached k and there's no next node (i.e. we're at the tail)
                // then the current node is the kth node
                if(i == k && nextNode == null)
                {
                    result = node.Data;
                    break;
                } else
                {
                    nextNode = nextNode?.Next;
                }
            }
            node = node.Next;
        }

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
