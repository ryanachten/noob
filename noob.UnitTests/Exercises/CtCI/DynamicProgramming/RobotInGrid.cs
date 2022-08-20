using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.CtCI.DynamicProgramming;

/// <summary>
/// Imagine a robot sitting on the upper left corner of grid with r rows and c columns.
/// The robot can only move in two directions, right and down, but certain cells are "off limits" such that
/// the robot cannot step on them.Design an algorithm to find a path for the robot from the top left to
/// the bottom right.
/// </summary>
public class RobotInGrid
{
    public static IEnumerable<object[]> Grids()
    {
        return new List<object[]>()
        {
            new object[]
            {
                1, 1,
                Array.Empty<(int, int)>(),
                new (int, int)[] { (0, 0) },
            },
            new object[]
            {
                1, 1,
                new (int, int)[] { (0, 0) },
                Array.Empty<(int, int)>(),
            },
            /// [0][1]
            /// [0][0]
            new object[]
            {
                2, 2,
                new (int, int)[] { (0, 1) },
                new (int, int)[] { (0, 0), (1, 0), (1, 1) },
            },
            /// [0][0]
            /// [1][0]
            new object[]
            {
                2, 2,
                new (int, int)[] { (1, 0) },
                new (int, int)[] { (0, 0), (0, 1), (1, 1) },
            },
            /// [0][1]
            /// [1][0]
            new object[]
            {
                2, 2,
                new (int, int)[] { (1, 0), (0, 1) },
                Array.Empty<(int, int)>(),

            },
            /// [0][0][0]
            /// [1][0][1]
            /// [1][0][0]
            new object[]
            {
                3, 3,
                new (int, int)[] { (1, 0), (1, 2), (2, 0) },
                new (int, int)[] { (0, 0), (0, 1), (1, 1), (2, 1), (2, 2) },
            }
        };
    }

    [Theory]
    [MemberData(nameof(Grids))]
    public void WhenNavigatingAGrid_ThenAPathCanBeDetermined(
        int rows, int colums, (int, int)[] offLimits, (int, int)[] expectedResult)
    {
        var result = PathFromGrid((0, 0), rows, colums, offLimits.ToHashSet(), new List<(int, int)>());
        Assert.Equivalent(expectedResult, result);
    }

    /// <summary>
    /// As we go through the grid, we look at possible moves: right or down
    /// if right contains a move which is valid, we add it to the list and progress
    /// if right is an off limit cell, we try moving down
    /// if down is also an  off limit cell, this path is blocked
    /// if cell is (n - 1, n - 1) then we have reached the end of the path
    /// </summary>
    private List<(int, int)> PathFromGrid(
        (int, int) location, int rows, int cols, HashSet<(int, int)> offLimits, List<(int, int)> path)
    {
        // Out of bounds
        if (location.Item1 > rows || location.Item2 > cols)
        {
            return new List<(int, int)>();
        }

        if (offLimits.Contains(location))
        {
            return new List<(int, int)>();
        }

        path.Add(location);

        var endCell = (rows - 1, cols - 1);
        if (location == endCell)
        {
            return path;
        }

        var rightPath = PathFromGrid((location.Item1, location.Item2 + 1), rows, cols, offLimits, path);
        if (rightPath.Any())
        {
            return rightPath;
        }

        var downPath = PathFromGrid((location.Item1 + 1, location.Item2), rows, cols, offLimits, path);
        return downPath;
    }
}
