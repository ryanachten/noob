using noob.UnitTests.Exercises.LeetCode.Models;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class AddTwoNumbers
{
    public static IEnumerable<object[]> Lists() => new List<object[]>()
    {
        new object[] {
            new ListNode(2, new ListNode(4, new ListNode(3))),
            new ListNode(5, new ListNode(6, new ListNode(4))),
            new ListNode(7, new ListNode(0, new ListNode(8))),
        },
        new object[] {
            new ListNode(0),
            new ListNode(0),
            new ListNode(0),
        },
        new object[] {
            new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
            new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))),
            new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1)))))))),
        }
    };

    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenAddingTwoNumbersTogether_ThenResultIsReturnedAsReversedListNode(ListNode l1, ListNode l2, ListNode expectedResult)
    {
        var result = SumListNode(l1, l2);
        Assert.Equivalent(expectedResult, result);
    }

    public ListNode SumListNode(ListNode l1, ListNode l2)
    {
        ListNode? result = null;
        ListNode? currentResultNode = null;
        var currentNode1 = l1;
        var currentNode2 = l2;
        var carryOver = 0;

        while (currentNode1 != null || currentNode2 != null || carryOver != 0)
        {
            var value1 = currentNode1 != null ? currentNode1.val : 0;
            var value2 = currentNode2 != null ? currentNode2.val : 0;

            var value = value1 + value2 + carryOver;
            if (value >= 10)
            {
                value -= 10;
                carryOver = 1;
            }
            else
            {
                carryOver = 0;
            }

            var node = new ListNode(value);
            if (currentResultNode == null)
            {
                result = node;
                currentResultNode = node;
            }
            else
            {
                currentResultNode.next = node;
                currentResultNode = currentResultNode.next;
            }

            currentNode1 = currentNode1?.next;
            currentNode2 = currentNode2?.next;
        }

        return result;
    }
}
