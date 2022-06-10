namespace noob.Models;

public class DoublyLinkedList : ILinkedList
{
    public LinkedListNode Head { get; private set; }

    public DoublyLinkedList(int data)
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
        end.Previous = n;

        return this;
    }

    public ILinkedList Delete(int data)
    {
        var n = Head;
        if (n.Data == data)
        {
            if (Head.Next == null)
            {
                throw new Exception("Cannot delete head - no next node has been assigned");
            }

            Head = Head.Next; // update head
            Head.Previous = null;
            return this;
        }

        while (n.Next != null)
        {
            if (n.Next.Data == data)
            {
                n.Next = n.Next.Next; // orphan n.Next

                if(n.Next?.Previous != null)
                {
                    n.Next.Previous = n;
                }
                return this;
            }
            n = n.Next;
        }

        return this;
    }
}
