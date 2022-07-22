using noob.Algorithms.Searching;
using noob.Models.Graphs.Directed;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// Given a directed graph, design an algorithm to find out whether there is a
/// route between two nodes.
/// </summary>
public sealed class RouteBetweenNodes
{
    private readonly static DirectedGraph<string, int> _graph = new DirectedGraph<string, int>()
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

    public static IEnumerable<object[]> Nodes => 
        new List<object[]>
        {
            new object[] {
                "node1", "node2", true
            },
            new object[] {
                "node1", "node6", true
            },
            new object[] {
                "node1", "node3", true
            },
            new object[] {
                "node3", "node2", false
            },
            new object[] {
                "node5", "node6", false
            }
        };

    [Theory]
    [MemberData(nameof(Nodes))]
    public void WhenFindingARouteBetweenTwoNodes_ThenPossibleRoutesAreDetermined(string node1, string node2, bool expectedResult)
    {
        // Act
        var result = HasRouteBetweenNodes(node1, node2);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    private static bool HasRouteBetweenNodes(string node1, string node2)
    {
        foreach (var node in BreadthFirstSearch<string, int>.Enumerate(_graph, node1))
        {
            if(node == node2) return true;
        }

        return false;
    }
}
