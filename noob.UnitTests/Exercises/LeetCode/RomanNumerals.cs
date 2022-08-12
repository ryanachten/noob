using System;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class RomanNumerals
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void WhenConvertingRomanNumeralsToInteger_ThenCorrectIntegerIsReturned(string roman, int expectedResult)
    {
        var result = RomanToInt(roman);
        Assert.Equal(expectedResult, result);
    }

    public int RomanToInt(string s)
    {
        var numeralLookup = new Dictionary<char, int>(){
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        var exceptions = new Dictionary<(char, char), int>(){
            { ('I', 'V'), 4 },
            { ('I', 'X'), 9 },
            { ('X', 'L'), 40 },
            { ('X', 'C'), 90 },
            { ('C', 'D'), 400 },
            { ('C', 'M'), 900 }
        };

        var integer = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length)
            {
                if (exceptions.ContainsKey((s[i], s[i + 1])))
                {
                    integer += exceptions[(s[i], s[i + 1])];
                    i++;
                    continue;
                }
            }
            integer += numeralLookup[s[i]];
        }
        return integer;
    }
}
