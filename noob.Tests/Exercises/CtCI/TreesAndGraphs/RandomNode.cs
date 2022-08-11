using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// You are implementing a binary tree class from scratch which, in addition to
/// insert, find, and delete, has a method getRandomNode() which returns a random node
/// from the tree.All nodes should be equally likely to be chosen. Design and implement an algorithm
/// for getRandomNode, and explain how you would implement the rest of the methods.
/// </summary>
public class RandomNode
{
    private class BinaryTreeNode
    {
        public int Value { get; set; }
        public BinaryTreeNode? Parent { get; set; }
        public BinaryTreeNode? LeftChild { get; set; }
        public BinaryTreeNode? RightChild { get; set; }

        public BinaryTreeNode(int value, BinaryTreeNode? parentNode)
        {
            Value = value;
            Parent = parentNode;
        }
    }

    private class BinaryTree
    {
        public BinaryTreeNode? Root { get; private set; }

        public BinaryTreeNode Insert(int value)
        {
            if (Root == null)
            {
                return Root = new BinaryTreeNode(value, null);
            }
            return Insert(value, Root);
        }

        public BinaryTreeNode Insert(int value, BinaryTreeNode parentNode)
        {
            if (parentNode.LeftChild == null)
            {
                return parentNode.LeftChild = new BinaryTreeNode(value, parentNode);
            }
            if (parentNode.RightChild == null)
            {
                return parentNode.RightChild = new BinaryTreeNode(value, parentNode);
            }

            // If both left and right are filled, we recurse down a branch
            // the branch we recurse is selected randomly to keep things balanced(ish)
            var rand = new Random().Next(-1, 2);
            if (rand > 0)
            {
                return Insert(value, parentNode.LeftChild);
            }
            return Insert(value, parentNode.RightChild);
        }

        public BinaryTreeNode GetRandomNode()
        {
            var nodes = PreOrderTraversal(Root);
            var random = new Random().Next(0, nodes.Count());
            return nodes.ElementAt(random);
        }

        /// <summary>
        /// Find the deepest node in tree, favoring the right side
        /// </summary>
        private BinaryTreeNode? FindDeepestNode(BinaryTreeNode node)
        {
            if (node.RightChild != null) return FindDeepestNode(node.RightChild);

            if (node.LeftChild != null) return FindDeepestNode(node.LeftChild);

            return null;
        }

        private IEnumerable<BinaryTreeNode> PreOrderTraversal(BinaryTreeNode? node)
        {
            if (node != null)
            {
                yield return node;

                foreach (var child in PreOrderTraversal(node.LeftChild))
                {
                    yield return child;
                }

                foreach (var child in PreOrderTraversal(node.RightChild))
                {
                    yield return child;
                }
            }
        }
    }


    [Fact]
    public void WhenInsertingValuesToTree_ThenValuesAreInserted()
    {
        // Arrange
        var tree = new BinaryTree();

        // Act
        tree.Insert(1);
        tree.Insert(2);
        tree.Insert(3);
        tree.Insert(4, tree.Root!.LeftChild!);
        tree.Insert(5, tree.Root!.RightChild!);

        // Assert
        Assert.Equal(1, tree.Root.Value);
        Assert.Equal(2, tree.Root?.LeftChild?.Value);
        Assert.Equal(3, tree.Root?.RightChild?.Value);
        Assert.Equal(4, tree.Root?.LeftChild?.LeftChild?.Value);
        Assert.Equal(5, tree.Root?.RightChild?.LeftChild?.Value);
    }

    //[Fact]
    //public void WhenDeletingValuesFromATree_ThenNodesAreUpdatedAndRemoved()
    //{
    //    ///     1      ->      5   
    //    ///     /\     ->      /\  
    //    ///    2  3    ->     2  3 
    //    ///   /   /    ->    /   
    //    ///  4   5     ->   4     

    //    // Arrange
    //    var tree = new BinaryTree();
    //    tree.Insert(1);
    //    tree.Insert(2);
    //    tree.Insert(3);
    //    tree.Insert(4, tree.Root!.LeftChild!);
    //    tree.Insert(5, tree.Root!.RightChild!);

    //    // Act
    //    tree.Delete(1);

    //    // Assert
    //    Assert.Equal(5, tree.Root.Value);
    //}

    [Fact]
    public void WhenGeneratingRandomNode_ThenRandomNodeIsReturned()
    {
        // Arrange
        ///     4
        ///     /\
        ///    6  2
        ///   /\  /\
        ///  1  3 5 7
        var tree = new BinaryTree();
        tree.Insert(4);
        tree.Insert(6);
        tree.Insert(2);
        tree.Insert(1);
        tree.Insert(3);
        tree.Insert(5);
        tree.Insert(7);

        // Act
        var randomNodesCount = 7;
        var nodes = new List<BinaryTreeNode>();
        for (int i = 0; i < randomNodesCount; i++)
        {
            nodes.Add(tree.GetRandomNode());
        }

        // Assert
        Assert.Equal(randomNodesCount, nodes.Where(x => x != null).Count());
        Assert.True(nodes.Distinct().Count() > 1);
    }
}
