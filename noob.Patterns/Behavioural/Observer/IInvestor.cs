namespace noob.Patterns.Behavioural.Observer;

/// <summary>
/// Observer interface
/// </summary>
public interface IInvestor
{
    void OnPriceChange(StockPriceChange priceChange);
}
