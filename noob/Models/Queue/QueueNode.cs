namespace noob.Models.Queue;

public class QueueNode<T>
{
    public QueueNode(T data)
    {
        Data = data;
    }

    public T? Data { get; }
    public QueueNode<T>? Next { get; set; }
}
