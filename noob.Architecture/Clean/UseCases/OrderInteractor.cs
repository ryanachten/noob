namespace noob.Architecture.Clean.UseCases;

using noob.Architecture.Clean.Entities;
using noob.Architecture.Clean.InterfaceAdapters.Gateways;

public interface ICreateOrderUseCase
{
    Order Handle(string customerName, decimal amount);
}

public class OrderInteractor(IOrderGateway gateway) : ICreateOrderUseCase
{
    private readonly IOrderGateway _gateway = gateway;

    public Order Handle(string customerName, decimal amount)
    {
        var order = new Order
        {
            Id = new Random().Next(1, 1000),
            CustomerName = customerName,
            Amount = amount,
            CreatedAt = DateTime.UtcNow
        };
        _gateway.Save(order);
        return order;
    }
}
