using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Algorithms.Searching.DFS;

public class GivenMatrixDfsTraversal
{
    public static readonly IEnumerable<object[]> Matrices = new List<object[]>
    {
        /// 1 2 3
        /// 4 5 6
        /// 7 8 9
        new object[] {
            new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
            new int[] { 1, 2, 3, 6, 9, 8, 5, 4, 7 }
        }
    };

    [Theory]
    [MemberData(nameof(Matrices))]
    public void WhenTaversingMatrix_ThenItemsAreReturnedDepthFirst(int[,] matrix, int[] expectedResult)
    {
        var result = DepthFirstSearch(matrix);
        Assert.Equivalent(expectedResult, result);
    }

    private static int[] DepthFirstSearch(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);
        var visited = new bool[rows, cols]; // can optimize this out by setting the value in matrix to Int32.MinValue
        var result = new List<int>(rows * cols);
        var stack = new Stack<(int, int)>();

        // Start at the top left corner
        stack.Push((0, 0));

        while (stack.Count > 0)
        {
            // pop the top coord
            var (row, col) = stack.Pop();

            // If the coord is outside of bounds, skip processing
            if (row < 0 || row >= rows || col < 0 || col >= cols) continue;

            // If the coord has already been marked as processed, skip
            if (visited[row, col]) continue;

            // Add the result and mark it as prcoessed
            result.Add(matrix[row, col]);
            visited[row, col] = true;

            // Add north, east, south, west cells
            stack.Push((row - 1, col)); // north
            stack.Push((row + 1, col)); // south
            stack.Push((row, col - 1)); // east
            stack.Push((row, col + 1)); // west
        }

        return result.ToArray();
    }
}
