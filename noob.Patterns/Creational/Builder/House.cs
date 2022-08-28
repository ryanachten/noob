namespace noob.Patterns.Creational.Builder;

/// <summary>
/// Product produced by the builder
/// </summary>
public class House
{
    public int Bedrooms { get; init; }
    public int Bathrooms { get; init; }
    public double FloorSpace { get; init; }
    public double MarketValue { get; init; }
}
