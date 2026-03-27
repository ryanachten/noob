namespace noob.Architecture.Onion.Presentation.Controllers;

using noob.Architecture.Onion.Application.Services;
using noob.Architecture.Onion.Domain.Entities;

public class OrdersController
{
    private readonly OrderAppService _service;

    public OrdersController(OrderAppService service)
    {
        _service = service;
    }

    public Order Create(string customerName, decimal amount)
    {
        return _service.Create(customerName, amount);
    }
}
