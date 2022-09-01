using noob.Patterns.Structural.Decorator;
using Xunit;

namespace noob.UnitTests.Patterns.Structural;

public class DecoratorTests
{
    [Fact]
    public void WhenConstructingCars_ThenCarsCanBeModifiedPerOrder()
    {
        var civic = new BasicCar("Toyota Civic");
        var ferrari = new SportsCar(new BasicCar("Ferrari"));
        var lincoln = new LimousineCar(new BasicCar("Lincoln")) { Seats = 10, Doors = 6 };
        var sportsLimo = new LimousineCar(new SportsCar(new BasicCar("SportsLimo3000"))) { Seats = 10 };

        Assert.Equal(4, civic.Doors);
        Assert.Equal(2, ferrari.Doors);
        Assert.Equal(6, lincoln.Doors);
        Assert.Equal(2, sportsLimo.Doors);
    }
}
