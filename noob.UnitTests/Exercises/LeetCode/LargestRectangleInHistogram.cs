using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class LargestRectangleInHistogram
{
    public static int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int>();
        var maxArea = 0;

        for (var i = 0; i <= heights.Length; i++)
        {
            // Add sentinel to close off the histogram
            var currentHeight = heights.Length == i ? 0 : heights[i];

            // while we have items in the stack and the current height is smaller than the largest height
            while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
            {
                // The current height is the top of the stack
                var height = heights[stack.Pop()];

                // We've found something smaller, so now we know our right boundary (i - 1)
                // The left boundary is the first bar to the left that is smaller (stack.Peek() + 1)
                // If the stack is empty, then there is no smaller value and i is the width
                // Otherwise we subtract right from left to get width
                var width = stack.Count == 0 ? i : i - stack.Peek() - 1;

                // Update max area with current value if larger
                var currentArea = height * width;
                maxArea = Math.Max(maxArea, currentArea);
            }

            stack.Push(i);
        }

        return maxArea;
    }

    public static TheoryData<int[], int> HistogramTestData =>
        new()
        {
            { [ 2, 1, 5, 6, 2, 3 ], 10 },
            { [ 2, 4 ], 4 }
        };

    [Theory]
    [MemberData(nameof(HistogramTestData))]
    public void GivenHistogram_WhenEvaluatingLargestRectangle_ThenLargestAreaIsReturned(int[] histogram, int expectedResult)
    {
        var result = LargestRectangleArea(histogram);
        Assert.Equal(expectedResult, result);
    }
}