namespace noob.Patterns.Behavioural.Visitor;

/// <summary>
/// ConcreteElement
/// </summary>
public class Fruit(double weight, double pricePerKg) : IItemElement
{
    public double Weight { get; } = weight;
    public double PricePerKg { get; } = pricePerKg;

    public double Accept(IShoppingCartVisitor visitor) => visitor.Visit(this);
}
