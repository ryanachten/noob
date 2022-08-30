namespace noob.Patterns.Structural.Adapter;

public class Employee
{
    public Guid Id { get; } = new();
    public string Name { get; }
    public string Role { get; }

    public Employee(string name, string role)
    {
        Name = name;
        Role = role;
    }
}
