using noob.Patterns.Creational.Builder;
using Xunit;

namespace noob.UnitTests.Patterns.Creational;

public class BuilderTests
{
    [Fact]
    public void WhenBuildingAHouse_ThenItHasTheCorrectValues()
    {
        var house = new HouseBuilder()
            .AddBedrooms(1)
            .AddBathrooms(2)
            .AddBedrooms(2)
            .Build();

        Assert.Equal(3, house.Bedrooms);
        Assert.Equal(2, house.Bathrooms);
        Assert.Equal(100, house.FloorSpace);
        Assert.Equal(210000, house.MarketValue);
    }
}
