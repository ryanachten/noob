namespace noob.Patterns.Creational.Singleton;

/// <summary>
/// Singleton implementation using Eager initialisation
/// </summary>
public class EagerSingleton : ISingleton
{
    private readonly static EagerSingleton _instance = new();

    /// <summary>
    /// Constructor is private to avoid clients instantiating this class
    /// </summary>
    private EagerSingleton()
    {
        Value = new Random().Next(int.MaxValue);
    }

    public static EagerSingleton Instance => _instance;

    public int Value { get; }
}
