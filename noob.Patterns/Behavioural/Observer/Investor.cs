namespace noob.Patterns.Behavioural.Observer;

/// <summary>
/// Concrete observer
/// </summary>
public class Investor : IInvestor
{
    public Dictionary<string, double> Investments = new();

    public Investor(List<Stock> stocks)
    {
        foreach (var stock in stocks)
        {
            Investments.Add(stock.Name, stock.Price);
        }
    }

    public void OnPriceChange(StockPriceChange priceChange)
    {
        if (Investments.ContainsKey(priceChange.Name))
        {
            Investments[priceChange.Name] = priceChange.Price;
        }
    }
}
