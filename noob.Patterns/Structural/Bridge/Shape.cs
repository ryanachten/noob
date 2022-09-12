namespace noob.Patterns.Structural.Bridge;

/// <summary>
/// Abstraction.
/// Defines the base shape for concrete implementations.
/// </summary>
public abstract class Shape
{
    protected IColour _colour;
    public string? Fill { get; private set; }

    public Shape(IColour colour)
    {
        _colour = colour;
    }

    public void ApplyColour()
    {
        Fill = _colour.ApplyColour();
    }
}
