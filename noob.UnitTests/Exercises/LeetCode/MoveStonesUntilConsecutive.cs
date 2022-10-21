using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class MoveStonesUntilConsecutive
{
    [Theory]
    [InlineData(new object[] { 1, 2, 5, new int[] { 1, 2 } })]
    [InlineData(new object[] { 4, 3, 2, new int[] { 0, 0 } })]
    [InlineData(new object[] { 3, 5, 1, new int[] { 1, 2 } })]
    [InlineData(new object[] { 9, 7, 1, new int[] { 1, 6 } })]
    public void WhenDeterminingNumberOfMoves_ThenMaxAndMixMovesAreReturned(
        int a, int b, int c, int[] expectedResults)
    {
        var result = NumMovesStones(a, b, c);
        Assert.Equal(expectedResults, result);
    }


    // 1. Determine the order of the stones
    // 2. Get the stone with the largest deviation from the median

    // Min strategy:
    // 3. Move that stone be next to the median stone
    // 4. Repeat 2-3 as necessary

    // Max strategy:
    // 3. Move that stone one step closer to median
    // 4. Repeat 2-3 as necessary
    public int[] NumMovesStones(int a, int b, int c)
    {
        var sorted = new int[] { a, b, c }.OrderBy(x => x).ToArray();

        var minCount = MoveMin(sorted[0], sorted[1], sorted[2], 0);
        var maxCount = MoveMax(sorted[0], sorted[1], sorted[2], 0);

        return new int[] { minCount, maxCount };
    }


    private static int MoveMin(int min, int mid, int max, int moves)
    {
        // If deviation from mid of 1, then we're in order
        if (mid - min == 1 && max - mid == 1)
        {
            return moves;
        }
        // Max has greater deviation
        if (mid - min < max - mid)
        {
            // when there's a deviation of 2, slot in middle (i.e. 1, 3, 8)
            if (mid - min == 2)
            {
                return MoveMin(min, min + 1, mid, moves + 1);
            }
            return MoveMin(min, mid, mid + 1, moves + 1);
        }
        // Min has greater deviation
        // when there's a deviation of 2, slot in middle (i.e. 1, 7, 9)
        if (max - mid == 2)
        {
            return MoveMin(mid, mid + 1, max, moves + 1);
        }
        return MoveMin(mid - 1, mid, max, moves + 1);
    }

    private static int MoveMax(int min, int mid, int max, int moves)
    {
        // If deviation from mid of 1, then we're in order
        if (mid - min == 1 && max - mid == 1)
        {
            return moves;
        }
        // Max has greater deviation
        if (mid - min < max - mid)
        {
            return MoveMax(min, mid, max - 1, moves + 1);
        }
        // Min has greater deviation
        return MoveMax(min + 1, mid, max, moves + 1);
    }
}
