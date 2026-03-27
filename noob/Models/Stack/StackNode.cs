namespace noob.Models.Stack;

public class StackNode<T>(T data)
{
    public readonly T Data = data;
    public StackNode<T>? Next { get; set; }

}
