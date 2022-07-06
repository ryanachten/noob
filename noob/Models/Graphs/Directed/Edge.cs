namespace noob.Models.Graphs.Directed;

public class Edge<TNode, TEdgeData>
{
    public TNode Source { get; set; }
    public TNode Destination { get; set; }
    public TEdgeData? Value { get; set; }

    public Edge(TNode source, TNode destination, TEdgeData? value)
    {
        Source = source;
        Destination = destination;
        Value = value;
    }
}
