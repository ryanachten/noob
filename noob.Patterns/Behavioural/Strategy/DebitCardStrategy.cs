namespace noob.Patterns.Behavioural.Strategy;

/// <summary>
/// Concrete strategy.
/// A concrete strategy implementation, representing an algorithm 
/// </summary>
public class DebitCardStrategy : IPaymentStrategy
{
    public int Balance { get; private set; }

    public DebitCardStrategy(int balance)
    {
        Balance = balance;
    }

    public void Pay(int amount)
    {
        Balance -= amount;
    }
}
