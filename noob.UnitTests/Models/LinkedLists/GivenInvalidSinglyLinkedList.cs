using noob.Models.LinkedList;
using System;
using Xunit;

namespace noob.UnitTests.Models.LinkedLists;

public class GivenInvalidSinglyLinkedList
{
    [Fact]
    public void WhenDeletingDataWithNoNextNodeAssigned_ThenExceptionIsThrown()
    {
        // Arrange
        var list = new SinglyLinkedList<int>(100);

        // Act
        var ex = Assert.Throws<Exception>(() => list.Delete(100));
        Assert.Equal("Cannot delete head - no next node has been assigned", ex.Message);
    }
}
