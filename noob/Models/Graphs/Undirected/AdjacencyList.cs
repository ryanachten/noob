namespace noob.Models.Graphs.Undirected;

public class AdjacencyList<T>
{
    public readonly ArrayList<AdjacencyListNode<T>> Nodes = new(3);

    /// <summary>
    /// Adds sibling to list
    /// </summary>
    public AdjacencyList<T> Add(T value)
    {
        Nodes.Add(new AdjacencyListNode<T>(value));

        return this;
    }

    /// <summary>
    /// Add a child to an existing node
    /// </summary>
    /// <param name="index">Node index</param>
    /// <param name="value">Value to be added</param>
    public AdjacencyList<T> AddChild(int index, T value)
    {
        if(index > Nodes.Count - 1)
        {
            throw new ArgumentException("Cannot add child to index which doesn't exist");
        }

        Nodes.Data[index].AddChild(value);
        
        return this;
    }

    /// <summary>
    /// Iterates through each node's children completely before moving to next sibling node
    /// </summary>
    public IEnumerable<AdjacencyListNode<T>> DepthFirstSearch()
    {
        foreach (var item in Nodes.Data)
        {
            foreach (var child in item.DepthFirstSearch())
            {
                yield return child;
            }
        }
    }

    /// <summary>
    /// Iterates through each node's siblings before moving through their children
    /// </summary>
    public IEnumerable<AdjacencyListNode<T>> BreadthFirstSearch()
    {
        var queue = new Queue.Queue<AdjacencyListNode<T>>();

        foreach (var node in Nodes.Data)
        {
            node.Visited = true;
            queue.Enqueue(node);
        }

        while (!queue.IsEmpty())
        {
            var firstNode = queue.Dequeue()?.Data;
            if (firstNode != null)
            {
                yield return firstNode;

                foreach (var child in firstNode.Children.Data)
                {
                    if (child != null && !child.Visited)
                    {
                        child.Visited = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Reset graph node state
    /// </summary>
    public void Reset()
    {
        foreach (var node in Nodes.Data)
        {
            node.Visited = false;

            foreach (var child in node.Children.Data)
            {
                child.Visited = false;
            }
        }
    }
}
