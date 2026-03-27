namespace noob.Solid.Models;

public class Cube(int length) : IThreeDimensionalShape
{
    public double Volume => Math.Pow(Length, 3);
    public int Length { get; } = length;
}
