namespace noob.Architecture.Clean.Infrastructure.Persistence;

using noob.Architecture.Clean.Entities;
using noob.Architecture.Clean.InterfaceAdapters.Gateways;

public class InMemoryOrderGateway : IOrderGateway
{
    private readonly List<Order> _orders = new();

    public void Save(Order order)
    {
        _orders.Add(order);
    }
}
