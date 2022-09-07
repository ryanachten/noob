namespace noob.Patterns.Creational.Singleton;

/// <summary>
/// Singleton implementation with thread-safety through locking
/// </summary>
public class ThreadSafeLockingSingleton : ISingleton
{
    private static ThreadSafeLockingSingleton? _instance;
    private readonly static object _threadLock = new();

    /// <summary>
    /// Constructor is private to avoid clients instantiating this class
    /// </summary>
    private ThreadSafeLockingSingleton()
    {
        Value = new Random().Next(int.MaxValue);
    }

    /// <summary>
    /// Synchronises singleton access to a lazily created instance
    /// using a lock to ensure only one thread instantiates the singleton
    /// </summary>
    public static ThreadSafeLockingSingleton Instance
    {
        get
        {
            // We use two checks checks here because of the performance costs associated with synchronisation.
            // To avoid unncessary costs for each call, add an additional instance check.
            // This approach is known as the 'double-checked locking' pattern.
            if (_instance == null)
            {
                lock (_threadLock)
                {
                    if (_instance == null)
                    {
                        _instance = new();
                    }
                }
            }
            return _instance;
        }
    }

    public int Value { get; }
}