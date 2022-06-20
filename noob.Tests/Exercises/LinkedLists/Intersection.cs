using noob.Models.LinkedList;
using Xunit;

namespace noob.UnitTests.Exercises.LinkedLists;

public class Intersection
{
    public static System.Collections.Generic.IEnumerable<object[]> IntersectingLists()
    {
        var list1 = new SinglyLinkedList<int>(1).Append(2).Append(3);
        var list2 = new SinglyLinkedList<int>(1).Append(2);
        var intersection = list1?.Head?.Next?.Next; // node 3
        
        if (list2.Head.Next != null)
        {
            list2.Head.Next.Next = intersection; // Assign List 1, node 3 -> List 2, node 3
        }
        list2.Append(4); // will be appended to both lists 1 and 2

        return new System.Collections.Generic.List<object[]>
        {
                new object[] {
                    list1!,
                    list2,
                    intersection!
                }
        };
    }

    [Theory]
    [MemberData(nameof(IntersectingLists))]
    public void WhenFindingListIntersections_ThenIntersectingNodeIsReturned(
        SinglyLinkedList<int> list1, SinglyLinkedList<int> list2, LinkedListNode<int> expectedNode
    )
    {
        // Act
        var node = list1.Head;
        LinkedListNode<int>? intersection = null;
        while (node != null && intersection == null)
        {
            var node2 = list2?.Head;
            while (node2 != null && intersection == null)
            {
                if(node == node2)
                {
                    intersection = node;
                }

                node2 = node2.Next;
            }

            node = node.Next;
        }

        // Assert
        Assert.Equal(expectedNode, intersection);
    }
}
