namespace noob.Models.Trees.BinaryTree;

public class BinarySearchTree<TKey, TValue> : BinaryTree<TKey, TValue> where TKey : IComparable<TKey> where TValue : IComparable<TValue>
{
    /// <summary>
    /// Add a key value pair to the tree
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns>Newly added node</returns>
    public new BinaryTreeNode<TKey, TValue> Add(TKey key, TValue value)
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
    /// <exception cref="ArgumentException">An existing key cannot be added to the tree</exception>
    public new BinaryTreeNode<TKey, TValue> Add(TKey key, TValue value, BinaryTreeNode<TKey, TValue> parentNode)
    {
        var comparisonResult = key.CompareTo(parentNode.Data.Key);

        // Where new key already exists, we throw and exception
        // since we're using immutable nodes
        if(comparisonResult == 0)
        {
            throw new ArgumentException($"Key '{key}' already exists and cannot be updated");
        } 
        // If the new key is smaller than the parent
        // create a node on the left if it doesn't exist
        // or continue to traverse to the left of the tree
        else if (comparisonResult < 0)
        {
            if(parentNode.LeftChild == null)
            {
                return parentNode.LeftChild = new BinaryTreeNode<TKey, TValue>(key, value, parentNode);
            } else
            {
                return Add(key, value, parentNode.LeftChild);
            }
        }
        // If the new key is greater than the parent
        // create a node on the right if it doesn't exist
        // or continue to traverse to the right of the tree
        if (parentNode.RightChild == null)
        {
            return parentNode.RightChild = new BinaryTreeNode<TKey, TValue>(key, value, parentNode);
        }
        else
        {
            return Add(key, value, parentNode.RightChild);
        }
    }


    /// <summary>
    /// Recursively attempts to get the value for a key by traversing the tree
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Value of key if found. Default value if not found</returns>
    public TValue? TryGetValue(TKey key)
    {
        return TryGetValue(key, Root);
    }

    private TValue? TryGetValue(TKey key, BinaryTreeNode<TKey, TValue>? node)
    {
        if (node == null) return default!;

        var comparisonResult = key.CompareTo(node.Data.Key);

        // If the current node key equals the key we're looking for
        // return the value of the current node
        if (comparisonResult == 0)
        {
            return node.Data.Value;
        }

        // If key we're looking for is smaller than current node
        // look at the left child
        else if(comparisonResult < 0)
        {
            return TryGetValue(key, node.LeftChild);
        }

        // If key we're looking for is greater than current node
        // look at the right child
        return TryGetValue(key, node.RightChild);
    }

    /// <summary>
    /// Remove a node by a given key
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Whether the node has been successfully removed or not</returns>
    public new bool Remove(TKey key)
    {
        var newRoot = Remove(key, Root, out bool hasRemovedNode);
        Root = newRoot;

        return hasRemovedNode;
    }

    private BinaryTreeNode<TKey, TValue>? Remove(TKey key, BinaryTreeNode<TKey, TValue>? node, out bool hasRemovedNode)
    {
        if (node == null)
        {
            hasRemovedNode = false;
            return Root;
        };

        var comparisonResult = key.CompareTo(node.Data.Key);

        // If the key is less than the current node, recursively call on left child
        if (comparisonResult < 0)
        {
            node.LeftChild = Remove(key, node.LeftChild, out hasRemovedNode);
        }
        // If the key is greater than the current node, recursively call on the right child
        else if (comparisonResult > 0)
        {
            node.RightChild = Remove(key, node.RightChild, out hasRemovedNode);
        }
        // If the current node key matches the key we're looking for
        else
        {
            // If the target node only has one child or no children
            if (node.LeftChild == null)
            {
                hasRemovedNode = true;
                return node.RightChild;
            }
            else if (node.RightChild == null)
            {
                hasRemovedNode = true;
                return node.LeftChild;
            }
            // If both children present, replace node with smallest key on the right 
            var min = MinNode(node.RightChild);
            node.Data = min.Data;

            // Clean up and delete the key we copied from
            Remove(node.Data.Key, node.RightChild, out hasRemovedNode);
        }

        return node;
    }

    private static BinaryTreeNode<TKey, TValue> MinNode(BinaryTreeNode<TKey, TValue> node)
    {
        var min = node;
        while (min.LeftChild != null)
        {
            min = min.LeftChild;
        }
        return min;
    }
}
