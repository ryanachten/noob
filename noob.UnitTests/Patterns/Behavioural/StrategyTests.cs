using noob.Patterns.Behavioural.Strategy;
using Xunit;

namespace noob.UnitTests.Patterns.Behavioural;

public class StrategyTests
{
    [Fact]
    public void WhenPayingShoppingCart_ThenPaymentCanBeMadeFromDifferentSources()
    {
        // Arrange
        var debitCard = new DebitCardStrategy(1000);
        var creditCard = new CreditCardStrategy();
        var shoppingCart = new ShoppingCart();

        // Act
        shoppingCart.AddItem(new(100)).AddItem(new(50));
        shoppingCart.Pay(debitCard);

        shoppingCart.AddItem(new(200)).AddItem(new(150));
        shoppingCart.Pay(creditCard);

        // Assert
        Assert.Equal(850, debitCard.Balance);
        Assert.Equal(350, creditCard.Bill);
    }
}
