namespace noob.Models.Trees.DisjointSetUnion;

/// <summary>
/// Disjoint Set Union (DSU) or Union-Find data structure
/// It is used to keep track of a set of elements partitioned into disjoint (non-overlapping) subsets.
/// It supports two primary operations: 
/// 1. Find: Determine which subset a particular element is in.
/// 2. Union: Merge two subsets into a single subset.
/// <link>https://cp-algorithms.com/data_structures/disjoint_set_union.html</link>
/// </summary>
public class DisjointSetUnion
{
    private readonly Dictionary<int, int> parent = [];

    /// <summary>
    /// Creates a new set with root in vertex v, where v is its own parent
    /// </summary>
    public void MakeSet(int vertex)
    {
        parent[vertex] = vertex;
    }

    /// <summary>
    /// Recursively climbs the parent of the vertex until it reaches the root of a given set
    /// </summary>
    public int FindSet(int vertex)
    {
        if (vertex == parent[vertex]) return vertex;

        return FindSet(parent[vertex]);
    }

    /// <summary>
    /// Finds the root of the set containing the vertex and performs path compression
    /// By pointing the two vertices to the same root, we flatten the structure
    /// </summary>
    public void UnionSets(int setA, int setB)
    {
        var rootA = FindSet(setA);
        var rootB = FindSet(setB);

        if (rootA != rootB)
        {
            parent[rootB] = rootA;
        }
    }
}
