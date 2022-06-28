namespace noob.Models.Trees;

public class TreeNode<T>
{
    public T Data { get; set; }

    public TreeNode(T data)
    {
        Data = data;
    }
}
