using System.Text;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class ZigzagConversion
{
    [Theory]
    // P   A   H   N
    // A P L S I I G
    // Y   I R
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    // P I    N
    // A   L S  I G
    // Y A   H R
    // P I
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 1, "A")]
    [InlineData("AB", 1, "AB")]
    public void WhenConvertingArrayToString_ThenStringIsComputedUsingZigZagPattern(string str, int numRows, string expectedResult)
    {
        var result = Convert(str, numRows);
        Assert.Equal(expectedResult, result);
    }


    // - iterate through through string, adding characters to row
    // - when row = n, then we are on the next column
    // - if column % n-1 == 0, then we're on another full column
    // - otherwise, it's a single character entry
    // - row index for single character entry = column % n-1
    public string Convert(string s, int numRows)
    {
        // If there's only one row or the string is less than 2 characters, then we're good
        if (numRows == 1 || s.Length < 2) return s;

        var n = numRows - 1;
        n = n < 0 ? 0 : n;

        var builders = new StringBuilder[numRows];
        for (var i = 0; i < numRows; i++)
        {
            builders[i] = new StringBuilder();
        }

        for (var i = 0; i < s.Length;)
        {
            if (i % n == 0)
            {
                // handle n row characters
                // - compute row index based on j % numRows
                for (var j = 0; j < numRows && j + i < s.Length; j++)
                {
                    var rowIndex = j % numRows;
                    builders[rowIndex].Append(s[j + i]);
                }
                i += numRows;
            }
            else
            {
                // handle single character
                var rowIndex = n - i % n;
                builders[rowIndex].Append(s[i]);
                i++;
            }
        }

        var result = new StringBuilder();
        foreach (var builder in builders) result.Append(builder.ToString());

        return result.ToString();
    }
}
