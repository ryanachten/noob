using noob.Patterns.Creational.Factory;
using System;
using Xunit;

namespace noob.UnitTests.Patterns.Creational;

public class FactoryTests
{
    [Theory]
    [InlineData(0, typeof(Circle))]
    [InlineData(4, typeof(Square))]
    [InlineData(10, null)]
    public void WhenGettingShapeFromSides_ThenCorrectShapeIsReturned(int numberOfSides, Type? shapeType)
    {
        var shape = ShapeFactory.GetShapeBySides(numberOfSides);
        Assert.Equal(shapeType, shape?.GetType());
    }
}
