using System;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class StringToInteger
{
    [Theory]
    [InlineData("42", 42)]
    [InlineData("+42", 42)]
    [InlineData("-42", -42)]
    [InlineData("   -42", -42)]
    [InlineData("4193 with words", 4193)]
    [InlineData("2147483648", Int32.MaxValue)] // Over Int32 max of 2147483647
    [InlineData("-2147483649", Int32.MinValue)] // Below Int32 min of -2147483648
    public void WhenConvertingStringToInteger_ThenConsecutiveNumeralsAreConverted(string str, int expectedResult)
    {
        var result1 = RegexMyAtoi(str);
        var result2 = StringParseMyAtoi(str);

        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult, result2);
    }

    private static readonly Regex _regex = new(@"^[\s]*(?<prefix>[+|-])?(?<number>[\d]+)", RegexOptions.Compiled);

    /// <summary>
    /// Regex implementation
    /// Runtime optimized compared to the string parse approach
    /// </summary>
    public int RegexMyAtoi(string s)
    {
        var isNegative = false;
        var matches = _regex.Match(s);
        var hasPrefix = matches.Groups.TryGetValue("prefix", out Group? prefix);
        if (hasPrefix && prefix?.Value == "-")
        {
            isNegative = true;
        }
        var hasNumber = matches.Groups.TryGetValue("number", out Group? number);
        if (hasNumber && !string.IsNullOrEmpty(number?.Value))
        {
            return ParseString(number.Value, isNegative);
        }
        return 0;
    }

    /// <summary>
    /// String parse implementation
    /// Space optimized, compared to the regex approach
    /// </summary>
    public int StringParseMyAtoi(string s)
    {
        var str = s.Trim();
        var isNegative = false;
        var builder = new StringBuilder();

        for (var i = 0; i < str.Length; i++)
        {
            var character = str[i];
            // If the first character '-' or '+', skip it
            if (i == 0)
            {
                if (character == '-')
                {
                    isNegative = true;
                    continue;
                }
                if (character == '+')
                {
                    continue;
                }
            }
            // Bit of a guess, but I think we should be able to know if the character is not a valid numeral
            // by using '0' and '9' as lower and upper bounds
            if (character < '0' || character > '9')
            {
                break;
            }
            builder.Append(character);
        }

        return ParseString(builder.ToString(), isNegative);
    }

    private static int ParseString(string str, bool isNegative)
    {
        try
        {
            // Happy path, where number is successfully parsed based on string builder input
            var parsedNumber = Int32.Parse(str);
            if (isNegative)
            {
                parsedNumber *= -1;
            }
            return parsedNumber;
        }
        // If parsing overflows, we return min/max val based on negative flag
        catch (OverflowException)
        {
            if (isNegative) return Int32.MinValue;
            return Int32.MaxValue;
        }
        catch (Exception)
        {
            // As an edge case where something else went wrong, return 0 I guess
        }
        return 0;
    }
}
