namespace noob.Patterns.Behavioural.Command;

/// <summary>
/// Concrete command.
/// Invokes operations on the receiver.
/// </summary>
public class FlipUpCommand(Light light) : ICommand
{
    public void Execute() => light.TurnOn();
}
