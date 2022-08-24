using noob.Solid.Models;

namespace noob.Solid.OpenClosed;

public class AreaCalculatorAfter
{
    public readonly IEnumerable<ITwoDimensionalShape> Shapes;

    public AreaCalculatorAfter(IEnumerable<ITwoDimensionalShape> shapes)
    {
        Shapes = shapes;
    }

    public double Sum()
    {
        double sum = 0;
        foreach (var shape in Shapes)
        {
            // Now that we've moved the area logic into the shape class it belongs to
            // we no longer need to add entries for each shape - fulfilling the OCP
            sum += shape.Area;
        }

        return sum;
    }
}