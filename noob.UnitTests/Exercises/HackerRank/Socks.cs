using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace noob.UnitTests.Exercises.HackerRank;

public class Socks
{
    [Theory]
    [InlineData(new object[] { new int[] {1, 2, 1, 2, 1, 3, 2 }, 2 })]
    public void WhenGettingFindingSockPairs_ThenCorrectNumberOfPairsIsReturned(int[] socks, int expectedPairs)
    {
        var res = SockMerchantLinq(socks.Length, socks.ToList());
        var res2 = SockMerchant(socks.Length, socks.ToList());

        Assert.Equal(expectedPairs, res);
        Assert.Equal(expectedPairs, res2);
    }

    /// <summary>
    /// LINQ implementation
    /// </summary>
    /// <param name="n"></param>
    /// <param name="ar"></param>
    /// <returns></returns>
    public static int SockMerchantLinq(int n, List<int> ar)
    {
        return ar.GroupBy(x => x).Sum(group => group.Count() / 2);
    }

    /// <summary>
    /// Dictionary implementation
    /// </summary>
    /// <param name="n"></param>
    /// <param name="ar"></param>
    /// <returns></returns>
    public static int SockMerchant(int n, List<int> ar)
    {
        var socks = new Dictionary<int, int>();
        foreach (var sock in ar)
        {
            if (socks.ContainsKey(sock))
            {
                socks[sock]++;
            } else
            {
                socks.Add(sock, 1);
            }
        }

        var total = 0;
        foreach (var kvp in socks)
        {
            total += kvp.Value / 2;
        }

        return total;
    }
}
