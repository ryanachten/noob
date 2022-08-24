using noob.Solid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using OCP = noob.Solid.OpenClosed;
using SRP = noob.Solid.SingleResponsibility;

namespace noob.UnitTests.Solid;

public class GivenAreaCalculator
{
    public static IEnumerable<object[]> Shapes() =>
        new List<object[]>
        {
            new object[] {
                new ITwoDimensionalShape[] { new Circle(3) }, 28,
            },
            new object[] {
                new ITwoDimensionalShape[] { new Square(2) }, 4
            },
            new object[] {
                new ITwoDimensionalShape[] { new Circle(3), new Square(2) }, 32
            },
        };

    [Theory]
    [MemberData(nameof(Shapes))]
    public void WhenCalculatingAreaBeforeRefactor_ThenAreaIsCalculatedByShape(ITwoDimensionalShape[] shapes, double expectedResult)
    {
        // Act
        var results = new double[]{
            new SRP.AreaCalculatorBefore(shapes).Sum(),
            new OCP.AreaCalculatorBefore(shapes).Sum()
        };

        // Assert
        Assert.True(results.All(x => expectedResult == Math.Round(x)));
    }

    [Theory]
    [MemberData(nameof(Shapes))]
    public void WhenCalculatingAreaAfterRefactor_ThenAreaIsCalculatedByShape(ITwoDimensionalShape[] shapes, double expectedResult)
    {
        // Act
        var results = new double[]{
            new SRP.AreaCalculatorAfter(shapes).Sum(),
            new OCP.AreaCalculatorAfter(shapes).Sum(),
        };

        // Assert
        Assert.True(results.All(x => expectedResult == Math.Round(x)));
    }
}
