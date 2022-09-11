namespace noob.Patterns.Behavioural.Visitor;

/// <summary>
/// Visitor interface
/// </summary>
public interface IShoppingCartVisitor
{
    public double Visit(Book book);
    public double Visit(Fruit fruit);
}
