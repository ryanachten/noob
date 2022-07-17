using System.Collections.Generic;

namespace noob.UnitTests.Algorithms.Sorting;

public abstract class BaseSortTests
{
    public static IEnumerable<object[]> UnsortedArrays =>
        new List<object[]>
        {
            new[]
            {
                new[] { 3, 1, 2 }, new[]{ 1, 2, 3}
            },
            new[]
            {
                new[] { 1, 2, 3 }, new[] { 1, 2, 3 }
            },
            new[]
            {
                new[] { 5, 2, 3, 5, 6, 1, 3 }, new[] { 1, 2, 3, 3, 5, 5, 6 }
            }
        };
}