using noob.Models;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
/// column are set to 0.
/// </summary>
public class ZeroMatrix
{
    private readonly byte[][] _matrix = new byte[][] {
            new byte[] { 01, 02, 03, 04 },
            new byte[] { 05, 06, 00, 08 },
            new byte[] { 09, 10, 11, 12 },
            new byte[] { 13, 14, 15, 16 },
        };

    private readonly byte[][] _expectedResult = new byte[][] {
            new byte[] { 01, 02, 00, 04 },
            new byte[] { 00, 00, 00, 00 },
            new byte[] { 09, 10, 00, 12 },
            new byte[] { 13, 14, 00, 16 },
        };

    [Fact]
    public void WhenAZeroIsPresentInAMatrix_ThenItsColumnAndRowAreSetToZero()
    {
        // Arrange
        var yLength = _matrix.Length;
        var xLength = _matrix[0].Length;
        var zeroes = new ArrayList<KeyValuePair<int, int>>(1);

        // Act
        for (int y = 0; y < yLength; y++)
        {
            for (int x = 0; x < xLength; x++)
            {
                if (_matrix[y][x] == 0)
                {
                    zeroes.Add(new KeyValuePair<int, int>(y, x));
                }
            }
        }

        for (int i = 0; i < zeroes.Count; i++)
        {
            var zero = zeroes.Data[0];
            int x = 0;
            int y = 0;
            while (x < xLength)
            {
                _matrix[zero.Key][x] = 0;
                x++;
            }
            while (y < yLength)
            {
                _matrix[y][zero.Value] = 0;
                y++;
            }
        }

        // Assert
        Assert.Equal(_expectedResult, _matrix);
    }
}
