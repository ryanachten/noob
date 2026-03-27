namespace noob.Models.Trees;

public class TreeNode<T>(T data)
{
    public T Data { get; set; } = data;
}
