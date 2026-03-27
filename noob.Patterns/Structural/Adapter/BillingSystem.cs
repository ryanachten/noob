namespace noob.Patterns.Structural.Adapter;

/// <summary>
/// Client class.
/// In this case, a third-party billing system requiring a list of employees from our HR system.
/// </summary>
public class BillingSystem(IHREmployeeTarget employeeSource)
{
    public List<string> Employees { get; private set; } = [];

    public void GetEmployees() => Employees = employeeSource.GetEmployeeList().ToList();
}
