using Microsoft.Extensions.Logging;
using noob.Solid.Models;

namespace noob.Solid.SingleResponsibility;

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
            sum += shape.Area;
        }

        return sum;
    }
}

/// <summary>
/// Instead of having output logic inside of the calculator class,
/// a better approach is to create a dedicated class to house this behaviour
/// </summary>
public class AreaSumOutput
{
    private readonly AreaCalculatorAfter _calculator;
    private readonly ILogger<AreaSumOutput> _logger;

    public AreaSumOutput(ILogger<AreaSumOutput> logger, AreaCalculatorAfter calculator)
    {
        _calculator = calculator;
        _logger = logger;
    }

    public void Log()
    {
        _logger.LogInformation("Sum of {count} shapes: {sum}", _calculator.Shapes.Count(), _calculator.Sum());
    }

    public string Json() => _calculator.Sum().ToString();

    // Other output targets can be added here, like HTML, CSV etc
}
