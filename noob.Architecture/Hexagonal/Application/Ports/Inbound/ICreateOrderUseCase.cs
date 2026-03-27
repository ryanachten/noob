namespace noob.Architecture.Hexagonal.Application.Ports.Inbound;

using noob.Architecture.Hexagonal.Domain;

public interface ICreateOrderUseCase
{
    Order Execute(string customerName, decimal amount);
}
