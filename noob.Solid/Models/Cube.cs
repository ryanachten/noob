namespace noob.Solid.Models;

public class Cube : IThreeDimensionalShape
{
    public double Volume => Math.Pow(Length, 3);
    public int Length { get; }

    public Cube(int length)
    {
        Length = length;
    }
}
