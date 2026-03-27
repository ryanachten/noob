namespace noob.Patterns.Structural.Bridge;

/// <summary>
/// Refined abstraction.
/// Extends the shape absraction.
/// </summary>
public class Circle(IColour colour) : Shape(colour)
{
}
