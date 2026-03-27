namespace noob.Models.Graphs.Directed;

public class Edge<TNode, TEdgeData>(TNode source, TNode destination, TEdgeData? value)
{
    public TNode Source { get; set; } = source;
    public TNode Destination { get; set; } = destination;
    public TEdgeData? Value { get; set; } = value;
}
