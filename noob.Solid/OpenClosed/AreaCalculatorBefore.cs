using noob.Solid.Models;

namespace noob.Solid.OpenClosed;

/// <summary>
/// Objects or entities should be open for extension but closed for modification.
/// </summary>
public class AreaCalculatorBefore
{
    private readonly IEnumerable<ITwoDimensionalShape> _shapes;

    public AreaCalculatorBefore(IEnumerable<ITwoDimensionalShape> shapes)
    {
        _shapes = shapes;
    }

    /// <summary>
    /// This implementation violates the Open-Closed Principle
    /// because every time we need to add a new type of shape,
    /// we need to add another condition to this method to handle it.
    /// 
    /// Instead, we should move the area logic into the shape class it belongs to
    /// </summary>
    public double Sum()
    {
        double sum = 0;
        foreach (var shape in _shapes)
        {
            if (shape.GetType() == typeof(Circle))
            {
                var circle = (Circle)shape;
                sum += Math.PI * Math.Pow(circle.Radius, 2);
            }
            // Default to square
            else
            {
                var square = (Square)shape;
                sum += Math.Pow(square.Length, 2);
            }
        }

        return sum;
    }
}
