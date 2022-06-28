namespace noob.Models.Trees;

public class Tree<T>
{
    public TreeNode<T> Root { get; private set; }

    public Tree(T data)
    {
        Root = new TreeNode<T>(data);
    }
}
