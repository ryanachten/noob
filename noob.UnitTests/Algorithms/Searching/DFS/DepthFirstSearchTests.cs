﻿using noob.Algorithms.Searching;
using noob.Models.Graphs.Directed;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Algorithms.Searching;

public class DepthFirstSearchTests
{
    [Fact]
    public void WhenEnumeratingThroughDirectionalGraph_ThenNodesAreReturnedInCorrectOrder()
    {
        var graph = new DirectedGraph<string, int>()
            .AddNode("node1").AddNode("node2")
            .AddNode("node3").AddNode("node4")
            .AddNode("node5").AddNode("node6")
            .AddEdge("node1", "node2", 1)
            .AddEdge("node1", "node3", 1)
            .AddEdge("node2", "node4", 1)
            .AddEdge("node3", "node5", 1)
            .AddEdge("node4", "node6", 1);
        /// 1 --> 2
        /// |     |
        /// V     V
        /// 3     4
        /// |     |
        /// V     V
        /// 5     6

        var dfs = new DepthFirstSearch<string, int>(graph);

        // Assert
        var expectedNodes = new[] { "node1", "node3", "node5", "node2", "node4", "node6" };
        var index = 0;
        foreach (var node in dfs.Enumerate(graph.Nodes.First()))
        {
            Assert.Equal(expectedNodes[index], node);
            index++;
        }
    }
}
