namespace noob.Patterns.Structural.Adapter;

/// <summary>
/// ITarget interface.
/// Used by the client to fulfil client requests
/// </summary>
public interface IHREmployeeTarget
{
    IEnumerable<string> GetEmployeeList();
}
