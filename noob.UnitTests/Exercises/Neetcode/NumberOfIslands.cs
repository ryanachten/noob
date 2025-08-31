using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.NeetCode;

public class NumberOfIslands
{
    public static TheoryData<char[][], int> Islands() => new()
    {
        {
            [
                ['0','1','1','1','0'],
                ['0','1','0','1','0'],
                ['1','1','0','0','0'],
                ['0','0','0','0','0']
            ], 1
        },
        {
            [
                ['1','1','0','0','1'],
                ['1','1','0','0','1'],
                ['0','0','1','0','0'],
                ['0','0','0','1','1']
            ],
            4
        }
    };

    [Theory]
    [MemberData(nameof(Islands))]
    public void GivenGrid_WhenFindingNumberOfIslands_ThenTheCorrectNumberIsReturned(char[][] grid, int expected)
    {
        var result = NumIslands(grid);
        Assert.Equal(expected, result);
    }

    private readonly Stack<(int, int)> _stack = new();

    public int NumIslands(char[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var islands = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row][col] == '1')
                {
                    Dfs(row, col, rows, cols, grid);
                    islands++;
                }
            }
        }

        return islands;
    }

    private void Dfs(int row, int col, int rows, int cols, char[][] grid)
    {
        _stack.Push((row, col));

        while (_stack.Count > 0)
        {
            var (x, y) = _stack.Pop();

            // Check we're in bounds
            if (x < 0 || y < 0 || x >= rows || y >= cols) continue;

            if (grid[x][y] != '1') continue;

            _stack.Push((x - 1, y)); // East
            _stack.Push((x + 1, y)); // West
            _stack.Push((x, y - 1)); // North
            _stack.Push((x, y + 1)); // South

            grid[x][y] = '0'; // mark the cell as read to avoid reprocessing
        }
    }
}