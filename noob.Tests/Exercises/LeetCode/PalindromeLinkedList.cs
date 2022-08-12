using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class PalindromeLinkedList
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

    [Fact]
    public void WhenDeterminigIfLinkedListIsPalindrome_ThenCorrectResultIsReturned()
    {
        var list = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
        var result = IsPalindrome(list);
        Assert.True(result);
    }

    public bool IsPalindrome(ListNode head)
    {
        var node = head;
        var values = new List<int>();
        while (node != null)
        {
            values.Add(node.val);
            node = node.next;
        }
        for (var i = 0; i < values.Count / 2; i++)
        {
            var a = values[i];
            var b = values[values.Count - 1 - i];
            if (a != b)
            {
                return false;
            }
        }
        return true;
    }
}
