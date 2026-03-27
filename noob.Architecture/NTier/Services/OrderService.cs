namespace noob.Architecture.NTier.Services;

using noob.Architecture.NTier.Models;
using noob.Architecture.NTier.Repositories;

public interface IOrderService
{
    Order CreateOrder(string customerName, decimal amount);
    Order? GetOrder(int id);
}

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public Order CreateOrder(string customerName, decimal amount)
    {
        if (amount < 0) throw new ArgumentException("Amount cannot be negative");

        var order = new Order
        {
            Id = new Random().Next(1, 1000),
            CustomerName = customerName,
            TotalAmount = amount,
            CreatedAt = DateTime.UtcNow
        };

        _repository.Add(order);
        return order;
    }

    public Order? GetOrder(int id) => _repository.GetById(id);
}
