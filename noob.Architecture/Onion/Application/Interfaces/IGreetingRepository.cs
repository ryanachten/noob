namespace noob.Architecture.Onion.Application.Interfaces;

using noob.Architecture.Onion.Domain.Entities;

public interface IGreetingRepository
{
    void Add(Greeting greeting);
}
