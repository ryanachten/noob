using noob.Models.Trees;
using System;
using Xunit;
using KVP = System.Collections.Generic.KeyValuePair<int, string>;

namespace noob.UnitTests.Models.Trees;

public class GivenEmptyBinarySearchTree
{
    [Fact]
    public void WhenGettingValueFromEmptyTree_ThenDefaultIsReturned()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();

        // Act
        var result = tree.TryGetValue(1);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void WhenAddingToEmptyBinarySearchTree_ThenRootNodeIsCreated()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();

        // Act
        tree.Add(1, "test");

        // Assert
        Assert.NotNull(tree.Root);
        Assert.Equal(1, tree.Root.Data.Key);
        Assert.Equal("test", tree.Root.Data.Value);
    }

    [Fact]
    public void WhenAddingKeyEqualToRoot_ThenExceptionIsThrown()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();

        // Act
        tree.Add(1, "test");

        // Assert
        var ex = Assert.Throws<ArgumentException>(() => tree.Add(1, "child of test"));
        Assert.Equal("Key '1' already exists and cannot be updated", ex.Message);
    }

    [Fact]
    public void WhenAddingKeyLowerThanRoot_ThenLeftNodeIsCreated()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();

        // Act
        tree.Add(10, "test");
        tree.Add(1, "child of test");

        // Assert
        Assert.NotNull(tree.Root);
        Assert.Equal(10, tree.Root.Data.Key);
        Assert.Equal("test", tree.Root.Data.Value);

        var leftChild = tree.Root.LeftChild;
        Assert.NotNull(leftChild);
        Assert.Equal(1, leftChild.Data.Key);
        Assert.Equal("child of test", leftChild.Data.Value);

        Assert.Null(tree.Root.RightChild);
    }

    [Fact]
    public void WhenAddingKeyGreaterThanRoot_ThenRightNodeIsCreated()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();

        // Act
        tree.Add(1, "test");
        tree.Add(10, "child of test");

        // Assert
        Assert.NotNull(tree.Root);
        Assert.Equal(1, tree.Root.Data.Key);
        Assert.Equal("test", tree.Root.Data.Value);

        var rightChild = tree.Root.RightChild;
        Assert.NotNull(rightChild);
        Assert.Equal(10, rightChild.Data.Key);
        Assert.Equal("child of test", rightChild.Data.Value);

        Assert.Null(tree.Root.LeftChild);
    }

    [Fact]
    public void WhenAddingMultipleKeys_ThenTreeIsBuiltCorrectly()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();

        // Act
        tree.Add(6, "root");
        
        tree.Add(4, "root.lc");
        tree.Add(8, "root.rc");

        tree.Add(3, "root.lc.lc");
        tree.Add(5, "root.lc.rc");
        
        tree.Add(7, "root.rc.lc");
        tree.Add(9, "root.rc.rc");

        // Assert
        Assert.Equal(new KVP(6, "root"), tree?.Root?.Data);

        Assert.Equal(new KVP(4, "root.lc"), tree?.Root?.LeftChild?.Data);
        Assert.Equal(new KVP(8, "root.rc"), tree?.Root?.RightChild?.Data);

        Assert.Equal(new KVP(3, "root.lc.lc"), tree?.Root?.LeftChild?.LeftChild?.Data);
        Assert.Equal(new KVP(5, "root.lc.rc"), tree?.Root?.LeftChild?.RightChild?.Data);

        Assert.Equal(new KVP(7, "root.rc.lc"), tree?.Root?.RightChild?.LeftChild?.Data);
        Assert.Equal(new KVP(9, "root.rc.rc"), tree?.Root?.RightChild?.RightChild?.Data);
    }

    [Fact]
    public void WhenRemovingKeyFromEmptyTree_ThenFalseIsReturned()
    {
        // Arrange
        var tree = new BinarySearchTree<int, string>();

        // Act
        var result = tree.Remove(0);

        // Assert
        Assert.False(result);
    }
}
