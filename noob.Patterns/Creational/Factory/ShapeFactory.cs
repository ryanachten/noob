namespace noob.Patterns.Creational.Factory;

/// <summary>
/// Class declaring the factory method
/// </summary>
public class ShapeFactory
{
    /// <summary>
    /// Factory method.
    /// Returns the appropriate concrete product based on the request parameters
    /// </summary>
    /// <returns>Concrete product</returns>
    public static IShape? GetShapeBySides(int numberOfSides)
    {
        return numberOfSides switch
        {
            0 => new Circle(),
            4 => new Square(),
            _ => null,
        };
    }
}
