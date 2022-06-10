namespace noob.Models;

public class SinglyLinkedList : ILinkedList
{
    public LinkedListNode Head { get; private set; }

    public SinglyLinkedList(int data)
    {
        Head = new LinkedListNode(data);
    }

    public ILinkedList Append(int data)
    {
        var end = new LinkedListNode(data);
        var n = Head;
        while (n.Next != null)
        {
            n = n.Next;
        }
        n.Next = end;

        return this;
    }

    public ILinkedList Delete(int data)
    {
        var n = Head;
        if(n.Data == data)
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
            if(n.Next.Data == data)
            {
                n.Next = n.Next.Next; // orphan n.Next
                return this;
            }
            n = n.Next;
        }

        return this;
    }
}
