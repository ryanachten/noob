using noob.Constants.Enums;
using noob.Models.Trees.BinaryTree;
using System;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// Implement a function to check if a binary tree is balanced. For the purposes of
/// this question, a balanced tree is defined to be a tree such that the heights of the two subtrees of any
/// node never differ by more than one.
/// </summary>
public class CheckBalanced
{
    public static IEnumerable<object[]> Trees()
    {
        var tree1 = new BinarySearchTree<int, int>();
        ///     4
        ///     /\
        ///    2  6
        ///   /\  /\
        ///  1  3 5 7
        tree1.Add(4, 4);
        tree1.Add(2, 2);
        tree1.Add(6, 6);
        tree1.Add(1, 1);
        tree1.Add(5, 5);
        tree1.Add(3, 3);
        tree1.Add(7, 7);

        var tree2 = new BinarySearchTree<int, int>();
        ///     4
        ///     /\
        ///    2  6
        ///   /\ 
        ///  1  3
        tree2.Add(4, 4);
        tree2.Add(2, 2);
        tree2.Add(6, 6);
        tree2.Add(1, 1);
        tree2.Add(3, 3);

        var tree3 = new BinarySearchTree<int, int>();
        ///     5
        ///     /\
        ///    4  6
        ///   /\ 
        ///  2  3
        /// /
        /// 1
        tree3.Add(5, 5);
        tree3.Add(4, 4);
        tree3.Add(6, 6);
        tree3.Add(2, 2);
        tree3.Add(3, 3);
        tree3.Add(1, 1);

        return new List<object[]>
        {
            new object[] {
                tree1, true
            },
            new object[] {
                tree2, true
            },
            new object[] {
                tree3, false
            }
        };
    }

    [Theory]
    [MemberData(nameof(Trees))]
    public void WhenCheckingIfTreeIsBalanced_ThenCorrectResultIsReturned(
        BinarySearchTree<int, int> tree, bool expectedResult)
    {
        // Act
        var isBalanced = HasSimilarHeight(tree);

        // Assert
        Assert.Equal(expectedResult, isBalanced);
    }

    /// <summary>
    /// Returns if the subtree height deviates by more than a factor of 1
    /// </summary>
    /// <param name="tree"></param>
    /// <returns></returns>
    private static bool HasSimilarHeight(BinaryTree<int, int> tree)
    {
        foreach (var node in tree.Items(BinaryTreeTraversalOrder.PRE_ORDER))
        {
            var leftHeight = tree.GetHeight(node?.LeftChild);
            var rightHeight = tree.GetHeight(node?.RightChild);
            if(Math.Abs(leftHeight - rightHeight) > 1)
            {
                return false;
            }
        }
        return true;
    }
}
