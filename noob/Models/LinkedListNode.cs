namespace noob.Models;

/// <summary>
/// .NET already has an LinkedListNode.
/// This implementation is to better understand the internals of the data structure
/// </summary>
public class LinkedListNode<T>
{
    public T Data;
    public LinkedListNode<T>? Next;
    public LinkedListNode<T>? Previous;

    public LinkedListNode(T data)
    {
        Data = data;
    }
}
