using noob.Patterns.Structural.Facade;
using Xunit;

namespace noob.UnitTests.Patterns.Structural;

public class FacadeTests
{
    [Fact]
    public async void WhenCreatingCar_ThenCarComponentsAreCreatedProperly()
    {
        var car = await CarFacade.CreateCar();

        Assert.NotNull(car);
        Assert.NotNull(car.Engine);
        Assert.NotNull(car.Transmission);
        Assert.NotNull(car.Steering);
    }
}
