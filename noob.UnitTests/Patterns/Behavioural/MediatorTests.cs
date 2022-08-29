using noob.Patterns.Behavioural.Mediator;
using Xunit;

namespace noob.UnitTests.Patterns.Behavioural;

public class MediatorTests
{
    [Fact]
    public void WhenSendingMessages_ThenUsersApartFromTheSenderReceiveThem()
    {
        // Arrange
        var mediator = new ChatMediator();
        var user1 = new ChatUser(mediator, "User 1");
        var user2 = new ChatUser(mediator, "User 2");
        var user3 = new ChatUser(mediator, "User 3");

        // Act
        mediator.AddUser(user1).AddUser(user2).AddUser(user3);
        user1.Send("Hello");
        user2.Send("Hi");

        // Assert
        Assert.Single(user1.Messages);
        Assert.Single(user2.Messages);
        Assert.Equal(2, user3.Messages.Count);
    }
}
