namespace noob.Architecture.Hexagonal.Infrastructure.Adapters.Inbound;

using noob.Architecture.Hexagonal.Application.Ports.Inbound;
using noob.Architecture.Hexagonal.Domain;

public class OrderController
{
    private readonly ICreateOrderUseCase _createOrderUseCase;

    public OrderController(ICreateOrderUseCase createOrderUseCase)
    {
        _createOrderUseCase = createOrderUseCase;
    }

    public Order Create(string customerName, decimal amount)
    {
        return _createOrderUseCase.Execute(customerName, amount);
    }
}
