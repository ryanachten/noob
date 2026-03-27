namespace noob.Patterns.Structural.Facade;

// Complex subsytem
public class Transmission(Engine engine)
{

    /// <summary>
    /// Placeholder method representing a complex process
    /// </summary>
    public static Task<Transmission> Create(Engine engine)
    {
        return Task.FromResult(new Transmission(engine));
    }
}
