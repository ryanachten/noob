using noob.Constants.Enums;
using noob.Models.Trees.BinaryTree;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// Tl and T2 are two very large binary trees, with Tl much bigger than T2. Create an
/// algorithm to determine if T2 is a subtree of Tl.
/// </summary>
public class CheckSubtree
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
        ///    6  2
        ///   /\  /\
        ///  1  3 5 8
        var tree2 = new BinaryTree<int, int>();
        tree2.Add(4, 4);
        tree2.Add(6, 6);
        tree2.Add(2, 2);
        tree2.Add(1, 1);
        tree2.Add(3, 3);
        tree2.Add(5, 5);
        tree2.Add(8, 8);

        ///     4
        ///     /\
        ///    6  2
        ///   /\  /\
        ///  1  3 5 7
        ///          \
        ///           8
        var tree3 = new BinaryTree<int, int>();
        tree3.Add(4, 4);
        tree3.Add(6, 6);
        tree3.Add(2, 2);
        tree3.Add(1, 1);
        tree3.Add(3, 3);
        tree3.Add(5, 5);
        tree3.Add(7, 7);
        tree3.Add(8, 8);

        ///     4
        ///     /\
        ///    6  2
        ///   /
        ///  1 
        var tree4 = new BinaryTree<int, int>();
        tree4.Add(4, 4);
        tree4.Add(6, 6);
        tree4.Add(2, 2);
        tree4.Add(1, 1, tree4.Root!.LeftChild!);

        ///     4
        ///     /\
        ///    6  2
        ///      /
        ///     1
        var tree5 = new BinaryTree<int, int>();
        tree5.Add(4, 4);
        tree5.Add(6, 6);
        tree5.Add(2, 2);
        tree5.Add(1, 1, tree5.Root!.RightChild!);

        return new List<object[]>
        {
            new object[] {
                tree1, new BinaryTree<int, int>(tree1.Root!.LeftChild!), true
            },
            new object[] {
                tree1, tree2, false
            },
            new object[] {
                tree1, tree3, false
            },
            new object[] {
                tree4, tree5, false
            }
        };
    }

    [Theory]
    [MemberData(nameof(Trees))]
    public void WhenDeterminingIfATreeIsASubtree_ThenSubtreeIsDetermined(
        BinaryTree<int, int> tree, BinaryTree<int, int> subtree, bool expectedResult)
    {
        // Act
        var result = IsSubtree(tree, subtree);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    private static bool IsSubtree(BinaryTree<int, int> tree, BinaryTree<int, int> tree2)
    {
        BinaryTree<int, int>? subTree = null; 
        foreach (var node in tree.Items(BinaryTreeTraversalOrder.PRE_ORDER))
        {
            if (node != null && node.Equals(tree2.Root))
            {
                subTree = new BinaryTree<int, int>(node);
            }
        }

        if (subTree == null) return false;

        var treesMatch = true;
        // This isn't a good idea for large trees since we're loading them both into memory
        // TODO: find a better way
        var nodes1 = NullablePreOrderTraversal(subTree.Root);
        var nodes2 = NullablePreOrderTraversal(tree2.Root);

        if(nodes1.Count() != nodes2.Count()) return false;

        for (int i = 0; i < nodes1.Count(); i++)
        {   
            var node1 = nodes1.ElementAt(i);
            var node2 = nodes2.ElementAt(i);

            if(node1 != null && !node1.Equals(node2))
            {
                treesMatch = false;
                break;
            }
        }

        return treesMatch;
    }

    /// <summary>
    /// We need to represent null values in the output as part of our tree comparison
    /// otherwise nodes being on different branches can be confused, leading to false positives
    /// </summary>
    private static IEnumerable<BinaryTreeNode<int, int>?> NullablePreOrderTraversal(BinaryTreeNode<int, int>? node)
    {
        if(node != null)
        {
            yield return node;

            foreach (var child in NullablePreOrderTraversal(node?.LeftChild))
            {
                yield return child;
            }

            foreach (var child in NullablePreOrderTraversal(node?.RightChild))
            {
                yield return child;
            }
        } else
        {
            yield return null;
        }
    }
}
