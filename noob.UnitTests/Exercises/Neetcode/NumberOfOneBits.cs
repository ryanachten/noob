using Xunit;

namespace noob.UnitTests.Exercises.NeetCode;

public class NumberOfOneBits
{

    [Theory]
    [InlineData(0b_00000000000000000000000000010111, 4)]
    [InlineData(0b_01111111111111111111111111111101, 30)]
    public void GivenBits_WhenFindingNumberOfOneBits_ThenTheCorrectNumberIsReturned(uint n, int expected)
    {
        var result = HammingWeight(n);
        Assert.Equal(expected, result);
    }

    public static int HammingWeight(uint n)
    {
        var count = 0;

        for (var i = 0; i < 32; i++)
        {
            // shift bits right by ith positions 
            // mask with 1 using an AND operations to verify what the value at the ith position is
            var bit = (n >> i) & 1;
            if (bit == 1) count++;
        }

        return count;
    }
}