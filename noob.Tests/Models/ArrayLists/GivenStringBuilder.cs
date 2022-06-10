using noob.Models;
using Xunit;

namespace noob.UnitTests.Models.ArrayLists;

public class GivenStringBuilder
{
    [Fact]
    public void WhenBuildingString_ThenStringIsReturned()
    {
        // Arrange
        var builder = new StringBuilder(100).Add('c').Add('a').Add('t');

        // Act
        var str = builder.ToString();

        // Assert
        Assert.Equal("cat", str);
    }
}
