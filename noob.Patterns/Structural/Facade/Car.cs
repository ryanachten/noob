namespace noob.Patterns.Structural.Facade;

public class Car
{
    public Transmission? Transmission { get; init; }
    public Engine? Engine { get; init; }
    public Steering? Steering { get; init; }
}
