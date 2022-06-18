using noob.Models.LinkedList;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LinkedLists;

/// <summary>
/// You have two numbers represented by a linked list, where each node contains a single
/// digit.The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
/// function that adds the two numbers and returns the sum as a linked list.
/// </summary>
public class SumList
{
    public static IEnumerable<object[]> Lists =>
    new List<object[]>
    {
            new object[] {
                new SinglyLinkedList<int>(6).Append(1).Append(7),
                new SinglyLinkedList<int>(2).Append(9).Append(5),
                new SinglyLinkedList<int>(9).Append(1).Append(2)
            }
    };

    public static IEnumerable<object[]> ReversedLists =>
    new List<object[]>
    {
            new object[] {
                new SinglyLinkedList<int>(7).Append(1).Append(6),
                new SinglyLinkedList<int>(5).Append(9).Append(2),
                new SinglyLinkedList<int>(2).Append(1).Append(9)
            }
    };

    [Theory]
    [MemberData(nameof(Lists))]
    public void WhenAddingDigitsInLinkedList_ThenResultIsReturnedInLinkedList(SinglyLinkedList<int> list1, SinglyLinkedList<int> list2, SinglyLinkedList<int> expectedResult)
    {
        // Act
        var sum = GetNumberFromLinkedList(list1) + GetNumberFromLinkedList(list2);
        SinglyLinkedList<int>? result = null;

        foreach (var item in sum.ToString())
        {
            var str = int.Parse(item.ToString());
            if (result == null)
            {
                result = new(str);
            }
            else
            {
                result.Append(str);
            }
        }

        // Assert
        Assert.Equal(expectedResult.ToFormattedString(), result?.ToFormattedString());
    }

    [Theory]
    [MemberData(nameof(ReversedLists))]
    public void WhenAddingDigitsInReversedLinkedList_ThenResultIsReturnedInReversedLinkedList(SinglyLinkedList<int> list1, SinglyLinkedList<int> list2, SinglyLinkedList<int> expectedResult)
    {
        // Act
        var sum = GetNumberFromReversedLinkedList(list1) + GetNumberFromReversedLinkedList(list2);
        var sumStr = sum.ToString();
        SinglyLinkedList<int>? result = null;
        
        for (int i = sumStr.Length - 1; i >= 0; i--)
        {
            var str = int.Parse(sumStr[i].ToString());
            if (result == null)
            {
                result = new(str);
            }
            else
            {
                result.Append(str);
            }
        }

        // Assert
        Assert.Equal(expectedResult.ToFormattedString(), result?.ToFormattedString());
    }

    private static int GetNumberFromLinkedList(SinglyLinkedList<int> list)
    {
        var number = string.Empty;
        var node = list.Head;
        while (node != null)
        {
            number += node.Data;
            node = node.Next;
        }
        return int.Parse(number);
    }

    private static int GetNumberFromReversedLinkedList(SinglyLinkedList<int> list)
    {
        var number = string.Empty;
        var node = list.Head;
        while (node != null)
        {
            number = node.Data + number;
            node = node.Next;
        }
        return int.Parse(number);
    }
}
