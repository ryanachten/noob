namespace noob.Models.Graphs.Undirected;

public class AdjacencyListNode<T>(T value)
{
    public T Value { get; private set; } = value;
    public readonly ArrayList<AdjacencyListNode<T>> Children = new(2);

    /// <summary>
    /// Indicates whether the node has been visited part of a search yet
    /// </summary>
    public bool Visited = false;

    /// <summary>
    /// Add child to current node
    /// </summary>
    public AdjacencyListNode<T> AddChild(T value)
    {
        Children.Add(new AdjacencyListNode<T>(value));

        return this;
    }

    /// <summary>
    /// Iterates through node's children
    /// </summary>
    public IEnumerable<AdjacencyListNode<T>> DepthFirstSearch()
    {
        Visited = true;

        foreach (var child in Children.Data)
        {
            if (!Visited)
            {
                foreach (var descendent in child.DepthFirstSearch())
                {
                    yield return descendent;
                }
            }
        }
    }
}
