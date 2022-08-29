namespace noob.Patterns.Behavioural.Observer;

public class StockPriceChange
{
    public readonly string Name;
    public readonly double Price;
    public StockPriceChange(string name, double price)
    {
        Name = name;
        Price = price;
    }
}
