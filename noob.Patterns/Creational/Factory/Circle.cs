namespace noob.Patterns.Creational.Factory;

/// <summary>
/// Concrete product which implements product interface (<see cref="IShape"/>)
/// </summary>
public class Circle : IShape
{
    public int Radius { get; set; }

    public double Area => Math.PI * Math.Pow(Radius, 2);
}
