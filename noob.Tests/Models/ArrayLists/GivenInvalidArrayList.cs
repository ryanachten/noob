using noob.Models;
using System;
using Xunit;

namespace noob.Tests.Models.ArrayLists;

public class GivenInvalidArrayList
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void WhenInitialisingWithInvalidLength_ThenExceptionIsThrown(int length)
    {
        // Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new ArrayList<int>(length));

        // Assert
        Assert.Equal(nameof(length), ex.ParamName);
    }
}
