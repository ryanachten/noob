namespace noob.Models;

/// <summary>
/// .NET already has an LinkedList.
/// This implementation is to better understand the internals of the data structure
/// </summary>
public interface ILinkedList
{
    public LinkedListNode Head { get; }

    ILinkedList Append(int data);
    ILinkedList Delete(int data);
}
