namespace noob.Models.Trees;

public class Tree<T>(T data)
{
    public TreeNode<T> Root { get; private set; } = new TreeNode<T>(data);
}
