using noob.Models;
using Xunit;

namespace noob.UnitTests.Models.LinkedLists;

public class GivenValidDoublyLinkedList
{
    [Fact]
    public void WhenAppendingData_ThenDataIsAdded()
    {
        // Arrange
        var list = new DoublyLinkedList(100);

        // Act
        list.Append(20).Append(0);

        // Assert
        var node1 = list.Head;
        var node2 = node1.Next;
        var node3 = node2?.Next;

        Assert.Equal(100, node1.Data);
        Assert.Equal(node1.Next, node2);
        Assert.Null(node1.Previous);

        Assert.Equal(20, node2?.Data);
        Assert.Equal(node2?.Next, node3);
        Assert.Equal(node2?.Previous, node1);

        Assert.Equal(0, node3?.Data);
        Assert.Null(node3?.Next);
        Assert.Equal(node3?.Previous, node2);
    }

    [Fact]
    public void WhenDeletingData_ThenDataIsRemoved()
    {
        // Arrange
        var list = new DoublyLinkedList(100).Append(20).Append(0);

        // Act
        list.Delete(20);

        // Assert
        var node1 = list.Head;
        var node2 = node1.Next;

        Assert.Equal(100, node1.Data);
        Assert.Equal(node1.Next, node2);
        Assert.Null(node1.Previous);

        Assert.Equal(0, node2?.Data);
        Assert.Null(node2?.Next);
        Assert.Equal(node2?.Previous, node1);
    }

    [Fact]
    public void WhenDeletingHeadNode_ThenHeadNodeIsRemoved()
    {
        // Arrange
        var list = new DoublyLinkedList(100).Append(20).Append(0);

        // Act
        list.Delete(100);

        // Assert
        var node1 = list.Head;
        var node2 = node1.Next;

        Assert.Equal(20, node1.Data);
        Assert.Equal(node1.Next, node2);
        Assert.Null(node1.Previous);

        Assert.Equal(0, node2?.Data);
        Assert.Null(node2?.Next);
        Assert.Equal(node2?.Previous, node1);
    }
}
