namespace noob.Models.Graphs;

public class AdjacencyMatrix
{
    public bool[,] Nodes { get; private set; }

    public AdjacencyMatrix(int count)
    {
        Nodes = new bool[count, count];
    }
}
