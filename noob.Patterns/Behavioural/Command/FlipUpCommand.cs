namespace noob.Patterns.Behavioural.Command;

/// <summary>
/// Concrete command.
/// Invokes operations on the receiver.
/// </summary>
public class FlipUpCommand : ICommand
{
    private readonly Light _light;

    public FlipUpCommand(Light light)
    {
        _light = light;
    }

    public void Execute() => _light.TurnOn();
}
