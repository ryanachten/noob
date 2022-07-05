using noob.Models.Graphs;
using Xunit;

namespace noob.UnitTests.Models.Graphs;

public class GivenAdjacencyList
{
    [Fact]
    public void WhenAddingToList_ThenSiblingsAndChildrenAreAddedCorrectly()
    {
        // Arrange
        var graph = new AdjacencyList<int>();

        // Act
        graph.Add(1).Add(3);
        graph.AddChild(0, 2).AddChild(0, 5);
        graph.AddChild(1, 4).AddChild(1, 6);
        /// 1 3
        /// 2 4
        /// 5 6

        // Assert
        Assert.Equal(2, graph.Nodes.Count);
        
        var firstNode = graph.Nodes.Data[0];
        Assert.Equal(1, firstNode.Value);
        Assert.Equal(2, firstNode.Children.Count);
        Assert.Equal(2, firstNode.Children.Data[0].Value);
        Assert.Equal(5, firstNode.Children.Data[1].Value);

        var secondNode = graph.Nodes.Data[1];
        Assert.Equal(3, secondNode.Value);
        Assert.Equal(2, secondNode.Children.Count);
        Assert.Equal(4, secondNode.Children.Data[0].Value);
        Assert.Equal(6, secondNode.Children.Data[1].Value);
    }

    [Fact]
    public void WhenConductingDepthFirstSearch_ThenChildNodesAreReturnedBeforeSiblings()
    {
        // Arrange
        var graph = new AdjacencyList<int>();

        // Act
        graph.Add(1).Add(2).Add(3);
        graph.AddChild(0, 4).AddChild(0, 7);
        graph.AddChild(1, 5).AddChild(1, 8);
        graph.AddChild(1, 6).AddChild(1, 9);

        /// 1 2 3
        /// 4 5 6
        /// 7 8 9

        // Assert
        var expectedNodes = new[] {1, 4, 7, 2, 5, 8, 3, 6, 9};
        var index = 0;
        foreach (var node in graph.DepthFirstSearch())
        {
            Assert.Equal(expectedNodes[index], node.Value);
            index++;
        }
    }

    [Fact]
    public void WhenConductingBreadthFirstSearch_ThenSiblingNodesAreReturnedBeforeChildren()
    {
        // Arrange
        var graph = new AdjacencyList<int>();

        // Act
        graph.Add(1).Add(2).Add(3);
        graph.AddChild(0, 4).AddChild(0, 7);
        graph.AddChild(1, 5).AddChild(1, 8);
        graph.AddChild(2, 6).AddChild(2, 9);

        /// 1 2 3
        /// 4 5 6
        /// 7 8 9

        // Assert
        var expectedNodes = new[] { 1, 2, 3, 4, 7, 5, 8, 6, 9 };
        var index = 0;
        foreach (var node in graph.BreadthFirstSearch())
        {
            Assert.Equal(expectedNodes[index], node.Value);
            index++;
        }
    }
}
