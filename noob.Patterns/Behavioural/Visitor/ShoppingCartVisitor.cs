namespace noob.Patterns.Behavioural.Visitor;

/// <summary>
/// ConcreteVisitor 
/// </summary>
public class ShoppingCartVisitor : IShoppingCartVisitor
{
    public double Visit(Book book)
    {
        var price = book.Price;
        if (price > 50)
        {
            // apply discount
            price -= 5;
        }
        return price;
    }

    public double Visit(Fruit fruit) => fruit.PricePerKg * fruit.Weight;
}
