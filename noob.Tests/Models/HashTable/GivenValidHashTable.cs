using noob.Models;
using System;
using Xunit;

namespace noob.UnitTests.Models.HashTable;

public class GivenValidHashTable
{
    [Fact]
    public void WhenAddingToTheTable_ThenTableHasCorrectCount()
    {
        // Arrange
        var table = new HashTable<string, int>();

        // Act
        table.Add("hello", 1).Add("world", 2);

        // Assert
        Assert.Equal(2, table.Count);
    }

    [Fact]
    public void WhenAddingExistingKeyToTheTable_ThenTheValueIsUpdated()
    {
        // Arrange
        var table = new HashTable<string, int>();

        // Act
        table.Add("hello", 1).Add("hello", 2).Add("hello", 3);

        // Assert
        Assert.Equal(1, table.Count);

        var value = table.GetValue("hello");
        Assert.Equal(3, value);
    }

    [Fact]
    public void WhenRehashingTable_ThenTableHasCorrectCount()
    {
        // Arrange
        var table = new HashTable<string, int>();

        // Act
        var rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            table.Add(i.ToString(), rand.Next(-1000, 1000));
        }

        // Assert
        Assert.Equal(100, table.Count);
    }

    [Theory]
    [InlineData("new1", 1)]
    [InlineData("new2", -1)]
    [InlineData("new3", 10000000)]

    public void WhenGettingValuesBasedOnKey_ThenTheCorrectValueIsReturned(string key, int value)
    {
        // Arrange
        var table = new HashTable<string, int>(5);
        table.Add("hello", 1).Add("world", 2).Add("test", 3).Add(key, value);

        // Act
        var actualValue = table.GetValue(key);

        // Assert
        Assert.Equal(4, table.Count);
        Assert.Equal(value, actualValue);
    }

    [Theory]
    [InlineData("new1", 1)]
    [InlineData("new2", -1)]
    [InlineData("new3", 10000000)]

    public void WhenGettingValuesAfterRehashing_ThenTheCorrectValueIsReturned(string key, int value)
    {
        // Arrange
        var table = new HashTable<string, int>();
        table.Add("hello", 1).Add("world", 2).Add("test", 3).Add(key, value);

        // Act
        var actualValue = table.GetValue(key);

        // Assert
        Assert.Equal(4, table.Count);
        Assert.Equal(value, actualValue);
    }
}
