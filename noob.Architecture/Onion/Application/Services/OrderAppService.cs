namespace noob.Architecture.Onion.Application.Services;

using noob.Architecture.Onion.Application.Interfaces;
using noob.Architecture.Onion.Domain.Entities;

public class OrderAppService(IOrderRepository repository)
{
    public Order Create(string customerName, decimal amount)
    {
        var order = new Order
        {
            Id = new Random().Next(1, 1000),
            CustomerName = customerName,
            TotalAmount = amount,
            CreatedAt = DateTime.UtcNow
        };
        repository.Add(order);
        return order;
    }
}
