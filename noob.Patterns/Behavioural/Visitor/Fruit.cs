namespace noob.Patterns.Behavioural.Visitor;

/// <summary>
/// ConcreteElement
/// </summary>
public class Fruit : IItemElement
{
    public double Weight { get; }
    public double PricePerKg { get; }

    public Fruit(double weight, double pricePerKg)
    {
        Weight = weight;
        PricePerKg = pricePerKg;
    }

    public double Accept(IShoppingCartVisitor visitor) => visitor.Visit(this);
}
