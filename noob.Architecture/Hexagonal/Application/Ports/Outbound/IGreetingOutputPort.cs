namespace noob.Architecture.Hexagonal.Application.Ports.Outbound;

using noob.Architecture.Hexagonal.Domain;

public interface IGreetingOutputPort
{
    void Save(Greeting greeting);
}
