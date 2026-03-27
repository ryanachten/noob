namespace noob.Solid.Models;

public class Sphere(int radius) : IThreeDimensionalShape
{
    public int Radius { get; } = radius;
    public double Volume => (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
}
