using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.HackerRank;

public class Birthday
{
    [Theory]
    [InlineData(new object[]{ new int[] { 2, 2, 1, 3, 2 }, 4, 2, 2 })]
    [InlineData(new object[] { new int[] { 4 }, 4, 1, 1 })]

    public void WhenGettingSegmentsBasedOnBirthday_ThenCorrectNumberOfSegmentsIsReturned(
        int[] segments, int day, int month, int expectedResult)
    {
        var res = GetBirthdaySegments(segments.ToList(), day, month);
        Assert.Equal(expectedResult, res);
    }

    public static int GetBirthdaySegments(List<int> segments, int day, int month)
    {
        var matches = new List<List<int>>();
        for (var i = 0; i < segments.Count; i++)
        {
            var j = i + 1;
            var continuousSegments = new List<int>() { segments[i] };
            while (j < i + month && j < segments.Count)
            {
                continuousSegments.Add(segments[j]);
                j++;
            }
            var total = continuousSegments.Aggregate((int a, int b) => a + b);
            if (total == day)
            {
                matches.Add(continuousSegments);
            }
        }
        return matches.Count;
    }
}
