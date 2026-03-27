using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class RichestCustomerWealth
{
    public static IEnumerable<object[]> Accounts() =>
    [
        [
            new int[][]
            {
                [1, 2, 3],
                [3, 2, 1]
            },
            6
        ],
        [
            new int[][]
            {
                [1, 5],
                [7, 3],
                [3, 5]
            },
            10
        ],
        [
            new int[][]
            {
                [2, 8, 7],
                [7, 1, 3],
                [1, 9, 5]
            },
            17
        ]
    ];

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
