namespace noob.Models.LinkedList;

/// <summary>
/// .NET already has an LinkedList.
/// This implementation is to better understand the internals of the data structure
/// </summary>
public interface ILinkedList<T>
{
    public LinkedListNode<T> Head { get; }

    ILinkedList<T> Append(T data);
    ILinkedList<T> Delete(T data);
    IEnumerable<LinkedListNode<T>> Items();
}
