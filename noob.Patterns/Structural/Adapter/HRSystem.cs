namespace noob.Patterns.Structural.Adapter;

/// <summary>
/// Adaptee class.
/// In this case, an HR system which isn't directly compatible with our billing system
/// </summary>
public class HRSystem
{
    private readonly List<Employee> _employees;

    public HRSystem()
    {
        _employees = new()
        {
            new("Jane", "CEO"),
            new("John", "COO"),
            new("Jenny", "CFO")
        };
    }

    public List<Employee> GetEmployees() => _employees;
}
