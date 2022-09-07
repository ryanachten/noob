namespace noob.Patterns.Creational.Singleton;

/// <summary>
/// This interface isn't necessary as part of the Singleton pattern.
/// Used here to faciliate easy testing
/// </summary>
public interface ISingleton
{
    static ISingleton Instance { get; } = default!;
    int Value { get; }
}
