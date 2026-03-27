namespace noob.Patterns.Behavioural.Visitor;

/// <summary>
/// ConcreteElement
/// </summary>
public class Book(double price) : IItemElement
{
    public double Price { get; } = price;

    public double Accept(IShoppingCartVisitor visitor) => visitor.Visit(this);
}
