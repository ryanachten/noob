using noob.Constants.Enums;
using noob.Models.Trees;
using Xunit;

namespace noob.UnitTests.Models.Trees;

public class GivenBinaryTree
{
    private readonly BinarySearchTree<int, string> _tree;

    public GivenBinaryTree()
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
    public void WhenTraversingTreeInOrder_ThenTreeIsTraversedLeftCurrentRight()
    {
        // Arrange
        var expectedOrder = new string[] { "root.lc.lc", "root.lc", "root.lc.rc", "root", "root.rc.lc", "root.rc", "root.rc.rc"};

        // Assert
        var index = 0;
        foreach (var item in _tree.Items())
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
        foreach (var item in _tree.Items(BinaryTreeTraversalOrder.PRE_ORDER))
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
        foreach (var item in _tree.Items(BinaryTreeTraversalOrder.POST_ORDER))
        {
            Assert.Equal(expectedOrder[index], item?.Data.Value);
            index++;
        }
    }
}
