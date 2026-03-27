namespace noob.Patterns.Structural.Decorator;

/// <summary>
/// Decorator abstract class.
/// This defines what a decorator for a given component will look like
/// </summary>
public abstract class CarDecorator(ICar car) : ICar
{
    public string Model { get => car.Model; set => car.Model = value; }
    public string Transmission { get => car.Transmission; set => car.Transmission = value; }
    public int Doors { get => car.Doors; set => car.Doors = value; }

    public ICar Assemble(string model) => car.Assemble(model);
}
