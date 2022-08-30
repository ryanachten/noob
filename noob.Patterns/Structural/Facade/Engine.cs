namespace noob.Patterns.Structural.Facade;

// Complex subsytem
public class Engine
{
    /// <summary>
    /// Placeholder method representing a complex process
    /// </summary>
    public static Task<Engine> Create()
    {
        return Task.FromResult(new Engine());
    }
}
