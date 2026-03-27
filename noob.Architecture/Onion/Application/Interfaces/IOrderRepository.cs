namespace noob.Architecture.Onion.Application.Interfaces;

using noob.Architecture.Onion.Domain.Entities;

public interface IOrderRepository
{
    void Add(Order order);
}
