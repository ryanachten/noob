namespace noob.Architecture.Clean.UseCases;

using noob.Architecture.Clean.Entities;
using noob.Architecture.Clean.InterfaceAdapters.Gateways;

public interface IGreetingUseCase
{
    Greeting Handle(string name);
}

public class GreetingInteractor : IGreetingUseCase
{
    private readonly IGreetingGateway _gateway;

    public GreetingInteractor(IGreetingGateway gateway)
    {
        _gateway = gateway;
    }

    public Greeting Handle(string name)
    {
        var greeting = new Greeting { Message = $"Hello, {name} from Clean Architecture!" };
        _gateway.Save(greeting);
        return greeting;
    }
}
