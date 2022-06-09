namespace noob.Models;

public interface ILinkedList
{
    public Node Head { get; }

    ILinkedList Append(int data);
    ILinkedList Delete(int data);
}
