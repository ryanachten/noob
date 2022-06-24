namespace noob.Models.Queue;

public class Queue<T>
{
    private QueueNode<T>? _first;
    private QueueNode<T>? _last;

    /// <summary>
    /// Add an item to the end of the queue
    /// </summary>
    /// <param name="item"></param>
    public Queue<T> Add(T item)
    {
        var node = new QueueNode<T>(item);

        if(_last != null)
        {
            _last.Next = node;
        }

        _last = node;
        if(_first == null)
        {
            _first = _last;
        }

        return this;
    }

    /// <summary>
    /// Remove the first item from the queue
    /// </summary>
    public void Remove()
    {
        if (_first == null) return;

        _first = _first.Next;
        
        if(_first == null)
        {
            _last = null;
        }
    }

    /// <summary>
    /// Return the top of the queue
    /// </summary>
    /// <returns></returns>
    public T? Peek() => _first == null ? default : _first.Data;

    /// <summary>
    /// Return if the queue is empty
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => _first == null;
}
