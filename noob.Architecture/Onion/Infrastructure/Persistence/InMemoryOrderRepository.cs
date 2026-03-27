namespace noob.Architecture.Onion.Infrastructure.Persistence;

using noob.Architecture.Onion.Domain.Entities;
using noob.Architecture.Onion.Application.Interfaces;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];

    public void Add(Order order)
    {
        _orders.Add(order);
    }
}
