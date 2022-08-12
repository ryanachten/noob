using noob.Models;
using Xunit;

namespace noob.Tests.Models.ArrayLists;

public class GivenValidArrayList
{
    [Fact]
    public void WhenAddingElements_ThenElementIsAddedSuccessfully()
    {
        // Arrange
        var array = new ArrayList<int>(10);
        
        // Act
        array.Add(1).Add(2);

        // Assert
        Assert.Equal(2, array.Count);
        Assert.Equal(1, array.Data[0]);
        Assert.Equal(2, array.Data[1]);
    }

    [Fact]
    public void WhenArrayExceedsCapacity_ThenArrayIsResizedToIncreaseCapacity()
    {
        // Arrange
        var array = new ArrayList<int>(2);

        // Act
        array.Add(1).Add(2).Add(3); // 3 items exceeds initial capacity of 2

        // Assert
        Assert.Equal(3, array.Count);
        Assert.Equal(1, array.Data[0]);
        Assert.Equal(2, array.Data[1]);
        Assert.Equal(3, array.Data[2]);
    }

    [Fact]
    public void WhenDeletingElements_ThenElementIsDeletedSuccessfully()
    {
        // Arrange
        var array = new ArrayList<int>(10);
        array.Add(1).Add(2).Add(3).Add(4);

        // Act
        array.Delete(2);

        // Assert
        Assert.Equal(3, array.Count);
        Assert.Equal(4, array.Data[2]);
    }

    [Fact]
    public void WhenDeletingTheLastIndex_ThenElementIsDeletedSuccessfully()
    {
        // Arrange
        var array = new ArrayList<int>(10);
        array.Add(1).Add(2).Add(3).Add(4);

        // Act
        array.Delete(3);

        // Assert
        Assert.Equal(3, array.Count);
        Assert.Equal(default, array.Data[3]);
    }

    [Fact]
    public void WhenDeletingAnInvalidIndex_ThenNoDataIsModified()
    {
        // Arrange
        var array = new ArrayList<int>(10);
        array.Add(1).Add(2).Add(3).Add(4);

        // Act
        array.Delete(4);

        // Assert
        Assert.Equal(4, array.Count);
        Assert.Equal(4, array.Data[3]);
    }
}
