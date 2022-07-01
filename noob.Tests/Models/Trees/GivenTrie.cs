using noob.Models.Trees;
using System;
using Xunit;

namespace noob.UnitTests.Models.Trees;

public class GivenTrie
{
    [Fact]
    public void WhenAddingSingleStringToTrie_ThenStringCanBeFound()
    {
        // Arrange
        var str = "hello";
        var trie = new TrieNode();

        // Act
        trie.Add(str);

        // Assert
        Assert.True(trie.Contains(str));
    }

    [Fact]
    public void WhenAddingMultipleStringsToTrie_ThenStringsCanBeFound()
    {
        // Arrange
        var str1 = "hello";
        var str2 = "hello";
        var trie = new TrieNode();

        // Act
        trie.Add(str1);
        trie.Add(str2);

        // Assert
        Assert.True(trie.Contains(str1));
        Assert.True(trie.Contains(str2));
    }

    [Theory]
    [InlineData("Hello", "H")]
    [InlineData("hello123", "1")]
    [InlineData("hello!!!!!", "!")]
    [InlineData("hello world", " ")]
    public void WhenAddingStringWithNonEnglishLetterToTrie_ThenExceptionIsThrown(string str, string expectedFirstInvalidChar)
    {
        // Arrange
        var trie = new TrieNode();

        // Assert
        var ex = Assert.Throws<ArgumentException>(() => trie.Add(str));
        Assert.Equal($"String contains a letter which is not a lowercase English letter '{expectedFirstInvalidChar}'", ex.Message);
    }

    [Theory]
    [InlineData("Hello")]
    [InlineData("hellooooo")]
    [InlineData("hell")]
    public void WhenFindingStringsThatDontExistInTrie_ThenFalseIsReturned(string str)
    {
        // Arrange
        var trie = new TrieNode();
        trie.Add("hello");

        // Act
        var result = trie.Contains(str);

        // Assert
        Assert.False(result);
    }
}
