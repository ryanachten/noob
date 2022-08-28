namespace noob.Patterns.Behavioural.Command;

/// <summary>
/// Receiver.
/// Performs actions associated with the incoming request.
/// </summary>
public class Light
{
    public Light(bool onByDefault = false)
    {
        IsOn = onByDefault;
    }

    public bool IsOn { get; private set; }
    public void TurnOn() => IsOn = true;
    public void TurnOff() => IsOn = false;
}
