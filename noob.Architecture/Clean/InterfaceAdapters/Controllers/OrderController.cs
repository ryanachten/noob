namespace noob.Architecture.Clean.InterfaceAdapters.Controllers;

using noob.Architecture.Clean.UseCases;
using noob.Architecture.Clean.Entities;

public class OrderController(ICreateOrderUseCase useCase)
{
    private readonly ICreateOrderUseCase _useCase = useCase;

    public Order Create(string customerName, decimal amount)
    {
        return _useCase.Handle(customerName, amount);
    }
}
