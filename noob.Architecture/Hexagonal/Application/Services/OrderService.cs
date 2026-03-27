namespace noob.Architecture.Hexagonal.Application.Services;

using noob.Architecture.Hexagonal.Application.Ports.Inbound;
using noob.Architecture.Hexagonal.Application.Ports.Outbound;
using noob.Architecture.Hexagonal.Domain;

public class OrderService : ICreateOrderUseCase
{
    private readonly IOrderOutputPort _outputPort;

    public OrderService(IOrderOutputPort outputPort)
    {
        _outputPort = outputPort;
    }

    public Order Execute(string customerName, decimal amount)
    {
        var order = new Order(new Random().Next(1, 1000), customerName, amount, DateTime.UtcNow);
        _outputPort.Save(order);
        return order;
    }
}
