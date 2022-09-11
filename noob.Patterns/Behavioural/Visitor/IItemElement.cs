namespace noob.Patterns.Behavioural.Visitor;

/// <summary>
/// Element interface
/// </summary>
public interface IItemElement
{
    public double Accept(IShoppingCartVisitor visitor);
}
