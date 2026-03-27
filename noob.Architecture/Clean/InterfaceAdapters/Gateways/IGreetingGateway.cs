namespace noob.Architecture.Clean.InterfaceAdapters.Gateways;

using noob.Architecture.Clean.Entities;

public interface IGreetingGateway
{
    void Save(Greeting greeting);
}
