namespace noob.Architecture.Hexagonal.Infrastructure.Adapters.Outbound;

using noob.Architecture.Hexagonal.Application.Ports.Outbound;
using noob.Architecture.Hexagonal.Domain;

public class InMemoryOrderAdapter : IOrderOutputPort
{
    private readonly List<Order> _orders = [];

    public void Save(Order order)
    {
        _orders.Add(order);
    }
}
