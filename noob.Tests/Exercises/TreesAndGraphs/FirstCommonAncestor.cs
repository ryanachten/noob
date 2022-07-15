using noob.Constants.Enums;
using noob.Models.Trees.BinaryTree;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// Design an algorithm and write code to find the first common ancestor
/// of two nodes in a binary tree.Avoid storing additional nodes in a data structure.NOTE: This is not
/// necessarily a binary search tree.
/// </summary>
public class FirstCommonAncestor
{
    public static IEnumerable<object[]> Nodes()
    {
        ///     4
        ///     /\
        ///    6  2
        ///   /\  /\
        ///  1  3 5 7
        var tree = new BinaryTree<int, int>();
        tree.Add(4, 4);
        tree.Add(6, 6, tree.Root!);
        tree.Add(2, 2, tree.Root!);
        tree.Add(1, 1, tree.Root!.LeftChild!);
        tree.Add(3, 3, tree.Root!.LeftChild!);
        tree.Add(5, 5, tree.Root!.RightChild!);
        tree.Add(7, 7, tree.Root!.RightChild!);

        return new List<object[]>
        {
            new object[] {
                // 2, 6, 4
                tree, tree.Root!.RightChild!, tree.Root!.LeftChild!, tree.Root
            },
            new object[] {
                // 5, 6, 4
                tree, tree.Root!.RightChild!.LeftChild!, tree.Root!.LeftChild!, tree.Root
            },
            new object[] {
                // 5, 7, 2
                tree, tree.Root!.RightChild!.LeftChild!, tree.Root!.RightChild!.RightChild!, tree.Root!.RightChild
            },
            new object[] {
                // 5, 4, null
                tree, tree.Root!.RightChild!.LeftChild!, tree.Root, tree.Root
            },
            new object[] {
                // 5, 4, null
                tree, tree.Root!.RightChild!.LeftChild!, new BinaryTreeNode<int, int>(100, 100), default!
            },
        };
    }

    [Theory]
    [MemberData(nameof(Nodes))]
    public void WhenFindingCommonAncestorViaParent_ThenCommonAncestorIsDetermined(
        BinaryTree<int, int> tree, BinaryTreeNode<int, int> node1, BinaryTreeNode<int, int> node2, BinaryTreeNode<int, int>? expectedNode)
    {
        // Act
        var result = GetCommonAncestorViaParent(node1, node2);

        // Assert
        Assert.Equal(expectedNode, result);
    }

    [Theory]
    [MemberData(nameof(Nodes))]
    public void WhenFindingCommonAncestorViaDfs_ThenCommonAncestorIsDetermined(
        BinaryTree<int, int> tree, BinaryTreeNode<int, int> node1, BinaryTreeNode<int, int> node2, BinaryTreeNode<int, int>? expectedNode)
    {
        // Act
        var result = GetCommonAncestorViaDescendent(tree, node1, node2);

        // Assert
        Assert.Equal(expectedNode, result);
    }

    /// <summary>
    /// Getting common ancestor via the parent node
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns></returns>
    private static BinaryTreeNode<int, int>? GetCommonAncestorViaParent(BinaryTreeNode<int, int> node1, BinaryTreeNode<int, int> node2)
    {
        var currentNode1 = node1;
        while (currentNode1 != null)
        {
            var currentNode2 = node2;
            while (currentNode2 != null)
            {
                if (currentNode1.Equals(currentNode2))
                {
                    return currentNode1;
                }

                currentNode2 = currentNode2.Parent;
            }
            currentNode1 = currentNode1.Parent;
        }

        return null;
    }

    /// <summary>
    /// Alternative implementation getting common ancestor via the descendent
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns></returns>
    private static BinaryTreeNode<int, int>? GetCommonAncestorViaDescendent(BinaryTree<int, int> tree, BinaryTreeNode<int, int> node1, BinaryTreeNode<int, int> node2)
    {
        BinaryTreeNode<int, int>? deepestAncestor = null;
        foreach (var node in tree.Items(BinaryTreeTraversalOrder.PRE_ORDER))
        {
            var hasBothNodes = ContainsNode(node, node1) && ContainsNode(node, node2);
            if (hasBothNodes)
            {
                deepestAncestor = node;
            }
        }
        return deepestAncestor;
    }

    // Recursively search for a node
    private static bool ContainsNode(BinaryTreeNode<int, int>? currentNode, BinaryTreeNode<int, int> targetNode)
    {
        if (currentNode == null) return false;

        if(currentNode.Equals(targetNode)) return true;

        var left = ContainsNode(currentNode.LeftChild, targetNode);
        var right = ContainsNode(currentNode.RightChild, targetNode);

        return left || right;
    }
}
