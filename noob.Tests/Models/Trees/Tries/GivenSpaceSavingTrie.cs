using noob.Models.Trees.Tries;
using Xunit;

namespace noob.UnitTests.Models.Trees.Tries;

public class GivenSpaceSavingTrie
{
    [Fact]
    public void WhenAddingSingleStringToTrie_ThenStringCanBeFound()
    {
        // Arrange
        var str = "hello";
        var trie = new Trie();

        // Act
        trie.Add(str);

        // Assert
        Assert.True(trie.Contains(str));
    }

    [Fact]
    public void WhenAddingMultipleStringsToTrie_ThenStringsCanBeFound()
    {
        // Arrange
        var str1 = "help";
        var str2 = "helping";
        var str3 = "helped";
        var str4 = "helper";

        var trie = new Trie();

        // Act
        trie.Add(str1);
        trie.Add(str2);
        trie.Add(str3);
        trie.Add(str4);

        // Assert
        Assert.True(trie.Contains(str1));
        Assert.True(trie.Contains(str2));
        Assert.True(trie.Contains(str3));
        Assert.True(trie.Contains(str4));
    }

    [Theory]
    [InlineData("Hello", "H")]
    [InlineData("hello123", "1")]
    [InlineData("hello!!!!!", "!")]
    [InlineData("hello world", " ")]
    public void WhenAddingStringWithNonEnglishLetterToTrie_ThenExceptionIsThrown(string str, string expectedFirstInvalidChar)
    {
        // Arrange
        var trie = new Trie();

        // Assert
        var ex = Assert.Throws<InvalidCharacterException>(() => trie.Add(str));
        Assert.Equal($"String contains a letter which is not a lowercase English letter '{expectedFirstInvalidChar}'", ex.Message);
    }

    [Theory]
    [InlineData("Hello")]
    [InlineData("hellooooo")]
    [InlineData("hell")]
    public void WhenFindingStringsThatDontExistInTrie_ThenFalseIsReturned(string str)
    {
        // Arrange
        var trie = new Trie();
        trie.Add("hello");

        // Act
        var result = trie.Contains(str);

        // Assert
        Assert.False(result);
    }
}
