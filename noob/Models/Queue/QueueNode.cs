namespace noob.Models.Queue;

public class QueueNode<T>(T data)
{
    public T? Data { get; } = data;
    public QueueNode<T>? Next { get; set; }
}
