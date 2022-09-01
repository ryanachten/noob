namespace noob.Patterns.Behavioural.Strategy;

/// <summary>
/// Strategy interface.
/// Defines the contract shared by different alogrithms
/// </summary>
public interface IPaymentStrategy
{
    void Pay(int amount);
}
