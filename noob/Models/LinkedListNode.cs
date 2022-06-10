namespace noob.Models;

/// <summary>
/// .NET already has an LinkedListNode.
/// This implementation is to better understand the internals of the data structure
/// </summary>
public class LinkedListNode
{
    public int Data;
    public LinkedListNode? Next;
    public LinkedListNode? Previous;

    public LinkedListNode(int data)
    {
        Data = data;
    }
}
