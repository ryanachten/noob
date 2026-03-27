namespace noob.Architecture.NTier.Repositories;

using noob.Architecture.NTier.Models;

public interface IOrderRepository
{
    Order? GetById(int id);
    void Add(Order order);
}

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Order? GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);

    public void Add(Order order) => _orders.Add(order);
}
