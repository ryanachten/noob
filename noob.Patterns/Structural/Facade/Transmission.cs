namespace noob.Patterns.Structural.Facade;

// Complex subsytem
public class Transmission
{
    private readonly Engine _engine;

    public Transmission(Engine engine)
    {
        _engine = engine;
    }

    /// <summary>
    /// Placeholder method representing a complex process
    /// </summary>
    public static Task<Transmission> Create(Engine engine)
    {
        return Task.FromResult(new Transmission(engine));
    }
}
