using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class MaxAreaIsland
{
    public static IEnumerable<object[]> Grids() => new List<object[]>{
       new object[]
       {
           new int[][]
           {
                new int[]{ 0,0,1,0,0,0,0,1,0,0,0,0,0 },
                new int[]{0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new int[]{0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
                new int[]{0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0},
                new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0}
            },
           6
       },
       new object[]
       {
           new int[][]
           {
                new int[]{1,1,0,0,0 },
                new int[]{1,1,0,0,0 },
                new int[]{0,0,0,1,1 },
                new int[]{0,0,0,1,1 }
            },
           4
       }
    };

    [Theory]
    [MemberData(nameof(Grids))]
    public void WhenCalculatingMaxLandMass_ThenMaxLandMassIsReturned(int[][] grid, int expectedResult)
    {
        var result = MaxAreaOfIsland(grid);
        Assert.Equal(expectedResult, result);
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        var maxLandMass = 0;

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {

                // If the pixel is an island pixel and we haven't visited it yet 
                if (grid[row][col] == 1)
                {
                    var landMass = GetIslandLandMass((row, col), grid);
                    if (landMass > maxLandMass) maxLandMass = landMass;
                }
            }
        }
        return maxLandMass;
    }

    private static int GetIslandLandMass((int, int) start, int[][] grid)
    {
        var currentLandMass = 0;
        var queue = new Queue<(int, int)>();
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            var (row, col) = queue.Dequeue();

            // Increment land mass and store visited pixel
            currentLandMass++;
            grid[row][col] = 0;

            // Check if neighbouring pixels are part of island and add to queue
            if (row - 1 >= 0 && grid[row - 1][col] == 1)
            { // north
                queue.Enqueue((row - 1, col));
                grid[row - 1][col] = 0;
            }
            if (row + 1 < grid.Length && grid[row + 1][col] == 1)
            { // south
                queue.Enqueue((row + 1, col));
                grid[row + 1][col] = 0;
            }
            if (col - 1 >= 0 && grid[row][col - 1] == 1)
            { // west
                queue.Enqueue((row, col - 1));
                grid[row][col - 1] = 0;
            }
            if (col + 1 < grid[row].Length && grid[row][col + 1] == 1)
            { // east
                queue.Enqueue((row, col + 1));
                grid[row][col + 1] = 0;
            }
        }

        return currentLandMass;
    }
}
