using noob.Algorithms;
using noob.Models.Graphs.Directed;
using Xunit;

namespace noob.UnitTests.Algorithms;

public class GivenDirectionalGraph
{
    private DirectedGraph<string, int> _unweightedGraph;
    private DirectedGraph<string, int> _weightedGraph;

    public GivenDirectionalGraph()
    {
        _unweightedGraph = new DirectedGraph<string, int>()
            .AddNode("node1").AddNode("node2")
            .AddNode("node3").AddNode("node4")
            .AddNode("node5").AddNode("node6")
            .AddEdge("node1", "node2", 1)
            .AddEdge("node1", "node3", 1)
            .AddEdge("node2", "node4", 1)
            .AddEdge("node3", "node4", 1)
            .AddEdge("node3", "node5", 1)
            .AddEdge("node4", "node6", 1)
            .AddEdge("node5", "node6", 1);
        /// 1 --> 2
        /// |     |
        /// V     V
        /// 3 --> 4
        /// |     |
        /// V     V
        /// 5 --> 6

        _weightedGraph = new DirectedGraph<string, int>()
            .AddNode("node1").AddNode("node2")
            .AddNode("node3").AddNode("node4")
            .AddNode("node5").AddNode("node6")
            .AddEdge("node1", "node2", 5)
            .AddEdge("node1", "node3", 1)
            .AddEdge("node2", "node4", 1)
            .AddEdge("node3", "node4", 1)
            .AddEdge("node3", "node5", 1)
            .AddEdge("node4", "node6", 3)
            .AddEdge("node5", "node6", 1);
        ///    5
        /// 1 --> 2
        /// |     |
        /// V     V
        /// 3 --> 4
        /// |     | 3
        /// V     V
        /// 5 --> 6
    }

    [Theory]
    [InlineData("node1", "node1", null)]
    [InlineData("node1", "nonexistingnode", null)]
    [InlineData("node1", "node2", new[] { "node1", "node2" })]
    [InlineData("node1", "node4", new[] { "node1", "node2", "node4" })]
    [InlineData("node1", "node6", new[] { "node1", "node2", "node4", "node6" })]
    public void WhenFindingShortestPathInUnWeightedGraph_ThenCorrectPathIsReturned(string startNode, string endNode, string[]? expectedResult)
    {
        // Arrange
        var dijkstra = new Dijkstra<string>(_unweightedGraph);

        // Act
        var result = dijkstra.ShortestPath(startNode, endNode)?.ToArray();

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("node1", "node2", new[] { "node1", "node2" })]
    [InlineData("node1", "node4", new[] { "node1", "node3", "node4" })]
    [InlineData("node1", "node6", new[] { "node1", "node3", "node5", "node6" })]
    public void WhenFindingShortestPathInWeightedGraph_ThenCorrectPathIsReturned(string startNode, string endNode, string[]? expectedResult)
    {
        // Arrange
        var dijkstra = new Dijkstra<string>(_weightedGraph);

        // Act
        var result = dijkstra.ShortestPath(startNode, endNode)?.ToArray();

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
