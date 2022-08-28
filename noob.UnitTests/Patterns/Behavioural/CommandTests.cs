using noob.Patterns.Behavioural.Command;
using Xunit;

namespace noob.UnitTests.Patterns.Behavioural;

public class CommandTests
{
    [Fact]
    public void WhenFlippingSwitchUp_ThenLightIsTurnedOn()
    {
        // Arrange
        var receiver = new Light();
        var command = new FlipUpCommand(receiver);
        var invoker = new Switch();

        // Act
        invoker.Execute(command);

        // Assert
        Assert.True(receiver.IsOn);
    }

    [Fact]
    public void WhenFlippingSwitchDown_ThenLightIsTurnedOff()
    {
        // Arrange
        var receiver = new Light(true);
        var command = new FlipDownCommand(receiver);
        var invoker = new Switch();

        // Act
        invoker.Execute(command);

        // Assert
        Assert.False(receiver.IsOn);
    }
}
