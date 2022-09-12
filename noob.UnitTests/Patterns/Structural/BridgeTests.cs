using noob.Patterns.Structural.Bridge;
using Xunit;

namespace noob.UnitTests.Patterns.Structural;

public class BridgeTests
{
    [Fact]
    public void WhenApplyingColourToShape_ThenTheirFillIsSet()
    {
        // Arrange
        var red = new Red();
        var green = new Green();
        var circle = new Circle(red);
        var square = new Square(green);

        // Act
        circle.ApplyColour();
        square.ApplyColour();

        // Assert
        Assert.Equal("Red", circle.Fill);
        Assert.Equal("Green", square.Fill);
    }
}
