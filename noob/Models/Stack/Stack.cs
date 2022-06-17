namespace noob.Models.Stack;

public class Stack<T> where T : struct
{
    private StackNode<T>? Top { get; set; }

    /// <summary>
    /// Removes the top item from the stack
    /// </summary>
    /// <returns>Top value or null if top value doesn't exist</returns>
    public T? Pop()
    {
        if (Top == null) return null;
        
        T item = Top.Data;
        Top = Top.Next;
        
        return item;
    }

    /// <summary>
    /// Adds an item to the top of the stack
    /// </summary>
    /// <param name="item"></param>
    public Stack<T> Push(T item)
    {
        var node = new StackNode<T>(item)
        {
            Next = Top
        };
        Top = node;

        return this;
    }

    /// <summary>
    /// Returns the top item of the stack
    /// </summary>
    /// <returns></returns>
    public T? Peek() => Top?.Data;

    /// <summary>
    /// Returns whether the stack contains any items
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => Top == null;
}
