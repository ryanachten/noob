namespace noob.Patterns.Structural.Bridge;

/// <summary>
/// Refined abstraction.
/// Extends the shape absraction.
/// </summary>
public class Circle : Shape
{
    public Circle(IColour colour) : base(colour)
    {
    }
}
