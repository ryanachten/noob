namespace noob.Patterns.Structural.Decorator;

/// <summary>
/// Concrete decorator.
/// Setting properties specific to a sports car
/// </summary>
public class SportsCar : CarDecorator
{
    public string Engine { get; set; } = "V8";

    public SportsCar(ICar car) : base(car)
    {
        car.Doors = 2;
    }
}
