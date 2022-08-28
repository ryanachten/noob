namespace noob.Patterns.Behavioural.Command;

/// <summary>
/// Concrete command.
/// Invokes operations on the reciver.
/// </summary>
public class FlipDownCommand : ICommand
{
    private readonly Light _light;

    public FlipDownCommand(Light light)
    {
        _light = light;
    }

    public void Execute() => _light.TurnOff();
}
