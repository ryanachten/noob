namespace noob.Patterns.Creational.Factory;

/// <summary>
/// Concrete product which implements product interface (<see cref="IShape"/>)
/// </summary>
public class Square : IShape
{
    public int Length { get; set; }

    public double Area => Math.Pow(Length, 2);
}
