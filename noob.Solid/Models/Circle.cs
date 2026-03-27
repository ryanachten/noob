namespace noob.Solid.Models;

public class Circle(int radius) : ITwoDimensionalShape
{
    public int Radius { get; } = radius;

    public double Area => Math.PI * Math.Pow(Radius, 2);
}
