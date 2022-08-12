using noob.Models.Trees.BinaryTree;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// Write an algorithm to find the "next" node (i.e., in-order successor) of a given node in a
/// binary search tree.You may assume that each node has a link to its parent.
/// </summary>
public class Successor
{
    public static IEnumerable<object[]> Nodes()
    {
        ///     4
        ///     /\
        ///    2  6
        ///   /\  /\
        ///  1  3 5 7
        var tree = new BinarySearchTree<int, int>();
        tree.Add(4, 4);
        tree.Add(2, 2);
        tree.Add(6, 6);
        tree.Add(1, 1);
        tree.Add(5, 5);
        tree.Add(3, 3);
        tree.Add(7, 7);

        return new List<object[]>
        {
            new object[] {
                // nodes 2, 3
                tree.Root!.RightChild!, tree.Root!.RightChild!.LeftChild!
            },
            new object[] {
                // nodes 3, 4
                tree.Root!.LeftChild!.RightChild!, tree.Root
            },
            new object[] {
                // nodes 1, 2
                tree.Root!.LeftChild!.LeftChild!, tree.Root.LeftChild
            },
            new object[] {
                // nodes 5, 6
                tree.Root!.RightChild!.LeftChild!, tree.Root.RightChild
            },
            new object[] {
                // nodes 7
                tree.Root!.RightChild!.RightChild!, default!
            }

        };
    }

    [Theory]
    [MemberData(nameof(Nodes))]
    public void WhenDeterminingNextInOrderSuccessor_ThenCorrectNodeIsReturned(
        BinaryTreeNode<int, int> targetNode, BinaryTreeNode<int, int>? expectedResult)
    {
        // Act
        var result = GetSuccessorFromNode(targetNode);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    /// <summary>
    /// Retrieve next node in-order based on a given node
    /// </summary>
    /// <param name="targetNode"></param>
    private static BinaryTreeNode<int, int>? GetSuccessorFromNode(BinaryTreeNode<int, int> targetNode)
    {
        if (targetNode.LeftChild != null) return targetNode.LeftChild;

        if (targetNode.RightChild != null) return targetNode.RightChild;

        // If we're at a leaf node, traverse up the tree until we find a node greater than the node
        var currentNode = targetNode;
        while(currentNode.Parent != null)
        {
            if(currentNode.Parent.Data.Key > targetNode.Data.Key)
            {
                return currentNode.Parent;
            }
            currentNode = currentNode.Parent;
        }

        return null;
    }
}
