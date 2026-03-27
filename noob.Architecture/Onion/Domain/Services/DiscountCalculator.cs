namespace noob.Architecture.Onion.Domain.Services;

using noob.Architecture.Onion.Domain.Entities;

public class DiscountCalculator
{
    public decimal Calculate(Order order)
    {
        return order.TotalAmount > 100 ? 0.1m : 0.0m;
    }
}
