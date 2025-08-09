using Xunit;
using noob.Models.Trees.DisjointSetUnion;

namespace noob.UnitTests.Models.Trees.DisjointSetUnionTests;

public class GivenTwoVertices
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
}
