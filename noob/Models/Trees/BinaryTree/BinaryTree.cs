using noob.Constants.Enums;

namespace noob.Models.Trees.BinaryTree;

public class BinaryTree<TKey, TValue> where TKey : IComparable<TKey> where TValue : IComparable<TValue>
{
    public BinaryTreeNode<TKey, TValue>? Root { get; protected set; }

    public BinaryTree(BinaryTreeNode<TKey, TValue>? root = null)
    {
        Root = root;
    }

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
    /// Remove a node by a given key
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Whether the node has been successfully removed or not</returns>
    public bool Remove(TKey key)
    {
        Root = Remove(key, Root, out bool hasRemovedNode);
        return hasRemovedNode;
    }

    /// <summary>
    /// Remove a node by key from the tree
    /// </summary>
    /// <param name="key">Key to be removed</param>
    /// <param name="root">Node to begin searching for node to remove</param>
    /// <param name="hasRemovedNode">Indicates whether node has been removed or not</param>
    /// <returns>Updated subtree</returns>
    private static BinaryTreeNode<TKey, TValue>? Remove(TKey key, BinaryTreeNode<TKey, TValue>? root, out bool hasRemovedNode)
    {
        hasRemovedNode = false;

        if (root == null)
        {
            return null;
        }

        if(root.LeftChild == null && root.RightChild == null)
        {
            // If we've found the key, but there are no children
            // return true with null node
            if (root.Data.Key.Equals(key))
            {
                hasRemovedNode = true;
                return null;
            }
            // If we've haven't found the key and there are no children
            // return false with no modifications
            else
            {
                return root;
            }
        }

        var queue = new Queue<BinaryTreeNode<TKey, TValue>>();
        queue.Enqueue(root);

        BinaryTreeNode<TKey, TValue>? lastNode = null;
        BinaryTreeNode<TKey, TValue>? keyNode = null;

        // Do pre-order traversal until we find the key and last node
        while(queue.Count != 0)
        {
            lastNode = queue.Dequeue();

            if (lastNode.Data.Key.Equals(key)) keyNode = lastNode;

            // If children exist, add them to the queue
            if(lastNode.LeftChild != null) queue.Enqueue(lastNode.LeftChild);
            if (lastNode.RightChild != null) queue.Enqueue(lastNode.RightChild);
        }

        if (keyNode != null && lastNode != null)
        {
            var lastNodeData = lastNode.Data;
            DeleteDeepest(root, lastNode);
            keyNode.Data = lastNodeData;

            hasRemovedNode = true;
        }

        return root;
    }

    private static void DeleteDeepest(
        BinaryTreeNode<TKey, TValue> root, BinaryTreeNode<TKey, TValue> targetNode)
    {
        var queue = new Queue<BinaryTreeNode<TKey, TValue>>();
        queue.Enqueue(root);

        BinaryTreeNode<TKey, TValue>? lastNode;

        // Do pre-order traversal until last node to find and delete given node
        while (queue.Count != 0)
        {
            lastNode = queue.Dequeue();

            if (lastNode.Equals(targetNode))
            {
                // Don't think this actually performs any deletion
                lastNode = null;
                return;
            }

            if (lastNode?.RightChild != null)
            {
                // If right child is target node, delete it
                if (lastNode.RightChild.Equals(targetNode))
                {
                    lastNode.RightChild = null;
                    return;
                }
                // Otherwise, add it to queue
                queue.Enqueue(lastNode.RightChild);
            }

            if (lastNode?.LeftChild != null)
            {
                if (lastNode.LeftChild.Equals(targetNode))
                {
                    lastNode.LeftChild = null;
                    return;
                }
                queue.Enqueue(lastNode.LeftChild);
            }
        }
    }

    /// <summary>
    /// Iterate through items using a given tree traversal order
    /// </summary>
    /// <param name="order">Tree traversal order (in/pre/post order)</param>
    /// <returns>Items iterator</returns>
    public IEnumerable<BinaryTreeNode<TKey, TValue>> Items(BinaryTreeTraversalOrder order = BinaryTreeTraversalOrder.IN_ORDER)
    {
        IEnumerable<BinaryTreeNode<TKey, TValue>> items = order switch
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

    /// <summary>
    /// Find the deepest node in tree, favoring the right side
    /// </summary>
    private BinaryTreeNode<TKey, TValue> FindDeepestNode(BinaryTreeNode<TKey, TValue> node)
    {
        if (node.RightChild != null) return FindDeepestNode(node.RightChild);

        if (node.LeftChild != null) return FindDeepestNode(node.LeftChild);

        return node;
    }

    private IEnumerable<BinaryTreeNode<TKey, TValue>> InOrderTraversal(BinaryTreeNode<TKey, TValue>? node)
    {
        if (node != null)
        {
            foreach (var child in InOrderTraversal(node?.LeftChild))
            {
                yield return child;
            }

            yield return node!;

            foreach (var child in InOrderTraversal(node?.RightChild))
            {
                yield return child;
            }
        }
    }

    private IEnumerable<BinaryTreeNode<TKey, TValue>> PreOrderTraversal(BinaryTreeNode<TKey, TValue>? node)
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

    private IEnumerable<BinaryTreeNode<TKey, TValue>> PostOrderTraversal(BinaryTreeNode<TKey, TValue>? node)
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

            yield return node!;
        }
    }
}
