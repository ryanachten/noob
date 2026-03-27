namespace noob.Architecture.VerticalSlice.Features.Orders;

public record CreateOrderRequest(string CustomerName, decimal Amount);

public interface IOrderRepository
{
    void Save(Order order);
}

public class CreateOrderHandler
{
    private readonly IOrderRepository _repository;

    public CreateOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public Order Handle(CreateOrderRequest request)
    {
        var order = new Order 
        { 
            Id = new Random().Next(1, 1000),
            CustomerName = request.CustomerName, 
            Amount = request.Amount 
        };
        _repository.Save(order);
        return order;
    }
}
