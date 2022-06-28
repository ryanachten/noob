using noob.Constants.Enums;

namespace noob.Models.Trees;

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
    /// Print items using a given traversal order
    /// </summary>
    /// <param name="order">Tree traversal order (in/pre/post order)</param>
    /// <returns></returns>
    public string Print(BinaryTreeTraversalOrder order) {
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
            var leftChildren = InOrderTraversal(node?.LeftChild);
            foreach (var child in leftChildren)
            {
                yield return child;
            }

            yield return node;

            var rightChildren = InOrderTraversal(node?.RightChild);
            foreach (var child in rightChildren)
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
