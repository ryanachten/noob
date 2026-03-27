namespace noob.Architecture.NTier.Controllers;

using noob.Architecture.NTier.Models;
using noob.Architecture.NTier.Services;

public class OrdersController
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public Order Post(string customerName, decimal amount)
    {
        return _orderService.CreateOrder(customerName, amount);
    }

    public Order? Get(int id)
    {
        return _orderService.GetOrder(id);
    }
}
