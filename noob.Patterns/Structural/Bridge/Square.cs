namespace noob.Patterns.Structural.Bridge;

/// <summary>
/// Refined abstraction.
/// Extends the shape absraction.
/// </summary>
public class Square : Shape
{
    public Square(IColour colour) : base(colour)
    {
    }
}
