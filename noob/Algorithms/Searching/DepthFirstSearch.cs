using noob.Models.Graphs.Directed;

namespace noob.Algorithms.Searching;

/// <summary>
/// DFS implementation for directed graphs
/// </summary>
public class DepthFirstSearch<TNode, TEdgeData>(DirectedGraph<TNode, TEdgeData> graph) where TNode : notnull
{
    private readonly List<TNode> _visitedNodes = [];

    /// <summary>
    /// Enumerates though graph, returning descendants before neighbours
    /// </summary>
    /// <param name="node">Starting node</param>
    /// <returns>Node iterator</returns>
    public IEnumerable<TNode> Enumerate(TNode node)
    {
        _visitedNodes.Add(node);

        var edges = graph.OutgoingEdges().Where(e => e.Source?.Equals(node) ?? false);
        yield return node;
        foreach (var edge in edges.Where(
        // If we haven't visited a node yet, recursively iterate through it's adjacent nodes
        edge => !_visitedNodes.Contains(edge.Destination)))
        {
            var nodes = Enumerate(edge.Destination);
            foreach (var adjacentNode in nodes)
            {
                yield return adjacentNode;
            }
        }
    }
}
