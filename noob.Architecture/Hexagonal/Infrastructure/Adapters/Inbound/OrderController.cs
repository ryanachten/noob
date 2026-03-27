namespace noob.Architecture.Hexagonal.Infrastructure.Adapters.Inbound;

using noob.Architecture.Hexagonal.Application.Ports.Inbound;
using noob.Architecture.Hexagonal.Domain;

public class OrderController(ICreateOrderUseCase createOrderUseCase)
{
    public Order Create(string customerName, decimal amount)
    {
        return createOrderUseCase.Execute(customerName, amount);
    }
}
