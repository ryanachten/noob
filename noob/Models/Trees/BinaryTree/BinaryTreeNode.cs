namespace noob.Models.Trees.BinaryTree;

public class BinaryTreeNode<TKey, TValue> : IEquatable<BinaryTreeNode<TKey, TValue>> where TKey : IComparable<TKey> where TValue : IComparable<TValue>
{
    public KeyValuePair<TKey, TValue> Data { get; set; }
    public BinaryTreeNode<TKey, TValue>? Parent { get; set; }
    public BinaryTreeNode<TKey, TValue>? LeftChild { get; set; }
    public BinaryTreeNode<TKey, TValue>? RightChild { get; set; }

    public BinaryTreeNode(TKey key, TValue value, BinaryTreeNode<TKey, TValue>? parentNode = null)
    {
        Data = new KeyValuePair<TKey, TValue>(key, value);
        Parent = parentNode;
    }

    public BinaryTreeNode<TKey, TValue> Clone() => new(Data.Key, Data.Value, Parent)
    {
        LeftChild = LeftChild,
        RightChild = RightChild
    };

    public bool Equals(BinaryTreeNode<TKey, TValue>? other)
    {
        return other != null && Data.Key.Equals(other.Data.Key) && Data.Value.Equals(other.Data.Value);
    }
}
