using System;
using System.Text;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class AddBinaryStrings
{
    [Theory]
    [InlineData("1", "1", "10")]
    [InlineData("1", "0", "1")]
    [InlineData("0", "1", "1")]
    [InlineData("0", "0", "0")]
    [InlineData("10", "10", "100")]
    [InlineData("11", "11", "110")]

    [InlineData("11", "1", "100")]
    [InlineData("1010", "1011", "10101")]
    [InlineData("1111", "1111", "11110")]

    public void GivenTwoBinaryStrings_ThenTheCorrectBinarySumStringIsReturned(string num1, string num2, string expectedResult)
    {
        var result = AddBinary(num1, num2);
        Assert.Equal(expectedResult, result);
    }

    public string AddBinary(string a, string b)
    {
        var res = new StringBuilder();
        var maxLength = Math.Max(a.Length, b.Length);
        var overflow = 0;
        for (var i = 0; i < maxLength; i++)
        {
            var aIndex = a.Length - i - 1;
            var bIndex = b.Length - i - 1;

            var charA = aIndex >= 0 ? a[aIndex] : '0';
            var charB = bIndex >= 0 ? b[bIndex] : '0';
            var str = Add(charA, charB, ref overflow);
            res.Insert(0, str);
        }

        if (overflow == 1)
        {
            res.Insert(0, 1);
        }

        return res.ToString();
    }

    private static int Add(char charA, char charB, ref int overflow)
    {
        var a = charA - '0';
        var b = charB - '0';

        var sum = a + b + overflow;
        overflow = sum > 1 ? 1 : 0;
        return sum % 2;
    }
}
