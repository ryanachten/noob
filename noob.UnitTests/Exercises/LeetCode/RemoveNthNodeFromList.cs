using noob.UnitTests.Exercises.LeetCode.Models;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class RemoveNthNodeFromList
{
    public static IEnumerable<object[]> Lists() => new List<object[]>()
    {
        new object[] {
            new ListNode(1, new ListNode(2, new ListNode(3))),
            2,
            new ListNode(1, new ListNode(3)),
        },
        new object[] {
            new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))),
            2,
            new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(5)))),
        }
    };

    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenRemovingNthNode_ThenCorrectNodeIsRemoved(ListNode head, int n, ListNode expectedResult)
    {
        var updatedHead = RemoveNthFromEnd(head, n);
        Assert.Equivalent(expectedResult, updatedHead);
    }

    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        // If there's no nodes to iterate through, then return null node
        if (head.next == null) return null;

        var node = head;
        var prevNode = head;
        var i = 0;

        while (node != null)
        {
            // If we're at the end of the linked list - remove the nth node
            if (node.next == null)
            {
                // If the total number of nodes equals n, then we need to remove head
                if (i + 1 == n) return head.next;

                // Otherwise, we remove the next prev node
                prevNode.next = prevNode.next?.next;
                break;
            }

            // If we've past n nodes, track the nth node for later removal
            if (i >= n)
            {
                prevNode = prevNode.next;
            }
            node = node.next;
            i++;
        }

        return head;
    }
}
