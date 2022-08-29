namespace noob.Patterns.Behavioural.Mediator;

/// <summary>
/// Colleague abstract class holding a reference to the mediator (<see cref="_mediator"/>)
/// </summary>
public abstract class User
{
    protected readonly IChatMediator _mediator;
    protected readonly string _name;

    public User(IChatMediator mediator, string name)
    {
        _mediator = mediator;
        _name = name;
    }

    public abstract void Send(string message);

    public abstract void Receive(string message);
}
