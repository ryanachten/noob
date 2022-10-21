using System;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class Matrix01
{
    public static IEnumerable<object[]> Matrices() => new List<object[]>
    {
        new object[] { new int[][] { new int[] { 0, 0, 0 },new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 } }},
        new object[] { new int[][] { new int[] { 0, 0, 0 },new int[] { 0, 1, 0 }, new int[] { 1, 1, 1 } }},

    };

    [Theory]
    [MemberData(nameof(Matrices))]
    public void WhenCalculatingDistances_ThenDistancesShouldBeCalculated(int[][] mat)
    {
        var res = UpdateMatrix(mat);
        Assert.NotNull(res);
    }

    public int[][] UpdateMatrix(int[][] mat)
    {
        var queue = new Queue<(int, int)>();

        // Find 0's and queue them, as well as set non-0's to max int val
        for (var row = 0; row < mat.Length; row++)
        {
            for (var col = 0; col < mat[row].Length; col++)
            {
                if (mat[row][col] == 0)
                {
                    queue.Enqueue((row, col));
                }
                else
                {
                    mat[row][col] = Int32.MaxValue;
                }
            }
        }

        while (queue.Count != 0)
        {
            var (row, col) = queue.Dequeue();
            var visitedCells = new HashSet<(int, int)>();
            SetMinDistancesToZero(mat, row, col, 1, visitedCells);
        }

        return mat;
    }

    private void SetMinDistancesToZero(int[][] mat, int row, int col, int dist, HashSet<(int, int)> visitedCells)
    {
        visitedCells.Add((row, col));

        // North
        if (row - 1 >= 0 && !visitedCells.Contains((row - 1, col)))
        {
            if (mat[row - 1][col] > dist)
            {
                mat[row - 1][col] = dist;
            }
            SetMinDistancesToZero(mat, row - 1, col, dist + 1, visitedCells);
        }

        // South
        if (row + 1 < mat.Length && !visitedCells.Contains((row + 1, col)))
        {
            if (mat[row + 1][col] > dist)
            {
                mat[row + 1][col] = dist;
            }
            SetMinDistancesToZero(mat, row + 1, col, dist + 1, visitedCells);
        }

        // West
        if (col - 1 >= 0 && !visitedCells.Contains((row, col - 1)))
        {
            if (mat[row][col - 1] > dist)
            {
                mat[row][col - 1] = dist;
            }
            SetMinDistancesToZero(mat, row, col - 1, dist + 1, visitedCells);
        }

        // East
        if (col + 1 < mat[row].Length && !visitedCells.Contains((row, col + 1)))
        {
            if (mat[row][col + 1] > dist)
            {
                mat[row][col + 1] = dist;
            }
            SetMinDistancesToZero(mat, row, col + 1, dist + 1, visitedCells);
        }
    }
}
