namespace noob.Patterns.Structural.Decorator;

/// <summary>
/// Component interface.
/// Contains the members which will be implmented by both the concrete classes and the decorators
/// </summary>
public interface ICar
{
    string Model { get; set; }
    string Transmission { get; set; }
    int Doors { get; set; }

    ICar Assemble(string model);
}
