namespace noob.Patterns.Behavioural.Mediator;

/// <summary>
/// Colleague abstract class holding a reference to the mediator (<see cref="_mediator"/>)
/// </summary>
public abstract class User(IChatMediator mediator, string name)
{
    protected readonly IChatMediator _mediator = mediator;
    protected readonly string _name = name;

    public abstract void Send(string message);

    public abstract void Receive(string message);
}
