namespace noob.Architecture.Clean.Entities;

public class Order
{
    public int Id { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public DateTime CreatedAt { get; init; }
}
