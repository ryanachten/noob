namespace noob.Models.Graphs.Undirected;

public class AdjacencyMatrix(int count)
{
    public bool[,] Nodes { get; private set; } = new bool[count, count];
}
