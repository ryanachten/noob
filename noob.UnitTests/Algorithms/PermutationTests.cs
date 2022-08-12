using noob.Algorithms;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Algorithms
{
    public class PermutationTests
    {
        [Theory]
        [InlineData("abc", 6)]
        [InlineData("test", 24)]
        public void WhenPermutatingStrings_ThenCallbackWithResultsAreExecuted(string str, int expectedNumberOfResults)
        {
            // Arrange
            var permutation = new Permutation(str);

            // Act
            var permutations = permutation.Permutate().GetPermutations();
            Assert.Equal(expectedNumberOfResults, permutations.Count());
        }
    }
}
