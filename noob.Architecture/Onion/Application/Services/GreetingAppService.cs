namespace noob.Architecture.Onion.Application.Services;

using noob.Architecture.Onion.Application.Interfaces;
using noob.Architecture.Onion.Domain.Entities;

public class GreetingAppService
{
    private readonly IGreetingRepository _repository;

    public GreetingAppService(IGreetingRepository repository)
    {
        _repository = repository;
    }

    public Greeting SayHello(string name)
    {
        var greeting = new Greeting { Message = $"Hello, {name} from Onion Architecture!" };
        _repository.Add(greeting);
        return greeting;
    }
}
