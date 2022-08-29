using noob.Patterns.Behavioural.Observer;
using Xunit;

namespace noob.UnitTests.Patterns.Behavioural;

public class ObserverTests
{
    [Fact]
    public void WhenStockPricesChange_ThenInvestorsAreNotified()
    {
        // Arrange
        var google = new Stock("Google", 100.0);
        var microsoft = new Stock("Microsoft", 90.0);
        var james = new Investor(new() { google });
        var jane = new Investor(new() { google, microsoft });
        google.Attach(james);
        google.Attach(jane);
        microsoft.Attach(jane);

        // Act
        google.UpdateStockPrice(120);
        microsoft.UpdateStockPrice(150);

        // Assert
        Assert.Equal(120, james.Investments["Google"]);
        Assert.Equal(120, jane.Investments["Google"]);
        Assert.Equal(150, jane.Investments["Microsoft"]);
    }
}
