namespace noob.Patterns.Behavioural.Mediator;

/// <summary>
/// Mediator interface
/// </summary>
public interface IChatMediator
{
    void SendMessage(string message, User user);
    IChatMediator AddUser(User user);
}
