namespace noob.Extensions;

public static class LinkedListExtensions
{
    /// <summary>
    /// Clone a given LinkedList
    /// </summary>
    /// <returns>A clone of a LinkedList</returns>
    public static LinkedList<T> Clone<T>(this LinkedList<T> source) => new(source);

    /// <summary>
    /// Adds the contents of one LinkedList to another
    /// </summary>
    public static void AddRange<T>(this LinkedList<T> source, LinkedList<T> target) {
        foreach (var node in target)
        {
            source.AddLast(node);
        }
    } 
}
