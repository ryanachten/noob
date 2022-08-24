namespace noob.Solid.Models;

public class Sphere : IThreeDimensionalShape
{
    public int Radius { get; }
    public double Volume => (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);

    public Sphere(int radius)
    {
        Radius = radius;
    }
}
