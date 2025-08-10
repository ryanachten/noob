using Xunit;
using noob.Models.Trees.DisjointSetUnion;

namespace noob.UnitTests.Models.Trees.DisjointSetUnionTests;

public class GivenVertices
{
    [Fact]
    public void WhenCreatingASet_ThenTheSetCanBeFound()
    {
        var dsu = new DisjointSetUnion();
        dsu.MakeSet(1);
        dsu.MakeSet(2);

        Assert.Equal(1, dsu.FindSet(1));
        Assert.Equal(2, dsu.FindSet(2));
    }

    [Fact]
    public void WhenCreatingAUnionOfTwoSets_ThenTheParentShouldBeTheSame()
    {
        var dsu = new DisjointSetUnion();
        dsu.MakeSet(1);
        dsu.MakeSet(2);
        dsu.UnionSets(1, 2);

        Assert.Equal(1, dsu.FindSet(1));
        Assert.Equal(1, dsu.FindSet(2));
    }

    [Fact]
    public void WhenCreatingAUnionOfWithACycle_ThenTheCycleIsDetected()
    {
        var dsu = new DisjointSetUnion();
        dsu.MakeSet(1);
        dsu.MakeSet(2);
        Assert.False(dsu.UnionSets(1, 2));
        Assert.True(dsu.UnionSets(2, 1));
    }

    [Fact]
    public void WhenCreatingAUnionOfTwoSetsBySize_ThenTheParentShouldBeSetWithHigherSize()
    {
        var dsu = new DisjointSetUnion();
        dsu.MakeSet(1);
        dsu.MakeSet(2);
        dsu.MakeSet(3);

        dsu.UnionSetsBySize(2, 3); // Set contains 2, 3, 2 has a size of 2
        dsu.UnionSetsBySize(1, 2); // Set 1 contains size 1, should be merged into set 2

        Assert.Equal(2, dsu.FindSet(1));
        Assert.Equal(2, dsu.FindSet(2));
        Assert.Equal(2, dsu.FindSet(3));
    }

    [Fact]
    public void WhenCreatingAUnionBySizeWithACycle_ThenTheCycleIsDetected()
    {
        var dsu = new DisjointSetUnion();
        dsu.MakeSet(1);
        dsu.MakeSet(2);
        Assert.False(dsu.UnionSetsBySize(1, 2));
        Assert.True(dsu.UnionSetsBySize(2, 1));
    }

    [Fact]
    public void WhenCreatingAUnionOfTwoSetsByRank_ThenTheParentShouldBeSetWithHigherRank()
    {
        var dsu = new DisjointSetUnion();
        dsu.MakeSet(1);
        dsu.MakeSet(2);
        dsu.MakeSet(3);

        dsu.UnionSetsByRank(2, 3); // Set contains 2, 3, 2 has a rank of 1
        dsu.UnionSetsByRank(1, 2); // Set 1 contains rank 0, should be merged into set 2

        Assert.Equal(2, dsu.FindSet(1));
        Assert.Equal(2, dsu.FindSet(2));
        Assert.Equal(2, dsu.FindSet(3));
    }

    [Fact]
    public void WhenCreatingAUnionByRankWithACycle_ThenTheCycleIsDetected()
    {
        var dsu = new DisjointSetUnion();
        dsu.MakeSet(1);
        dsu.MakeSet(2);
        Assert.False(dsu.UnionSetsByRank(1, 2));
        Assert.True(dsu.UnionSetsByRank(2, 1));
    }
}
