namespace noob.Architecture.Clean.InterfaceAdapters.Gateways;

using noob.Architecture.Clean.Entities;

public interface IOrderGateway
{
    void Save(Order order);
}
