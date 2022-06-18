namespace noob.Models.LinkedList;

public abstract class BaseLinkedList<T>
{
    public LinkedListNode<T> Head { get; protected set; }

    public BaseLinkedList(T data)
    {
        Head = new LinkedListNode<T>(data);
    }

    /// <summary>
    /// Items iterator, allows us to use foreach statements with LinkedLists
    /// </summary>
    /// <returns></returns>
    public IEnumerable<LinkedListNode<T>> Items()
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            yield return currentNode;
            currentNode = currentNode?.Next;
        }
    }

    /// <summary>
    /// Formatted string illustrating linked list connections, useful for debugging
    /// </summary>
    /// <returns>Formatted string</returns>
    public string ToFormattedString()
    {
        var str = string.Empty;
        foreach (var item in Items())
        {
            if(item.Previous != null)
            {
                str += "<-";
            }

            str += $"[{item.Data}]";

            if (item.Next != null)
            {
                str += "->";
            }
        }

        return str;
    }
}
