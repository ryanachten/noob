namespace noob.Solid.Models;

public class Square : ITwoDimensionalShape
{
    public int Length { get; }

    public double Area => Math.Pow(Length, 2);

    public Square(int length)
    {
        Length = length;
    }
}
