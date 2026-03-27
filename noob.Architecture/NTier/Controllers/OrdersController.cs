namespace noob.Architecture.NTier.Controllers;

using noob.Architecture.NTier.Models;
using noob.Architecture.NTier.Services;

public class OrdersController(IOrderService orderService)
{
    public Order Post(string customerName, decimal amount)
    {
        return orderService.CreateOrder(customerName, amount);
    }

    public Order? Get(int id)
    {
        return orderService.GetOrder(id);
    }
}
