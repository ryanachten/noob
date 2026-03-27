namespace noob.Models.LinkedList;

/// <summary>
/// .NET already has an LinkedListNode.
/// This implementation is to better understand the internals of the data structure
/// </summary>
public class LinkedListNode<T>(T data)
{
    public T Data = data;
    public LinkedListNode<T>? Next;
    public LinkedListNode<T>? Previous;
}
