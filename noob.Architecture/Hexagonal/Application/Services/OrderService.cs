namespace noob.Architecture.Hexagonal.Application.Services;

using noob.Architecture.Hexagonal.Application.Ports.Inbound;
using noob.Architecture.Hexagonal.Application.Ports.Outbound;
using noob.Architecture.Hexagonal.Domain;

public class OrderService(IOrderOutputPort outputPort) : ICreateOrderUseCase
{
    public Order Execute(string customerName, decimal amount)
    {
        var order = new Order(new Random().Next(1, 1000), customerName, amount, DateTime.UtcNow);
        outputPort.Save(order);
        return order;
    }
}
