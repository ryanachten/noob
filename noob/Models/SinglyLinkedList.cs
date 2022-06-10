namespace noob.Models;

public class SinglyLinkedList<T> : ILinkedList<T>
{
    public LinkedListNode<T> Head { get; private set; }

    public SinglyLinkedList(T data)
    {
        Head = new LinkedListNode<T>(data);
    }

    public ILinkedList<T> Append(T data)
    {
        var end = new LinkedListNode<T>(data);
        var n = Head;
        while (n.Next != null)
        {
            n = n.Next;
        }
        n.Next = end;

        return this;
    }

    public ILinkedList<T> Delete(T data)
    {
        var n = Head;
        if(n.Data!.Equals(data))
        {
            if(Head.Next == null)
            {
                throw new Exception("Cannot delete head - no next node has been assigned");
            } 
            
            Head = Head.Next; // update head
            return this;
        }

        while (n.Next != null)
        {
            if(n.Next.Data!.Equals(data))
            {
                n.Next = n.Next.Next; // orphan n.Next
                return this;
            }
            n = n.Next;
        }

        return this;
    }
}
