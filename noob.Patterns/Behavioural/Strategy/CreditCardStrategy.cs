namespace noob.Patterns.Behavioural.Strategy;

/// <summary>
/// Concrete strategy.
/// A concrete strategy implementation, representing an algorithm 
/// </summary>
public class CreditCardStrategy : IPaymentStrategy
{
    public int Bill { get; private set; } = 0;

    public void Pay(int amount)
    {
        Bill += amount;
    }
}
