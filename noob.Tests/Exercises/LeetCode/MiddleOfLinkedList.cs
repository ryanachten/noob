using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class MiddleOfLinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static IEnumerable<object[]> Lists() => new List<object[]>()
    {
        new object[] {
            new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))),
            3
        },
        new object[] {
            new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))),
            4
        }
    };

    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenGettingMiddleNode_ThenCorrectNodeIsReturned(ListNode head, int expectedResult)
    {
        var result1 = RuntimeOptimizedMiddleNode(head);
        var result2 = SpaceOptimizedMiddleNode(head);

        Assert.Equal(expectedResult, result1.val);
        Assert.Equal(expectedResult, result2.val);
    }

    public ListNode RuntimeOptimizedMiddleNode(ListNode head)
    {
        var nodes = new List<ListNode>();
        var currentNode = head;
        while (currentNode != null)
        {
            nodes.Add(currentNode);
            currentNode = currentNode.next;
        }
        var middleIndex = Math.Ceiling((double)(nodes.Count / 2));
        return nodes.ElementAt((int)middleIndex);
    }

    public ListNode SpaceOptimizedMiddleNode(ListNode head)
    {
        var currentNode = head;
        var count = 0;
        while (currentNode != null)
        {
            count++;
            currentNode = currentNode.next;
        }
        var middleIndex = Math.Ceiling((double)(count / 2));
        currentNode = head;
        for (var i = 0; i < middleIndex; i++)
        {
            currentNode = currentNode.next;
        }
        return currentNode;
    }
}
