using noob.Models.LinkedList;
using noob.Models.Trees.BinaryTree;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// Given a binary tree, design an algorithm which creates a linked list of all the nodes
/// at each depth(e.g., if you have a tree with depth D, you'll have D linked lists).
/// </summary>
public class ListOfDepths
{
    [Fact]
    public void WhenGeneratingLinkedLists_ThenLinkedListsWithCorrectItemsIsReturned()
    {
        // Arrange
        var tree = new BinarySearchTree<int, int>();
        ///     4
        ///     /\
        ///    2  6
        ///   /\  /\
        ///  1  3 5 7
        tree.Add(4, 4);
        tree.Add(2, 2);
        tree.Add(6, 6);
        tree.Add(1, 1);
        tree.Add(5, 5);
        tree.Add(3, 3);
        tree.Add(7, 7);

        // Act
        var lists = new SinglyLinkedList<KeyValuePair<int, int>>[tree.GetHeight()];
        var result = GenerateTreeDepthLists(tree.Root, lists, 0);

        // Assert
        var expectedResults = new List<List<int>> {
            new() { 4 },
            new() { 2, 6 },
            new() { 1, 3, 5, 7 },
        };
        for (int i = 0; i < result.Length; i++)
        {
            var currentNode = result[i].Head;
            var j = 0;
            while (currentNode != null)
            {
                Assert.Equal(expectedResults[i][j], currentNode.Data.Value);
                currentNode = currentNode.Next;
                j++;
            }
        }
    }


    /// <summary>
    /// Recursively generate an array of linked lists based on tree depth
    /// </summary>
    /// <param name="node"></param>
    /// <param name="lists"></param>
    /// <param name="currentDepth"></param>
    /// <returns></returns>
    private SinglyLinkedList<KeyValuePair<int, int>>[] GenerateTreeDepthLists(BinaryTreeNode<int, int>? node, SinglyLinkedList<KeyValuePair<int, int>>[] lists, int currentDepth)
    {
        if (node == null) return lists;

        if(lists[currentDepth] == null)
        {
            lists[currentDepth] = new(node.Data);
        } else
        {
            lists[currentDepth].Append(node.Data);
        }

        lists = GenerateTreeDepthLists(node.LeftChild, lists, currentDepth+1);
        lists = GenerateTreeDepthLists(node.RightChild, lists, currentDepth + 1);

        return lists;
    }
}
