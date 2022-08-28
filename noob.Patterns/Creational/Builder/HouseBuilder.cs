namespace noob.Patterns.Creational.Builder;

public class HouseBuilder
{
    private int _bedrooms;
    private int _bathrooms;
    private double _floorSpace;
    private double _marketValue;

    public HouseBuilder AddBedrooms(int number)
    {
        _bedrooms += number;
        _floorSpace += 20 * number;
        _marketValue += 50000 * number;

        return this;
    }
    public HouseBuilder AddBathrooms(int number)
    {
        _bathrooms += number;
        _floorSpace += 20 * number;
        _marketValue += 30000 * number;

        return this;
    }

    public House Build() => new()
    {
        Bathrooms = _bathrooms,
        Bedrooms = _bedrooms,
        FloorSpace = _floorSpace,
        MarketValue = _marketValue
    };
}
