using noob.Utils;

namespace noob.Models;

/// <summary>
/// .NET already has an ArrayList.
/// This implementation is to better understand the internals of the data structure
/// </summary>
/// <typeparam name="T"></typeparam>
public class ArrayList<T>
{
    /// <summary>
    /// Number of items in the array
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Contents of the array
    /// </summary>
    public T[] Data { get; private set; }
    
    /// <summary>
    /// Max capacity of the array
    /// </summary>
    private int Capacity => Data.Length;

    public ArrayList(int length)
    {
        if(length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        Count = 0;
        Data = new T[length];
    }

    public ArrayList<T> Add(T newData)
    {
        // If add operation exceeds the max capacity of the array
        // create a new array with 2x the capacity to hold data
        if(Count + 1 > Capacity)
        {
            var newArray = new T[Capacity * 2];
            Array.Copy(Data, newArray, Data.Length);
            Text.WriteText($"Resizing array. Old size: {Data.Length}. New size: {newArray.Length}", true);
            Data = newArray;
        }

        Data[Count] = newData;
        Count++;

        return this;
    }
}
