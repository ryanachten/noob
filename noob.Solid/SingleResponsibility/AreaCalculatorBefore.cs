using noob.Solid.Models;

namespace noob.Solid.SingleResponsibility;

/// <summary>
/// A class should have only one reason to change, meaning that a class should have only one job.
/// </summary>
public class AreaCalculatorBefore
{
    private readonly IEnumerable<ITwoDimensionalShape> _shapes;

    public AreaCalculatorBefore(IEnumerable<ITwoDimensionalShape> shapes)
    {
        _shapes = shapes;
    }

    public double Sum()
    {
        double sum = 0;
        foreach (var shape in _shapes)
        {
            sum += shape.Area;
        }

        return sum;
    }

    /// <summary>
    /// Output violates the Single Responsibility Principle.
    /// The AreaCalculator class should only handle calculation logic
    /// The output method also doesn't scale very well - what if output formatting differs based on target?
    /// </summary>
    /// <returns></returns>
    public string Output() => $"Sum of {_shapes.Count()} shapes: {Sum()}";
}
