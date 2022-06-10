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
}
