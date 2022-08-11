using noob.Constants.Enums;
using noob.Models.Trees.BinaryTree;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// Implement a function to check if a binary tree is a binary search tree.
/// </summary>
public class ValidateBST
{
    public static IEnumerable<object[]> Trees()
    {
        ///     4
        ///     /\
        ///    6  2
        ///   /\  /\
        ///  1  3 5 7
        var tree1 = new BinaryTree<int, int>();
        tree1.Add(4, 4);
        tree1.Add(6, 6);
        tree1.Add(2, 2);
        tree1.Add(1, 1);
        tree1.Add(3, 3);
        tree1.Add(5, 5);
        tree1.Add(7, 7);

        ///     4
        ///     /\
        ///    2  6
        ///   /\  /\
        ///  1  3 5 7
        var tree2 = new BinarySearchTree<int, int>();
        tree2.Add(4, 4);
        tree2.Add(2, 2);
        tree2.Add(6, 6);
        tree2.Add(1, 1);
        tree2.Add(5, 5);
        tree2.Add(3, 3);
        tree2.Add(7, 7);

        ///     4
        ///     /
        ///    6 
        ///   /\ 
        ///  1  3
        var tree3 = new BinaryTree<int, int>();
        tree3.Add(4, 4);
        tree3.Add(6, 6);
        tree3.Add(1, 1, tree3.Root?.LeftChild!);
        tree3.Add(3, 3, tree3.Root?.LeftChild!);

        ///     4
        ///    / \
        ///   1   2
        ///       /\
        ///       5 7
        var tree4 = new BinaryTree<int, int>();
        tree4.Add(4, 4);
        tree4.Add(1, 1);
        tree4.Add(2, 2);
        tree4.Add(5, 5);
        tree4.Add(7, 7);

        return new List<object[]>
        {
            new object[] {
                tree1, false
            },
            new object[] {
                tree2, true
            },
            new object[] {
                tree3, false
            },
            new object[] {
                tree4, false
            }
        };
    }
        

    [Theory]
    [MemberData(nameof(Trees))]
    public void WhenValidatingBinaryTree_ThenBinarySearchTreeIsDetermined(BinaryTree<int, int> tree, bool expectedResult)
    {
        // Act
        var result = IsBinarySearchTree(tree);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    private static bool IsBinarySearchTree(BinaryTree<int, int> tree)
    {
        foreach (var node in tree.Items(BinaryTreeTraversalOrder.PRE_ORDER))
        {
            // If left child is greater than parent, we are violating BST ordering 
            if (node?.LeftChild != null && node.LeftChild.Data.Key > node.Data.Key)
                return false;

            // If right child is smaller than parent, we are violating BST ordering 
            if (node?.RightChild != null && node.RightChild.Data.Key < node.Data.Key)
                return false;

            // If the left child is greater than the right child, we are violating BST ordering
            if (node?.LeftChild != null && node?.RightChild != null && node.LeftChild.Data.Key > node.RightChild.Data.Key)
                return false;
        }

        return true;
    }
}
