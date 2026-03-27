namespace noob.Architecture.Onion.Application.Services;

using noob.Architecture.Onion.Application.Interfaces;
using noob.Architecture.Onion.Domain.Entities;

public class OrderAppService
{
    private readonly IOrderRepository _repository;

    public OrderAppService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public Order Create(string customerName, decimal amount)
    {
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
}
