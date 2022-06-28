namespace noob.Models.Trees;

public class BinarySearchTree<TKey, TValue> : BinaryTree<TKey, TValue> where TKey : IComparable<TKey>
{
    /// <summary>
    /// Add a key value pair to the tree
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns>Newly added node</returns>
    public BinaryTreeNode<TKey, TValue> Add(TKey key, TValue value)
    {
        if (Root == null)
        {
            Root = new BinaryTreeNode<TKey, TValue>(key, value);
            return Root;
        }
        return Add(key, value, Root);
    }

    protected BinaryTreeNode<TKey, TValue> Add(TKey key, TValue value, BinaryTreeNode<TKey, TValue> parentNode)
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
                return parentNode.LeftChild = new BinaryTreeNode<TKey, TValue>(key, value);
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
            return parentNode.RightChild = new BinaryTreeNode<TKey, TValue>(key, value);
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

    public BinaryTreeNode<TKey, TValue>? Remove(TKey key)
    {
        return Remove(key, Root);
    }

    private BinaryTreeNode<TKey, TValue>? Remove(TKey key, BinaryTreeNode<TKey, TValue>? node)
    {
        if (node == null) return null;

        var comparisonResult = key.CompareTo(node.Data.Key);

        // If the current node key matches the key we're looking for
        if (comparisonResult == 0)
        {
            var deletedNode = node.Clone();
            if (node.LeftChild == null && node.RightChild == null)
            {
                // TODO: not sure what to do here
            }
            // If the target node has only left child, replace the node with left child
            else if (node.LeftChild != null && node.RightChild == null)
            {
                node.Data = node.LeftChild.Data;
                node.LeftChild = null;
            }
            // If the target node has only right child, replace the node with right child
            else if (node.RightChild != null && node.LeftChild == null)
            {
                node.Data = node.RightChild.Data;
                node.RightChild = null;
            }
            // If both children present, replace node with smallest key on the right 
            else if (node.RightChild != null && node.LeftChild != null)
            {
                if(node.RightChild.LeftChild == null)
                {
                    node.Data = node.RightChild.Data;
                    node.RightChild = null;
                } else
                {
                    var smallestKeyParent = node.RightChild;
                    while(smallestKeyParent?.LeftChild?.LeftChild != null)
                    {
                        smallestKeyParent = smallestKeyParent.LeftChild;
                    }
                    node.Data = smallestKeyParent!.LeftChild!.Data;
                    smallestKeyParent.LeftChild = null;
                }
            }
            return deletedNode;
        }
        // If the key is less than the current node, recursively call on left child
        else if (comparisonResult < 0)
        {
            return Remove(key, node.LeftChild);
        }
        // Finally, if the key is greater than the current node, recursively call on the right child
        return Remove(key, node.RightChild);
    }
}
