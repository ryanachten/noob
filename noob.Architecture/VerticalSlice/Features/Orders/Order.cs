namespace noob.Architecture.VerticalSlice.Features.Orders;

public class Order
{
    public int Id { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public decimal Amount { get; init; }
}
