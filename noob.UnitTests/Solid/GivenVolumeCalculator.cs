using noob.Solid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using LSP = noob.Solid.LiskovSubstitution;

namespace noob.UnitTests.Solid;

public class GivenVolumeCalculator
{
    public static IEnumerable<object[]> Shapes() =>
        new List<object[]>
        {
            new object[] {
                new IThreeDimensionalShape[] { new Sphere(3) }, 113,
            },
            new object[] {
                new IThreeDimensionalShape[] { new Cube(2) }, 8
            },
            new object[] {
                new IThreeDimensionalShape[] { new Sphere(3), new Cube(2) }, 121
            },
        };

    [Theory]
    [MemberData(nameof(Shapes))]
    public void WhenCalculatingVolumeBeforeRefactor_ThenVolumeIsCalculatedByShape(IThreeDimensionalShape[] shapes, double expectedResult)
    {
        // Act
        var results = new double[]{
            new LSP.VolumeCalculatorBefore(shapes).Sum().Total,
        };

        // Assert
        Assert.True(results.All(x => expectedResult == Math.Round(x)));
    }

    [Theory]
    [MemberData(nameof(Shapes))]
    public void WhenCalculatingVolumeAfterRefactor_ThenVolumeIsCalculatedByShape(IThreeDimensionalShape[] shapes, double expectedResult)
    {
        // Act
        var results = new double[]{
            new LSP.VolumeCalculatorAfter(shapes).Sum(),
        };

        // Assert
        Assert.True(results.All(x => expectedResult == Math.Round(x)));
    }
}
