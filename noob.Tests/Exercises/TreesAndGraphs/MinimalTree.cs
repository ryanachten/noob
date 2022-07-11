using noob.Models.Trees.BinaryTree;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// Given a sorted (increasing order) array with unique integer elements, write an algorithm
/// to create a binary search tree with minimal height.
/// </summary>
public class MinimalTree
{
    [Theory]
    ///     3
    ///     /\
    ///    2  4
    ///   /
    ///  1 
    [InlineData(new int[] { 1, 2, 3, 4 }, 3)]
    ///     4
    ///     /\
    ///    2  6
    ///   /\  /\
    ///  1  3 5 7
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3)]
    public void WhenCreatingABinarySearchTree_ThenTreeIsReturnedWithMinimalHeight(int[] numbers, int expectedHeight)
    {
        // Arrange
        var tree = new BinarySearchTree<int, int>();

        // Act
        var result = AddMiddleItemToTree(tree, numbers, 0, numbers.Length);

        // Assert
        Assert.Equal(expectedHeight, tree.GetHeight());
        var index = 0;
        foreach (var item in result.Items())
        {
            Assert.Equal(numbers[index], item?.Data.Value);
            index++;
        }
    }

    /// <summary>
    /// Recursively adds the middle index of the sorted array to the tree
    /// this ensures the tree is balanced with minimal height
    /// </summary>
    /// <param name="tree">Binary search tree</param>
    /// <param name="arr">Sorted array of integers</param>
    /// <param name="minIndex">Min index to add from</param>
    /// <param name="maxIndex">Max index to add from</param>
    /// <returns>Tree with array items added to it</returns>
    private static BinarySearchTree<int, int> AddMiddleItemToTree(BinarySearchTree<int, int> tree, int[] arr, int minIndex, int maxIndex)
    {
        if(minIndex == maxIndex) return tree;

        var middle = minIndex + (maxIndex - minIndex) / 2;
        var value = arr[middle];

        tree.Add(value, value);
        tree = AddMiddleItemToTree(tree, arr, minIndex, middle);
        tree = AddMiddleItemToTree(tree, arr, middle + 1, maxIndex);

        return tree;
    }
}
