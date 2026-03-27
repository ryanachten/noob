namespace noob.Architecture.Hexagonal.Application.Ports.Inbound;

using noob.Architecture.Hexagonal.Domain;

public interface IGreetUseCase
{
    Greeting Execute(string name);
}
