namespace noob.Patterns.Behavioural.Visitor;

/// <summary>
/// ConcreteElement
/// </summary>
public class Book : IItemElement
{
    public Book(double price)
    {
        Price = price;
    }

    public double Price { get; }

    public double Accept(IShoppingCartVisitor visitor) => visitor.Visit(this);
}
