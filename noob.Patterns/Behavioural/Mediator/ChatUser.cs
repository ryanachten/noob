namespace noob.Patterns.Behavioural.Mediator;

public class ChatUser : User
{
    public readonly List<string> Messages = new();

    public ChatUser(IChatMediator mediator, string name) : base(mediator, name)
    {
    }

    public override void Receive(string message)
    {
        Messages.Add(message);
    }

    public override void Send(string message)
        => _mediator.SendMessage($"{_name} sends: {message}", this);
}
