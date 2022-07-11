using noob.Constants.Enums;

namespace noob.Models.Trees.BinaryTree;

public class BinaryTree<TKey, TValue>
{
    public BinaryTreeNode<TKey, TValue>? Root { get; protected set; }

    /// <summary>
    /// Iterate through items using a given tree traversal order
    /// </summary>
    /// <param name="order">Tree traversal order (in/pre/post order)</param>
    /// <returns>Items iterator</returns>
    public IEnumerable<BinaryTreeNode<TKey, TValue>?> Items(BinaryTreeTraversalOrder order = BinaryTreeTraversalOrder.IN_ORDER)
    {
        IEnumerable<BinaryTreeNode<TKey, TValue>?> items = order switch
        {
            BinaryTreeTraversalOrder.PRE_ORDER => PreOrderTraversal(Root),
            BinaryTreeTraversalOrder.POST_ORDER => PostOrderTraversal(Root),
            _ => InOrderTraversal(Root),
        };

        foreach (var item in items)
        {
            yield return item;
        }
    }

    /// <summary>
    /// Returns the height of the current binary tree
    /// </summary>
    public int GetHeight() => GetHeight(Root);
    protected int GetHeight(BinaryTreeNode<TKey, TValue>? node)
    {
        if(node == null) return 0;

        var leftHeight = GetHeight(node.RightChild);
        var rightHeight = GetHeight(node.LeftChild);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    /// <summary>
    /// Print items using a given traversal order
    /// </summary>
    /// <param name="order">Tree traversal order (in/pre/post order)</param>
    /// <returns></returns>
    public string Print(BinaryTreeTraversalOrder order = BinaryTreeTraversalOrder.IN_ORDER) {
        var items = Items(order);
        var output = string.Empty;

        foreach (var item in items)
        {
            if (item != null)
            {
                output += $"[{item.Data.Key}: {item.Data.Value}] ";
            } else
            {
                output += "null ";
            }
        }
        
        return output;
    }

    private IEnumerable<BinaryTreeNode<TKey, TValue>?> InOrderTraversal(BinaryTreeNode<TKey, TValue>? node)
    {
        if (node != null)
        {
            foreach (var child in InOrderTraversal(node?.LeftChild))
            {
                yield return child;
            }

            yield return node;

            foreach (var child in InOrderTraversal(node?.RightChild))
            {
                yield return child;
            }
        }
    }

    private IEnumerable<BinaryTreeNode<TKey, TValue>?> PreOrderTraversal(BinaryTreeNode<TKey, TValue>? node)
    {
        if (node != null)
        {
            yield return node;

            foreach (var child in PreOrderTraversal(node?.LeftChild))
            {
                yield return child;
            }

            foreach (var child in PreOrderTraversal(node?.RightChild))
            {
                yield return child;
            }
        }
    }

    private IEnumerable<BinaryTreeNode<TKey, TValue>?> PostOrderTraversal(BinaryTreeNode<TKey, TValue>? node)
    {
        if (node != null)
        {
            foreach (var child in PostOrderTraversal(node?.LeftChild))
            {
                yield return child;
            }

            foreach (var child in PostOrderTraversal(node?.RightChild))
            {
                yield return child;
            }

            yield return node;
        }
    }
}
