namespace noob.Patterns.Behavioural.Strategy;

public class Item
{
    public Item(int cost)
    {
        Cost = cost;
    }

    public int Cost { get; }
}

public class ShoppingCart
{
    private readonly List<Item> _items = new();

    public ShoppingCart AddItem(Item item)
    {
        _items.Add(item);
        return this;
    }

    public void Pay(IPaymentStrategy paymentStrategy)
    {
        var total = _items.Sum(x => x.Cost);
        paymentStrategy.Pay(total);

        _items.Clear();
    }
}
