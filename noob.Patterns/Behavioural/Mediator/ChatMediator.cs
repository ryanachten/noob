namespace noob.Patterns.Behavioural.Mediator;

/// <summary>
/// Concrete implementation of the mediator
/// </summary>
public class ChatMediator : IChatMediator
{
    private readonly List<User> _users = new();

    public IChatMediator AddUser(User user)
    {
        _users.Add(user);
        return this;
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender) user.Receive(message);
        }
    }
}
