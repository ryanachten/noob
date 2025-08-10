using noob.Models.Trees.DisjointSetUnion;
using Xunit;

namespace noob.UnitTests.Exercises.NeetCode;

public class RedundantConnection
{
    public static TheoryData<int[][], int[]> Connections() => new()
    {
        { [[1, 2], [2, 3], [3, 1]], [3, 1] },
        { [[1, 2], [1, 3], [3, 4], [2, 4]], [2, 4] },
        { [[1, 2], [1, 3], [1, 4], [3, 4], [4, 5]], [3, 4] },
        { [[3,4],[1,2],[2,4],[3,5],[2,5]], [2,5]}
    };

    [Theory]
    [MemberData(nameof(Connections))]
    public void GivenConnections_WhenFindingRedundantConnection_ThenTheCorrectEdgeIsReturned(int[][] edges, int[] expected)
    {
        var result = FindRedundantConnection(edges);
        Assert.Equal(expected, result);
    }

    private static int[] FindRedundantConnection(int[][] edges)
    {
        var dsu = new DisjointSetUnion();
        // Initialize the disjoint set for each vertex in the edges
        foreach (var edge in edges)
        {
            var setA = edge[0];
            var setB = edge[1];
            dsu.MakeSet(setA);
            dsu.MakeSet(setB);

            // If the union operation returns false, it means the edge creates a cycle
            if (dsu.UnionSetsByRank(setA, setB))
            {
                return edge;
            }
        }

        return [];
    }
}