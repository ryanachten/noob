namespace noob.Architecture.Hexagonal.Application.Ports.Outbound;

using noob.Architecture.Hexagonal.Domain;

public interface IOrderOutputPort
{
    void Save(Order order);
}
