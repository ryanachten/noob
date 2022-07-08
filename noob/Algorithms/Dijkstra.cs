using noob.Models.Graphs.Directed;

namespace noob.Algorithms;

public class Dijkstra<TNode> where TNode : notnull
{
    /// <summary>
    /// Edges eligible for review
    /// </summary>
    private readonly DirectedGraph<TNode, int> _graph;

    /// <param name="targetNode">Target node to find shortest path for</param>
    public Dijkstra(DirectedGraph<TNode, int> graph)
    {
        _graph = graph;
    }

    public List<TNode>? ShortestPath(TNode sourceNode, TNode targetNode)
    {
        var distances = new Dictionary<TNode, double>();
        var previousNodes = new Dictionary<TNode, TNode>();
        var localNodes = new List<TNode>();

        // Copy nodes and set distance to infinity as it's currently unknown
        foreach (var node in _graph.Nodes)
        {
            localNodes.Add(node);
            distances.Add(node, double.PositiveInfinity);
        }

        distances[sourceNode] = 0; // distance to source node is always 0

        while (localNodes.Count > 0)
        {
            var minNode = localNodes.OrderBy(n => distances[n]).First(); // TODO: we could probably use a priority queue here instead
            localNodes.Remove(minNode);

            var edges = _graph.OutgoingEdges();
            var neighbours = edges.Where(x => x.Source.Equals(minNode));
            foreach (var edge in neighbours)
            {
                // If the distance from the min node to the current destination is shorter
                // then update distance and previous entries
                var distance = distances[minNode] + edge.Value;
                if(distance < distances[edge.Destination])
                {
                    distances[edge.Destination] = distance;
                    previousNodes[edge.Destination] = minNode;
                }
            }

            // If we're at the end node, we can stop looking
            if (minNode.Equals(targetNode))
            {
                break;
            }
        }

        // Construct the path to the target node
        var path = new List<TNode>();
        var currentNode = targetNode;
        while (previousNodes.ContainsKey(currentNode))
        {
            path.Add(currentNode);
            currentNode = previousNodes[currentNode];
        }
        path.Add(sourceNode);
        path.Reverse(); // reverse the path to be in chronological order

        return path.Count > 1 ? path : null;
    }
}


