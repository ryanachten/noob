using System;
using System.Linq;
using System.Text;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class ReverseInteger
{
    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(Int32.MinValue, 0)]
    public void WhenReversingAnInteger_ThenDigitsAreReversedAsInt32(int num, int expectedResult)
    {
        var result = Reverse(num);
        Assert.Equal(expectedResult, result);
    }

    public int Reverse(int x)
    {
        var str = x.ToString();
        var isNegative = str[0] == '-';
        if (isNegative)
        {
            str = str.Replace("-", string.Empty);
        }
        var reversedStr = new StringBuilder().Append(str.Reverse().ToArray()).ToString();
        var hasParsed = int.TryParse(reversedStr, out int parsedNumber);
        if (hasParsed)
        {
            if (isNegative)
            {
                parsedNumber *= -1;
            }
            return parsedNumber;
        }
        return 0;
    }
}
