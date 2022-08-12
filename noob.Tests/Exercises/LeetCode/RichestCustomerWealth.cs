using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class RichestCustomerWealth
{
    public static IEnumerable<object[]> Accounts() => new List<object[]>()
    {
        new object[] {
            new int[][]
            {
                new int[] {1, 2, 3},
                new int[] {3, 2, 1}
            },
            6
        },
        new object[] {
            new int[][]
            {
                new int[] {1, 5},
                new int[] {7, 3},
                new int[] {3, 5}
            },
            10
        },
        new object[] {
            new int[][]
            {
                new int[] {2, 8, 7},
                new int[] {7, 1, 3},
                new int[] {1, 9, 5}
            },
            17
        }
    };

    [Theory]
    [MemberData(nameof(Accounts))]
    public void WhenDeterminingCustomerWealth_ThenRichestCustomerWealthIsReturned(int[][] accounts, int expectedResult)
    {
        var result = MaximumWealth(accounts);
        Assert.Equal(expectedResult, result);
    }

    public int MaximumWealth(int[][] accounts)
    {
        return accounts.Select(a => a.Sum()).Max();
    }
}
