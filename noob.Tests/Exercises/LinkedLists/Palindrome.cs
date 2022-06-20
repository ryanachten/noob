using noob.Models.LinkedList;
using System;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LinkedLists;

/// <summary>
/// Implement a function to check if a linked list is a palindrome.
/// </summary>
public class Palindrome
{
    public static IEnumerable<object[]> Palindromes =>
        new List<object[]>
        {
                new object[] {
                    new SinglyLinkedList<char>('T').Append('o').Append('o').Append('t'),
                },
                new object[] {
                    new SinglyLinkedList<char>('T').Append('o').Append('u').Append('o').Append('t'),
                }
        };

    public static IEnumerable<object[]> NonPalindromes =>
        new List<object[]>
        {
                new object[] {
                    new SinglyLinkedList<char>('T').Append('o').Append('u').Append('t'),
                }
        };

    [Theory]
    [MemberData(nameof(Palindromes))]
    public void WhenPassedAPalindrome_ThenTrueIsReturned(SinglyLinkedList<char> list)
    {
        // Act
        var result = IsListPalindrome(list);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [MemberData(nameof(NonPalindromes))]
    public void WhenPassedANonPalindrome_ThenFalseIsReturned(SinglyLinkedList<char> list)
    {
        // Act
        var result = IsListPalindrome(list);

        // Assert
        Assert.False(result);
    }

    private static bool IsListPalindrome(SinglyLinkedList<char> list)
    {
        // Easy way:
        // - iterate through nodes forwards
        // - generate list of chars
        // - iterate through list of chars and see if it's the same backwards and forwards
        var node = list.Head;
        var word = string.Empty;
        while(node != null)
        {
            word += node.Data;
            node = node.Next;
        }
        word = word.ToLower();

        var result = true;
        var halfwayIndex = Math.Ceiling((double)word.Length / 2);
        for (int i = 0; i < halfwayIndex; i++)
        {
            var oppositeIndex = word[word.Length - 1 - i];
            if (word[i] != oppositeIndex)
            {
                result = false;
            }
        }

        return result;
    }
}
