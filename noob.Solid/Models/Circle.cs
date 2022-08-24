namespace noob.Solid.Models;

public class Circle : ITwoDimensionalShape
{
    public int Radius { get; }

    public double Area => Math.PI * Math.Pow(Radius, 2);

    public Circle(int radius)
    {
        Radius = radius;
    }
}
