namespace noob.Patterns.Structural.Adapter;

public class Employee(string name, string role)
{
    public Guid Id { get; } = new();
    public string Name { get; } = name;
    public string Role { get; } = role;
}
