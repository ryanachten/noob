namespace noob.Models.Trees.BinaryTree;

public class BinaryTreeNode<TKey, TValue>
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
}
