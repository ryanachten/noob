namespace noob.Patterns.Behavioural.Observer;

/// <summary>
/// Subject abstract class
/// </summary>
public class Stock(string name, double price)
{
    public string Name = name;
    public double Price { get; private set; } = price;

    /// <summary>
    /// List of observers
    /// </summary>
    private readonly List<IInvestor> _investors = [];

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
