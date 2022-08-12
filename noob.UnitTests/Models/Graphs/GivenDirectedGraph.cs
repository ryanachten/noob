using noob.Models.Graphs.Directed;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Models.Graphs;

public class GivenDirectedGraph
{
    [Fact]
    public void WhenAddingNode_ThenNodeIsAdded()
    {
        // Arrange
        var graph = new DirectedGraph<int, string>();

        // Act
        graph.AddNode(1).AddNode(2).AddNode(3);

        // Assert
        Assert.Equal(3, graph.Nodes.Count());
        Assert.Contains(1, graph.Nodes);
        Assert.Contains(2, graph.Nodes);
        Assert.Contains(3, graph.Nodes);
    }

    [Fact]
    public void WhenAddingEdge_ThenEdgeIsAdded()
    {
        // Arrange
        var graph = new DirectedGraph<int, string>();
        graph.AddNode(1).AddNode(2);

        // Act
        graph.AddEdge(1, 2, "edge 1").AddEdge(2, 1, "edge 2");
        graph.AddEdge(2, 3, "edge 3"); // node 3 doesn't exist but should be added

        // Assert
        Assert.Equal(3, graph.Nodes.Count());
        Assert.Contains(1, graph.Nodes);
        Assert.Contains(2, graph.Nodes);
        Assert.Contains(3, graph.Nodes);

        Assert.Equal(3, graph.OutgoingEdges().Count());
        Assert.True(graph.TryGetEdge(1, 2, out string? edge1Value));
        Assert.Equal("edge 1", edge1Value);
        Assert.True(graph.TryGetEdge(2, 1, out string? edge2Value));
        Assert.Equal("edge 2", edge2Value);
        Assert.True(graph.TryGetEdge(2, 3, out string? edge3Value));
        Assert.Equal("edge 3", edge3Value);
    }
}
