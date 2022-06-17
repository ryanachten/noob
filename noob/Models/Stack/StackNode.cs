namespace noob.Models.Stack;

public class StackNode<T>
{
    public StackNode(T data)
    {
        Data = data;
    }

    public readonly T Data;
    public StackNode<T>? Next { get; set; }

}
