namespace noob.Architecture.VerticalSlice.Features.Greetings;

// In Vertical Slice, we often keep the request, response, handler, and persistence interface in one file
// or one folder for that specific feature.

public record SayHelloRequest(string Name);

public interface IGreetingRepository
{
    void Save(Greeting greeting);
}

public class SayHelloHandler
{
    private readonly IGreetingRepository _repository;

    public SayHelloHandler(IGreetingRepository repository)
    {
        _repository = repository;
    }

    public Greeting Handle(SayHelloRequest request)
    {
        var greeting = new Greeting { Message = $"Hello, {request.Name} from Vertical Slice Architecture!" };
        _repository.Save(greeting);
        return greeting;
    }
}
