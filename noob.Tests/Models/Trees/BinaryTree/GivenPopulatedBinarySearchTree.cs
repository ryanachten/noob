using noob.Models.Trees.BinaryTree;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Models.Trees.BinaryTree;

public class GivenPopulatedBinarySearchTree
{
    private readonly BinarySearchTree<int, string> _tree;

    public GivenPopulatedBinarySearchTree()
    {
        var tree = new BinarySearchTree<int, string>();
        tree.Add(6, "root");
        tree.Add(4, "root.lc");
        tree.Add(8, "root.rc");
        tree.Add(3, "root.lc.lc");
        tree.Add(5, "root.lc.rc");
        tree.Add(7, "root.rc.lc");
        tree.Add(9, "root.rc.rc");

        _tree = tree;
    }

    [Fact]
    public void WhenGettingValueWithOnlyOneValue_ThenRootNodeIsReturned()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();
        tree.Add(1, "test");

        // Act
        var result = tree.TryGetValue(1);

        // Assert
        Assert.Equal("test", result);
    }

    [Fact]
    public void WhenGettingValuesFromNestedTree_ThenCorrectValuesAreReturned()
    {
        // Act
        var result1 = _tree.TryGetValue(6);
        var result2 = _tree.TryGetValue(4);
        var result3 = _tree.TryGetValue(8);
        var result4 = _tree.TryGetValue(3);
        var result5 = _tree.TryGetValue(5);
        var result6 = _tree.TryGetValue(7);
        var result7 = _tree.TryGetValue(9);

        // Assert
        Assert.Equal("root", result1);
        Assert.Equal("root.lc", result2);
        Assert.Equal("root.rc", result3);
        Assert.Equal("root.lc.lc", result4);
        Assert.Equal("root.lc.rc", result5);
        Assert.Equal("root.rc.lc", result6);
        Assert.Equal("root.rc.rc", result7);
    }

    [Fact]
    public void WhenRemovingNodeWithOnlyLeftChild_ThenNodeIsReplacedWithLeftChild()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();
        tree.Add(6, "root");
        tree.Add(4, "root.lc");
        tree.Add(8, "root.rc");
        tree.Add(3, "root.lc.lc");

        var expectedTree = new BinarySearchTree<int, string>();
        expectedTree.Add(6, "root");
        expectedTree.Add(3, "root.lc.lc");
        expectedTree.Add(8, "root.rc");

        // Act
        var result = tree.Remove(4);

        // Assert
        Assert.True(result);
        HasEqualTrees(expectedTree, tree);
    }

    [Fact]
    public void WhenRemovingNodeWithOnlyRightChild_ThenNodeIsReplacedWithRightChild()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();
        tree.Add(6, "root");
        tree.Add(4, "root.lc");
        tree.Add(8, "root.rc");
        tree.Add(5, "root.lc.rc");

        var expectedTree = new BinarySearchTree<int, string>();
        expectedTree.Add(6, "root");
        expectedTree.Add(5, "root.lc.rc");
        expectedTree.Add(8, "root.rc");

        // Act
        var result = tree.Remove(4);

        // Assert
        Assert.True(result);
        HasEqualTrees(expectedTree, tree);
    }

    [Fact]
    public void WhenRemovingNodeWithNoChildren_ThenNodeShouldBeRemoved()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();
        tree.Add(6, "root");
        tree.Add(4, "root.lc");
        tree.Add(8, "root.rc");
        tree.Add(5, "root.lc.rc");

        var expectedTree = new BinarySearchTree<int, string>();
        expectedTree.Add(6, "root");
        expectedTree.Add(4, "root.lc");
        expectedTree.Add(8, "root.rc");

        // Act
        var result = tree.Remove(5);

        // Assert
        Assert.True(result);
        HasEqualTrees(expectedTree, tree);
    }

    [Fact]
    public void WhenRemovingNodeWithBothChildren_ThenNodeIsReplacedWithSmallestKeyOnRight()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();
        tree.Add(6, "root");
        tree.Add(4, "root.lc");
        tree.Add(8, "root.rc");
        tree.Add(3, "root.lc.lc");
        tree.Add(5, "root.lc.rc");
        tree.Add(7, "root.rc.lc");
        tree.Add(9, "root.rc.rc");

        var expectedTree = new BinarySearchTree<int, string>();
        expectedTree.Add(7, "root.rc.lc");
        expectedTree.Add(4, "root.lc");
        expectedTree.Add(8, "root.rc");
        expectedTree.Add(3, "root.lc.lc");
        expectedTree.Add(5, "root.lc.rc");
        expectedTree.Add(9, "root.rc.rc");

        // Act
        var result = tree.Remove(6);

        // Assert
        Assert.True(result);
        HasEqualTrees(expectedTree, tree);
    }

    [Fact]
    public void WhenRemovingNodeUsingKeyThatDoesntExist_ThenFalseIsReturned()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();
        tree.Add(6, "root");
        tree.Add(4, "root.lc");
        tree.Add(8, "root.rc");
        tree.Add(3, "root.lc.lc");
        tree.Add(5, "root.lc.rc");
        tree.Add(7, "root.rc.lc");
        tree.Add(9, "root.rc.rc");

        var expectedTree = new BinarySearchTree<int, string>();
        expectedTree.Add(6, "root");
        expectedTree.Add(4, "root.lc");
        expectedTree.Add(8, "root.rc");
        expectedTree.Add(3, "root.lc.lc");
        expectedTree.Add(5, "root.lc.rc");
        expectedTree.Add(7, "root.rc.lc");
        expectedTree.Add(9, "root.rc.rc");

        // Act
        var result = tree.Remove(100);

        // Assert
        Assert.False(result);
    }

    private static void HasEqualTrees(BinarySearchTree<int, string> tree1, BinarySearchTree<int, string> tree2)
    {
        var items1 = tree1.Items();
        var items2 = tree2.Items();
        for (int i = 0; i < items2.Count(); i++)
        {
            var item1 = items1.ElementAt(i);
            var item2 = items2.ElementAt(i);

            Assert.NotNull(item1);
            Assert.NotNull(item2);
            Assert.Equal(item1.Data.Value, item2.Data.Value);
            Assert.Equal(item1.Data.Key, item2.Data.Key);
        }
    }
}
