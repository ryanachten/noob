using noob.Models.Graphs.Directed;

namespace noob.Algorithms;

/// <summary>
/// DFS implementation for directed graphs
/// </summary>
public class DepthFirstSearch<TNode, TEdgeData> where TNode : notnull
{
    private readonly DirectedGraph<TNode, TEdgeData> _graph;
    private readonly List<TNode> _visitedNodes = new();

    public DepthFirstSearch(DirectedGraph<TNode, TEdgeData> graph)
    {
        _graph = graph;
    }

    /// <summary>
    /// Enumerates though graph, returning descendants before neighbours
    /// </summary>
    /// <param name="node">Starting node</param>
    /// <returns>Node iterator</returns>
    public IEnumerable<TNode> Enumerate(TNode node)
    {
        _visitedNodes.Add(node);

        var edges = _graph.OutgoingEdges().Where(e => e.Source?.Equals(node) ?? false);
        yield return node;

        foreach (var edge in edges)
        {
            // If we haven't visited a node yet, recursively iterate through it's adjacent nodes
            if (!_visitedNodes.Contains(edge.Destination))
            {
                var nodes = Enumerate(edge.Destination);
                foreach (var adjacentNode in nodes)
                {
                    var test = adjacentNode.ToString();
                    yield return adjacentNode;
                }
            }
        }
    }
}
