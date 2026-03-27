namespace noob.Patterns.Structural.Decorator;

/// <summary>
/// Concrete implementation of the component interface (<see cref="ICar"/>).
/// This is base component which will be extended via decorators
/// </summary>
public class BasicCar(string model) : ICar
{
    public string Model { get; set; } = model;

    public string Transmission { get; set; } = "Automatic";

    public int Doors { get; set; } = 4;

    public ICar Assemble(string model)
    {
        return new BasicCar(model);
    }
}
