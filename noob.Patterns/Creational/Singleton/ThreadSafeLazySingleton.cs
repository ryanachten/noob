namespace noob.Patterns.Creational.Singleton;

/// <summary>
/// Singleton implementation with thread-safety through .NET's Lazy initialisation
/// </summary>
public class ThreadSafeLazySingleton : ISingleton
{
    /// <summary>
    /// We use .NET's lazy initialisation to support both lazy loading and thread safety
    /// </summary>
    private readonly static Lazy<ThreadSafeLazySingleton> _instance = new(() => new ThreadSafeLazySingleton());

    /// <summary>
    /// Constructor is private to avoid clients instantiating this class
    /// </summary>
    private ThreadSafeLazySingleton()
    {
        Value = new Random().Next(int.MaxValue);
    }

    public static ThreadSafeLazySingleton Instance => _instance.Value;

    public int Value { get; }
}