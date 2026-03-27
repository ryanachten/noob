namespace noob.Patterns.Structural.Facade;

// Complex subsytem
public class Steering(Engine engine)
{

    /// <summary>
    /// Placeholder method representing a complex process
    /// </summary>
    public static Task<Steering> Create(Engine engine)
    {
        return Task.FromResult(new Steering(engine));
    }
}
