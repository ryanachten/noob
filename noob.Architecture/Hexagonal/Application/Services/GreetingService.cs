namespace noob.Architecture.Hexagonal.Application.Services;

using noob.Architecture.Hexagonal.Application.Ports.Inbound;
using noob.Architecture.Hexagonal.Application.Ports.Outbound;
using noob.Architecture.Hexagonal.Domain;

public class GreetingService : IGreetUseCase
{
    private readonly IGreetingOutputPort _outputPort;

    public GreetingService(IGreetingOutputPort outputPort)
    {
        _outputPort = outputPort;
    }

    public Greeting Execute(string name)
    {
        var greeting = new Greeting($"Hello, {name} from Hexagonal Architecture!");
        _outputPort.Save(greeting);
        return greeting;
    }
}
