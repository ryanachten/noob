using noob.Patterns.Behavioural.Visitor;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Patterns.Behavioural;

public class VisitorTests
{
    [Fact]
    public void WhenCalculatingShoppingCartTotal_ThenTotalIsCorrectlyCalculated()
    {
        // Arrange
        var cart = new ShoppingCart(new List<IItemElement>()
        {
            new Book(55), // should be 50 w/ discount
            new Book(50),
            new Fruit(10, 1),
            new Fruit(10, 2),
        });

        // Act
        var total = cart.GetTotal();

        // Assert
        Assert.Equal(130, total);
    }
}
