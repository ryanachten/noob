namespace noob.Patterns.Creational.Singleton;

/// <summary>
/// Singleton implementation using Lazy initialisation
/// </summary>
public class LazySingleton : ISingleton
{
    private static LazySingleton? _instance;

    /// <summary>
    /// Constructor is private to avoid clients instantiating this class
    /// </summary>
    private LazySingleton()
    {
        Value = new Random().Next(int.MaxValue);
    }

    /// <summary>
    /// Creates instance if it doesn't exist and then returns instance
    /// </summary>
    public static LazySingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }
    }

    public int Value { get; }
}