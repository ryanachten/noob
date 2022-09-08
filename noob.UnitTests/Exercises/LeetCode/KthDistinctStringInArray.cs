using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class KthDistinctStringInArray
{
    [Theory]
    [InlineData(new object[] { new string[] { "d", "b", "c", "b", "c", "a" }, 2, "a" })]
    [InlineData(new object[] { new string[] { "aaa", "aa", "a" }, 1, "aaa" })]
    [InlineData(new object[] { new string[] { "a", "b", "a" }, 3, "" })]
    public void WhenFindingDistinctString_ThenKthDistinctValueIsReturned(string[] arr, int k, string expectedResult)
    {
        var result = KthDistinct(arr, k);
        Assert.Equal(expectedResult, result);
    }

    public string KthDistinct(string[] arr, int k)
    {
        var parsedStrs = new Dictionary<string, int>();
        foreach (var str in arr)
        {
            if (parsedStrs.ContainsKey(str))
            {
                parsedStrs[str]++;
            }
            else
            {
                parsedStrs.Add(str, 1);
            }
        }
        foreach (var str in arr)
        {
            if (parsedStrs[str] == 1)
            {
                k--;
                if (k == 0)
                {
                    return str;
                }
            }
        }

        return string.Empty;
    }
}
