using noob.Models.Graphs.Directed;

namespace noob.Algorithms;

public static class BreadthFirstSearch<TNode, TEdgeData> where TNode : notnull
{
    /// <summary>
    /// Enumerates through graph in preorder
    /// </summary>
    public static IEnumerable<TNode> Enumerate(DirectedGraph<TNode, TEdgeData> graph, TNode startNode)
    {
        var visitedNodes = new List<TNode>(); // Need to track nodes we've visited to avoid repeating
        var queue = new Queue<TNode>();
        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            yield return node;

            var edges = graph.OutgoingEdges().Where(e => e.Source.Equals(node));
            foreach (var edge in edges)
            {
                if (!visitedNodes.Contains(edge.Destination))
                {
                    queue.Enqueue(edge.Destination);
                    visitedNodes.Add(edge.Destination);
                }
            }
        }
    }
}
