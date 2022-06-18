namespace noob.Models.LinkedList;

public class DoublyLinkedList<T> : BaseLinkedList<T>, ILinkedList<T>
{
    public DoublyLinkedList(T data) : base(data) { }

    public ILinkedList<T> Append(T data)
    {
        var end = new LinkedListNode<T>(data);
        var n = Head;
        while (n.Next != null)
        {
            n = n.Next;
        }
        n.Next = end;
        end.Previous = n;

        return this;
    }

    public ILinkedList<T> Delete(T data)
    {
        var n = Head;
        if (n.Data!.Equals(data))
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
            if (n.Next.Data!.Equals(data))
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
