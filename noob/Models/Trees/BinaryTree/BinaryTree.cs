using noob.Constants.Enums;

namespace noob.Models.Trees.BinaryTree;

public class BinaryTree<TKey, TValue>
{
    public BinaryTreeNode<TKey, TValue>? Root { get; protected set; }

    /// <summary>
    /// Add a node to the tree
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns>Node added</returns>
    public BinaryTreeNode<TKey, TValue> Add(TKey key, TValue value)
    {
        if (Root == null)
        {
            Root = new BinaryTreeNode<TKey, TValue>(key, value);
            return Root;
        }
        return Add(key, value, Root);
    }

    /// <summary>
    /// Add a node to a specific parent node
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="parentNode"></param>
    /// <returns>Node added</returns>
    public BinaryTreeNode<TKey, TValue> Add(TKey key, TValue value, BinaryTreeNode<TKey, TValue> parentNode)
    {
        // If either the right or left child is null, fill it
        if(parentNode.LeftChild == null)
        {
            return parentNode.LeftChild = new BinaryTreeNode<TKey, TValue>(key, value, parentNode);
        } else if(parentNode.RightChild == null)
        {
            return parentNode.RightChild = new BinaryTreeNode<TKey, TValue>(key, value, parentNode);
        }

        // There might be a better way of doing this
        // but for now, let's just randomly determine whether we traverse the left of right subtree
        var rand = new Random().Next(-1, 1);
        if(rand >= 0)
        {
            return Add(key, value, parentNode.LeftChild);
        }
        return Add(key, value, parentNode.RightChild);
    }

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
    /// Returns the height of the entire binary tree
    /// </summary>
    public int GetHeight() => GetHeight(Root);
    
    /// <summary>
    /// Returns subtree height starting at a given node
    /// </summary>
    public int GetHeight(BinaryTreeNode<TKey, TValue>? node)
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
