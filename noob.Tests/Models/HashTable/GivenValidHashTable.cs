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
        var table = new HashTable<int>();

        // Act
        table.Add(1).Add(2);

        // Assert
        Assert.Equal(2, table.Count);
    }

    [Fact]
    public void WhenRehashingTable_ThenTableHasCorrectCount()
    {
        // Arrange
        var table = new HashTable<int>();

        // Act
        var rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            table.Add(rand.Next(-1000, 1000));
        }

        // Assert
        Assert.Equal(100, table.Count);
    }
}
