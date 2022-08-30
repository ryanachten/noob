namespace noob.Patterns.Structural.Adapter;

/// <summary>
/// Adapter class inherits from the adaptee, while implementing the target interface
/// </summary>
public class HREmployeeAdapter : HRSystem, IHREmployeeTarget
{
    /// <summary>
    /// Adapter method transforms adaptee contract into one the client can consume
    /// </summary>
    public IEnumerable<string> GetEmployeeList()
    {
        return GetEmployees().Select(e => e.Name);
    }
}
