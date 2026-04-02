using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class ClosestNodesInBinarySearchTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)
    {
        var vals = new List<int>();
        ConvertTreeToList(root, vals);

        var results = new List<IList<int>>();
        foreach (var query in queries)
        {
            results.Add(BinarySearchMinMax(query, vals, 0, vals.Count - 1));
        }

        return results;
    }

    private static List<int> BinarySearchMinMax(int target, List<int> vals, int left, int right)
    {
        int floor = -1;
        int ceiling = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (vals[mid] == target)
            {
                return [target, target];
            }

            if (vals[mid] < target)
            {
                floor = vals[mid];
                left = mid + 1;
            }
            else
            {
                ceiling = vals[mid];
                right = mid - 1;
            }
        }

        return [floor, ceiling];
    }

    private static void ConvertTreeToList(TreeNode node, List<int> vals)
    {
        if (node == null) return;

        // Process in pre-order to maintain value order
        ConvertTreeToList(node.left, vals);
        vals.Add(node.val);
        ConvertTreeToList(node.right, vals);
    }

    [Theory]
    [MemberData(nameof(GetTestCases))]
    public void GivenTree_WhenGettingClosestNodes_ReturnsClosestMinAndMaxNodes(int?[] treeValues, int[] queries, List<IList<int>> expected)
    {
        var root = BuildTreeFromArray(treeValues);
        var result = ClosestNodes(root, queries);

        Assert.Equal(expected.Count, result.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    /// <summary>
    /// Converts an array representation (level-order with null for missing nodes) to a binary tree
    /// </summary>
    private static TreeNode BuildTreeFromArray(int?[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null)
            return null;

        var root = new TreeNode(values[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while (queue.Count > 0 && index < values.Length)
        {
            var node = queue.Dequeue();

            // Add left child
            if (index < values.Length && values[index] != null)
            {
                node.left = new TreeNode(values[index].Value);
                queue.Enqueue(node.left);
            }
            index++;

            // Add right child
            if (index < values.Length && values[index] != null)
            {
                node.right = new TreeNode(values[index].Value);
                queue.Enqueue(node.right);
            }
            index++;
        }

        return root;
    }

    public static IEnumerable<object[]> GetTestCases()
    {
        yield return new object[]
        {
            new int?[] { 6, 2, 13, 1, 4, 9, 15, null, null, null, null, null, null, 14 },
            new int[] { 2, 5, 16 },
            new List<IList<int>>
            {
                new List<int> { 2, 2 },
                new List<int> { 4, 6 },
                new List<int> { 15, -1 }
            }
        };
    }
}
