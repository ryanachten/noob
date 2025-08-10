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
    private readonly Dictionary<int, int> size = [];
    private readonly Dictionary<int, int> rank = [];

    /// <summary>
    /// Creates a new set with root in vertex v, where v is its own parent
    /// </summary>
    public void MakeSet(int vertex)
    {
        parent[vertex] = vertex;
        size[vertex] = 1;
        rank[vertex] = 0;
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
    /// (Unoptimized implementation) Finds the root of the set containing the vertex and performs path compression
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

    /// <summary>
    /// Performs union by size. Appends to root with more descendants.
    /// </summary>
    public void UnionSetsBySize(int setA, int setB)
    {
        var rootA = FindSet(setA);
        var rootB = FindSet(setB);

        if (rootA == rootB) return;

        // Ensure rootA is the root with more descendants
        if (size[rootA] < size[rootB])
        {
            (rootA, rootB) = (rootB, rootA);
        }

        // Attach rootB to rootA
        parent[rootB] = rootA;

        // Update the size of the new root
        size[rootA] += size[rootB];
    }

    /// <summary>
    /// Performs union by rank, representing the upper bound of the height of the tree.
    /// The root with higher rank becomes the parent of the root with lower rank.
    /// If ranks are equal, one root is chosen arbitrarily and its rank is incremented.
    /// </summary>
    public void UnionSetsByRank(int setA, int setB)
    {
        var rootA = FindSet(setA);
        var rootB = FindSet(setB);

        if (rootA == rootB) return;

        // Ensure rootA is the root with higher rank
        if (rank[rootA] < rank[rootB])
        {
            (rootA, rootB) = (rootB, rootA);
        }

        // Attach rootB to rootA
        parent[rootB] = rootA;

        // If ranks are equal, increment the rank of rootA
        if (rank[rootA] == rank[rootB])
        {
            rank[rootA]++;
        }
    }
}


