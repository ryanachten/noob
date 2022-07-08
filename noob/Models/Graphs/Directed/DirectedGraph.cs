namespace noob.Models.Graphs.Directed;

/// <summary>
/// Directed graph implemented using a combination of adjacency list and matrix
/// </summary>
/// <typeparam name="TNode">Graph node value type</typeparam>
/// <typeparam name="TEdgeData">Graph edge value type</typeparam>
public class DirectedGraph<TNode, TEdgeData> where TNode : notnull
{
    /// <summary>
    /// Map of nodes and their adjacent nodes
    /// </summary>
    private readonly Dictionary<TNode, LinkedList<TNode>> _adjacencyLists = new();

    /// <summary>
    /// Tuple of ordered node/edge pairs
    /// </summary>
    private readonly Dictionary<(TNode, TNode), TEdgeData> _edges = new();

    /// <summary>
    /// Adds a node to the graph
    /// </summary>
    /// <param name="node"></param>
    public DirectedGraph<TNode, TEdgeData> AddNode(TNode node) { 
        _adjacencyLists.Add(node, new LinkedList<TNode>());

        return this;
    }

    /// <summary>
    /// Adds an edge between two nodes
    /// </summary>
    /// <param name="source">Source node</param>
    /// <param name="dest">Destination node</param>
    /// <param name="value">Data to assign to the edge</param>
    /// <exception cref="ArgumentException"></exception>
    public DirectedGraph<TNode, TEdgeData> AddEdge(TNode source, TNode dest, TEdgeData value)
    {
        if (source.Equals(dest)) throw new ArgumentException("Source and destination nodes cannot be the same");

        // If source or dest don't exist yet, add them
        if (!_adjacencyLists.ContainsKey(source)) AddNode(source);
        if (!_adjacencyLists.ContainsKey(dest)) AddNode(dest);

        // Add the edge for resource and dest with associated value
        _edges.Add((source, dest), value);

        // Add dest to source's adjacent nodes
        _adjacencyLists.TryGetValue(source, out LinkedList<TNode>? adjacentList);
        adjacentList?.AddFirst(dest);

        return this;
    }

    /// <summary>
    /// Tries to get an edge in the graph
    /// </summary>
    /// <param name="source">Source node</param>
    /// <param name="dest">Destination node</param>
    /// <param name="value">Data assigned to the edge</param>
    /// <returns></returns>
    public bool TryGetEdge(TNode source, TNode dest, out TEdgeData? value) => _edges.TryGetValue((source, dest), out value);

    /// <summary>
    /// Returns all the nodes in the graph
    /// </summary>
    public IEnumerable<TNode> Nodes => _adjacencyLists.Keys;

    /// <summary>
    /// Returns all the edges in the graph
    /// </summary>
    public IEnumerable<Edge<TNode, TEdgeData>> OutgoingEdges()
    {
        foreach (var node in _adjacencyLists)
        {
            foreach (var adjacentNode in node.Value)
            {
                _edges.TryGetValue((node.Key, adjacentNode), out TEdgeData? edge);
                yield return new Edge<TNode, TEdgeData>(node.Key, adjacentNode, edge);
            }
        }
    }
}

