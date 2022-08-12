using noob.Extensions;
using noob.Models.Trees.BinaryTree;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// A binary search tree was created by traversing through an array from left to right
/// and inserting each element.Given a binary search tree with distinct elements, print all possible
/// arrays that could have led to this tree.
/// </summary>
public class BSTSequences
{
    public static IEnumerable<object[]> Trees()
    {
        ///     4
        ///     /\
        ///    2  6
        var tree1 = new BinarySearchTree<int, int>();
        tree1.Add(4, 4);
        tree1.Add(2, 2);
        tree1.Add(6, 6);

        ///     4
        ///     /\
        ///    2  6
        ///   /
        ///  1 
        var tree2 = new BinarySearchTree<int, int>();
        tree2.Add(4, 4);
        tree2.Add(2, 2);
        tree2.Add(6, 6);
        tree2.Add(1, 1);

        return new List<object[]>
        {
            new object[] {
                tree1,
                new int[][]{ new int[]{ 4, 2, 6 }, new int[] { 4, 6, 2 } }
            },
            new object[] {
                tree2,
                new int[][]{
                    new int[] { 4, 2, 6, 1 }, new int[] { 4, 6, 2, 1 }, new int[] { 4, 2, 1, 6 }
                }
            }
        };
    }

    [Theory]
    [MemberData(nameof(Trees))]
    public void WhenDeterminingArraysFromBinarySearchTree_ThenAllPossibleArraysAreReturned(BinarySearchTree<int, int> tree, int[][] expectedArrays)
    {
        // Act
        var lists = GenerateSequences(tree.Root);
        var results = lists.Select(x => x.ToArray()).ToArray();

        // Assert
        Assert.Equal(expectedArrays.Length, results.Length);
        foreach (var arr in expectedArrays)
        {
            Assert.Contains(arr, results);
        }
    }


    public static List<LinkedList<int>> GenerateSequences(BinaryTreeNode<int, int>? node)
    {
        var result = new List<LinkedList<int>>();
        if (node == null) {
            result.Add(new());
            return result;
        }

        var prefix = new LinkedList<int>();
        prefix.AddLast(node.Data.Key);

        // Recursively generate sequences for both left and right children
        var leftSequence = GenerateSequences(node.LeftChild);
        var rightSequence = GenerateSequences(node.RightChild);

        // Weave together nodes for each sequence
        foreach (var left in leftSequence)
        {
            foreach (var right in rightSequence)
            {
                var weaved = new List<LinkedList<int>>(); 
                WeaveLists(left, right, weaved, prefix);
                result.AddRange(weaved);
            }
        }

        return result;
    }

    /// <summary>
    /// Weave lists together in all possible permutations
    /// Works by recursively removing the head from lists
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="results"></param>
    /// <param name="prefix"></param>
    private static void WeaveLists(
        LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> results, LinkedList<int> prefix)
    {
        // If one list is empty, add the remainder to a clone of the prefix
        if(!first.Any() || !second.Any())
        {
            var result = prefix.Clone();
            result.AddRange(first);
            result.AddRange(second);
            results.Add(result);
            return;
        }

        // Recursively add the head of the first list to the prefix
        var headFirst = first.First();
        prefix.AddLast(headFirst);
        first.RemoveFirst();
        WeaveLists(first, second, results, prefix);
        prefix.RemoveLast();
        first.AddFirst(headFirst);

        // Recursively add the head of the second list to the prefix
        var headSecond = second.First();
        prefix.AddLast(headSecond);
        second.RemoveFirst();
        WeaveLists(first, second, results, prefix);
        prefix.RemoveLast();
        second.AddFirst(headSecond);
    }
}
