namespace noob.Patterns.Structural.Decorator;

/// <summary>
/// Concrete decorator.
/// Aadding properties specific to a limousine
/// </summary>
public class LimousineCar : CarDecorator
{
    public int Seats { get; set; }

    public LimousineCar(ICar car) : base(car)
    {
        Doors = car.Doors;
    }
}
