namespace noob.Patterns.Behavioural.Observer;

/// <summary>
/// Subject abstract class
/// </summary>
public class Stock
{
    public string Name;
    public double Price { get; private set; }

    /// <summary>
    /// List of observers
    /// </summary>
    private readonly List<IInvestor> _investors = new();

    public Stock(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public void Attach(IInvestor investor) => _investors.Add(investor);
    public void Remove(IInvestor investor) => _investors.Remove(investor);

    /// <summary>
    /// Observer notification method
    /// </summary>
    public void UpdateStockPrice(double price)
    {
        Price = price;
        foreach (var investor in _investors)
        {
            investor.OnPriceChange(new StockPriceChange(Name, Price));
        }
    }
}
