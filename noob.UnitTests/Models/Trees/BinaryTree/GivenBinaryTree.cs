using noob.Constants.Enums;
using noob.Models.Trees.BinaryTree;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Models.Trees.BinaryTree;

public class GivenBinaryTree
{
    private readonly BinarySearchTree<int, string> _binarySearchTree;

    public GivenBinaryTree()
    {
        var bst = new BinarySearchTree<int, string>();
        bst.Add(6, "root");
        bst.Add(4, "root.lc");
        bst.Add(8, "root.rc");
        bst.Add(3, "root.lc.lc");
        bst.Add(5, "root.lc.rc");
        bst.Add(7, "root.rc.lc");
        bst.Add(9, "root.rc.rc");

        _binarySearchTree = bst;
    }

    public static IEnumerable<object[]> Trees()
    {
        ///     4
        ///     /\
        ///    6  2
        var tree1a = new BinaryTree<int, int>();
        tree1a.Add(4, 4);
        tree1a.Add(6, 6);
        tree1a.Add(2, 2);

        // TODO: add clone method
        var tree1b = new BinaryTree<int, int>();
        tree1b.Add(4, 4);
        tree1b.Add(6, 6);
        tree1b.Add(2, 2);

        ///     4
        ///     /
        ///    6 
        var tree2 = new BinaryTree<int, int>();
        tree2.Add(4, 4);
        tree2.Add(6, 6);

        ///     2
        ///     /
        ///    6
        var tree3 = new BinaryTree<int, int>();
        tree3.Add(2, 2);
        tree3.Add(6, 6);

        ///     4
        ///     /\
        ///    6  2
        ///   /\  /\
        ///  1  3 5 7
        var tree4 = new BinaryTree<int, int>();
        tree4.Add(4, 4);
        tree4.Add(6, 6);
        tree4.Add(2, 2);
        tree4.Add(1, 1, tree4.Root!.LeftChild!);
        tree4.Add(3, 3, tree4.Root!.LeftChild!);
        tree4.Add(5, 5, tree4.Root!.RightChild!);
        tree4.Add(7, 7, tree4.Root!.RightChild!);

        ///     4
        ///     /\
        ///    6  7
        ///   /\  /
        ///  1  3 5 
        var tree5 = new BinaryTree<int, int>();
        tree5.Add(4, 4);
        tree5.Add(6, 6);
        tree5.Add(7, 7);
        tree5.Add(1, 1, tree5.Root!.LeftChild!);
        tree5.Add(3, 3, tree5.Root!.LeftChild!);
        tree5.Add(5, 5, tree5.Root!.RightChild!);

        return new List<object[]>
        {
            new object[] {
                tree1a, 2, true, tree2
            },
            new object[] {
                tree1b, 4, true, tree3
            },
            new object[] {
                tree4, 2, true, tree5
            }
        };
     }

        [Fact]
    public void WhenTraversingTreeInOrder_ThenTreeIsTraversedLeftCurrentRight()
    {
        // Arrange
        var expectedOrder = new string[] { "root.lc.lc", "root.lc", "root.lc.rc", "root", "root.rc.lc", "root.rc", "root.rc.rc"};

        // Assert
        var index = 0;
        foreach (var item in _binarySearchTree.Items())
        {
            Assert.Equal(expectedOrder[index], item?.Data.Value);
            index++;
        }
    }

    [Fact]
    public void WhenTraversingTreeInPreOrder_ThenTreeIsTraversedCurrentLeftRight()
    {
        // Arrange
        var expectedOrder = new string[] { "root", "root.lc", "root.lc.lc", "root.lc.rc", "root.rc", "root.rc.lc", "root.rc.rc" };

        // Assert
        var index = 0;
        foreach (var item in _binarySearchTree.Items(BinaryTreeTraversalOrder.PRE_ORDER))
        {
            Assert.Equal(expectedOrder[index], item?.Data.Value);
            index++;
        }
    }

    [Fact]
    public void WhenTraversingTreeInPostOrder_ThenTreeIsTraversedLeftRightCurrent()
    {
        // Arrange
        var expectedOrder = new string[] { "root.lc.lc", "root.lc.rc", "root.lc", "root.rc.lc", "root.rc.rc", "root.rc", "root" };

        // Assert
        var index = 0;
        foreach (var item in _binarySearchTree.Items(BinaryTreeTraversalOrder.POST_ORDER))
        {
            Assert.Equal(expectedOrder[index], item?.Data.Value);
            index++;
        }
    }

    [Theory]
    [MemberData(nameof(Trees))]
    public void WhenRemovingNodesFromTree_ThenNodesAreRemovedAndUpdatedAsExpected(
        BinaryTree<int, int> tree, int keyToRemove, bool expectedResult, BinaryTree<int, int> expectedTree)
    {
        // Act
        var result = tree.Remove(keyToRemove);

        // Assert
        Assert.Equal(expectedResult, result);

        var expectedItems = expectedTree.Items(BinaryTreeTraversalOrder.PRE_ORDER);
        var items = tree.Items(BinaryTreeTraversalOrder.PRE_ORDER);

        Assert.Equal(expectedItems.Count(), items.Count());

        for (int i = 0; i < expectedItems.Count(); i++)
        {
            var node1 = expectedItems.ElementAt(i);
            var node2 = items.ElementAt(i);
            Assert.True(node1?.Equals(node2));
        }
    }
}
