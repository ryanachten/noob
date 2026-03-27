namespace noob.Patterns.Behavioural.Command;

/// <summary>
/// Receiver.
/// Performs actions associated with the incoming request.
/// </summary>
public class Light(bool onByDefault = false)
{
    public bool IsOn { get; private set; } = onByDefault;
    public void TurnOn() => IsOn = true;
    public void TurnOff() => IsOn = false;
}
