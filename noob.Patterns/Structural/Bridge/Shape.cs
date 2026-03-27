namespace noob.Patterns.Structural.Bridge;

/// <summary>
/// Abstraction.
/// Defines the base shape for concrete implementations.
/// </summary>
public abstract class Shape(IColour colour)
{
    protected IColour _colour = colour;
    public string? Fill { get; private set; }

    public void ApplyColour()
    {
        Fill = _colour.ApplyColour();
    }
}
