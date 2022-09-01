namespace noob.Patterns.Structural.Decorator;

/// <summary>
/// Decorator abstract class.
/// This defines what a decorator for a given component will look like
/// </summary>
public abstract class CarDecorator : ICar
{
    public string Model { get => _car.Model; set => _car.Model = value; }
    public string Transmission { get => _car.Transmission; set => _car.Transmission = value; }
    public int Doors { get => _car.Doors; set => _car.Doors = value; }

    private readonly ICar _car;

    public CarDecorator(ICar car)
    {
        _car = car;
    }

    public ICar Assemble(string model) => _car.Assemble(model);
}
