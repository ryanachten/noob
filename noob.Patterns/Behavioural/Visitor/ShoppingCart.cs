/// <summary>
/// Client
/// </summary>
namespace noob.Patterns.Behavioural.Visitor;

public class ShoppingCart(List<IItemElement> items)
{
    private readonly ShoppingCartVisitor _visitor = new();

    public double GetTotal()
    {
        var total = 0.0;
        foreach (var item in items)
        {
            total += item.Accept(_visitor);
        }
        return total;
    }
}
