using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class KWeakestRowsInMatrix
{
    public static IEnumerable<object[]> Matrices() =>
        new object[][]{
            new object[]{
                new int[][] {
                    new int[] {1, 1, 0, 0, 0 },
                    new int[] {1, 1, 1, 1, 0},
                    new int[] {1, 0, 0, 0, 0},
                    new int[] {1, 1, 0, 0, 0},
                    new int[] {1, 1, 1, 1, 1 }
                },
                3,
                new[] { 2, 0, 3 },
            },
            new object[]{
                new int[][] {
                    new int[]{1,0,0,0 },
                    new int[]{1,1,1,1 },
                    new int[]{1, 0, 0, 0 },
                    new int[]{1,0,0,0 }
                },
                2,
                new[] { 0, 2 },
            },
            new object[]{
                new int[][] {
                    new int[] {1,1,0},
                    new int[] {1,1,0},
                    new int[] {1,1,1},
                    new int[] {1,1,1},
                    new int[] {0,0,0},
                    new int[] {1,1,1},
                    new int[] {1,0,0}
                },
                6,
                new[] {4,6,0,1,2,3},
            }
        };

    [Theory]
    [MemberData(nameof(Matrices))]
    public void WhenDeterminingWeakestRow_ThenRowsAreOrderedByByStrength(int[][] mat, int k, int[] expectedResult)
    {
        // Act
        var result = SpaceOptimizedKWeakestRows(mat, k);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    public int[] SpaceOptimizedKWeakestRows(int[][] mat, int k)
    {
        var totals = new List<KeyValuePair<int, int>>(); // list of KVPs with index and total
        for (var i = 0; i < mat.Length; i++)
        {
            totals.Add(new KeyValuePair<int, int>(i, mat[i].Sum()));
        }
        return totals.OrderBy(x => x.Value).Take(k).Select(x => x.Key).ToArray();
    }
}
