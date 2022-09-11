/// <summary>
/// Client
/// </summary>
namespace noob.Patterns.Behavioural.Visitor;

public class ShoppingCart
{
    private readonly List<IItemElement> _items;
    private readonly ShoppingCartVisitor _visitor = new();

    public ShoppingCart(List<IItemElement> items)
    {
        _items = items;
    }

    public double GetTotal()
    {
        var total = 0.0;
        foreach (var item in _items)
        {
            total += item.Accept(_visitor);
        }
        return total;
    }
}
