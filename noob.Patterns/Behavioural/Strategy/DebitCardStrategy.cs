namespace noob.Patterns.Behavioural.Strategy;

/// <summary>
/// Concrete strategy.
/// A concrete strategy implementation, representing an algorithm 
/// </summary>
public class DebitCardStrategy(int balance) : IPaymentStrategy
{
    public int Balance { get; private set; } = balance;

    public void Pay(int amount)
    {
        Balance -= amount;
    }
}
