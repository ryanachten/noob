using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class FizzBuzzArray
{
    [Theory]
    [InlineData(new object[] { 3, new string[] { "1", "2", "Fizz" } })]
    [InlineData(new object[] { 5, new string[] { "1", "2", "Fizz", "4", "Buzz" } })]
    [InlineData(new object[] { 15, new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" } })]
    public void WhenGeneratingFizzBuzzArray_ThenCorrectArrayMembersAreReturned(int n, string[] expectedResult)
    {
        var result = FizzBuzz(n);
        Assert.Equal(expectedResult, result);
    }

    public IList<string> FizzBuzz(int n)
    {
        var results = new List<string>();
        for (var i = 1; i <= n; i++){
            var str = string.Empty;

            if (i % 3 == 0) str += "Fizz";
            if (i % 5 == 0) str += "Buzz";
            if (string.IsNullOrEmpty(str)) str += i;

            results.Add(str);
        }
        return results;
    }
}
