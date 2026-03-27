namespace noob.Solid.Models;

public class Square(int length) : ITwoDimensionalShape
{
    public int Length { get; } = length;

    public double Area => Math.Pow(Length, 2);
}
