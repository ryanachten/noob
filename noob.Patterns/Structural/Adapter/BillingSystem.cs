namespace noob.Patterns.Structural.Adapter;

/// <summary>
/// Client class.
/// In this case, a third-party billing system requiring a list of employees from our HR system.
/// </summary>
public class BillingSystem
{
    private readonly IHREmployeeTarget _employeeSource;
    public List<string> Employees { get; private set; } = new();

    public BillingSystem(IHREmployeeTarget employeeSource)
    {
        _employeeSource = employeeSource;
    }

    public void GetEmployees() => Employees = _employeeSource.GetEmployeeList().ToList();
}
