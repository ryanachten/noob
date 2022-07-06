namespace noob.Models.Graphs.Undirected;

public class AdjacencyMatrix
{
    public bool[,] Nodes { get; private set; }

    public AdjacencyMatrix(int count)
    {
        Nodes = new bool[count, count];
    }
}
