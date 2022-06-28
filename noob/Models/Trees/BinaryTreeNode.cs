namespace noob.Models.Trees;

public class BinaryTreeNode<TKey, TValue>
{
    public KeyValuePair<TKey, TValue> Data { get; set; }
    public BinaryTreeNode<TKey, TValue>? LeftChild { get; set; }
    public BinaryTreeNode<TKey, TValue>? RightChild { get; set; }

    public BinaryTreeNode(TKey key, TValue value)
    {
        Data = new KeyValuePair<TKey, TValue>(key, value);
    }

    public BinaryTreeNode<TKey, TValue> Clone() => new(Data.Key, Data.Value)
    {
        LeftChild = LeftChild,
        RightChild = RightChild
    };
}
