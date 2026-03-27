namespace noob.Architecture.Onion.Presentation.Controllers;

using noob.Architecture.Onion.Application.Services;
using noob.Architecture.Onion.Domain.Entities;

public class OrdersController(OrderAppService service)
{
    public Order Create(string customerName, decimal amount)
    {
        return service.Create(customerName, amount);
    }
}
