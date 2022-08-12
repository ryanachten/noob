using noob.Models.LinkedList;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LinkedLists;

/// <summary>
/// Write code to partition a linked list around a value x, such that all nodes less than x come
/// before all nodes greater than or equal to x.If x is contained within the list, the values of x only need
/// to be after the elements less than x(see below). The partition element x can appear anywhere in the
/// "right partition"; it does not need to appear between the left and right partitions.
/// </summary>
public class Partition
{
    public static IEnumerable<object[]> Lists =>
    new List<object[]>
    {
            new object[] {
                new DoublyLinkedList<int>(3).Append(5).Append(8).Append(5).Append(10).Append(2).Append(1),
                5,
                3,
                7
            }
    };

    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenCreatingAPartition_ThenElementsLowerThanTargetAreInLeftParition(
        DoublyLinkedList<int> list,
        int target,
        int expectedLeftPartitionCount,
        int totalCount
    )
    {
        // Arrange
        DoublyLinkedList<int>? leftParition = null;
        DoublyLinkedList<int>? rightParition = null;


        // Act
        // - divide the list into left and right paritions
        var node = list.Head;
        while (node != null)
        {
            if (node.Data < target)
            {
                if(leftParition == null)
                {
                    leftParition = new DoublyLinkedList<int>(node.Data);
                } else
                {
                    leftParition.Append(node.Data);
                }
            }
            else
            {
                if (rightParition == null)
                {
                    rightParition = new DoublyLinkedList<int>(node.Data);
                }
                else
                {
                    rightParition.Append(node.Data);
                }
            }
            node = node.Next;
        }

        // Concatenate the two paritions
        node = leftParition?.Head;
        while (node != null)
        {
            // find the end of the left parition and assign the right partition to it
            if(node.Next == null)
            {
                node.Next = rightParition?.Head;
                if(rightParition?.Head != null)
                {
                    rightParition.Head.Previous = node;
                }
                break;
            }
            node = node?.Next;
        };

        // Assert
        // - ensure that left partition contains elements below target
        // - ensure that right partition contains elements above or equal to target
        var resultNode = leftParition?.Head;
        for (int i = 0; i < totalCount; i++)
        {
            if (i < expectedLeftPartitionCount)
            {
                Assert.True(resultNode?.Data < target);
            }
            else
            {
                Assert.True(resultNode?.Data >= target);
            }
            resultNode = resultNode.Next;
        }
    }
}
