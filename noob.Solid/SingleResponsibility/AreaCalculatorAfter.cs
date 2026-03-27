using Microsoft.Extensions.Logging;
using noob.Solid.Models;

namespace noob.Solid.SingleResponsibility;

public class AreaCalculatorAfter(IEnumerable<ITwoDimensionalShape> shapes)
{
    public readonly IEnumerable<ITwoDimensionalShape> Shapes = shapes;

    public double Sum()
    {
        double sum = 0;
        foreach (var shape in Shapes)
        {
            sum += shape.Area;
        }

        return sum;
    }
}

/// <summary>
/// Instead of having output logic inside of the calculator class,
/// a better approach is to create a dedicated class to house this behaviour
/// </summary>
public class AreaSumOutput(ILogger<AreaSumOutput> logger, AreaCalculatorAfter calculator)
{
    public void Log()
    {
        logger.LogInformation("Sum of {count} shapes: {sum}", calculator.Shapes.Count(), calculator.Sum());
    }

    public string Json() => calculator.Sum().ToString();

    // Other output targets can be added here, like HTML, CSV etc
}
