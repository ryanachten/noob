using noob.Models;
using noob.Models.LinkedList;
using System;
using Xunit;

namespace noob.UnitTests.Models.HashTable;

public class GivenInvalidHashTable
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(2)]
    [InlineData(4)]
    public void WhenInitialisingWithNonPrimeLength_ThenAnExceptionIsThrown(int length)
    {
        // Act
        var ex = Assert.Throws<ArgumentException>(() => new HashTable<string, int>(length));

        // Assert
        Assert.Equal("length is not a valid table length. Use a prime number.", ex.Message);
    }
}
