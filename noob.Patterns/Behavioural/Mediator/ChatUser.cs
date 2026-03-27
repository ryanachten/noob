namespace noob.Patterns.Behavioural.Mediator;

public class ChatUser(IChatMediator mediator, string name) : User(mediator, name)
{
    public readonly List<string> Messages = [];

    public override void Receive(string message)
    {
        Messages.Add(message);
    }

    public override void Send(string message)
        => _mediator.SendMessage($"{_name} sends: {message}", this);
}
