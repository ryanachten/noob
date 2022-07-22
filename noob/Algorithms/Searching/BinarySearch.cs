namespace noob.Algorithms.Searching;

public class BinarySearch<T> where T : IComparable<T>
{
    /// <summary>
    /// Finds a given element in a sorted array
    /// </summary>
    /// <param name="arr">Sorted array</param>
    /// <param name="target">Element to find in array</param>
    /// <returns>Index if element is found. -1 if error occurs or element is not found</returns>
    public static int Search(T[] arr, T target) => Search(arr, target, 0, arr.Length - 1);

    private static int Search(T[] arr, T target, int low, int high)
    {
        if(low > high) return -1; // Error

        int mid = (low + high) / 2;
        int comparison = arr[mid].CompareTo(target);

        if(comparison < 0)
        {
            return Search(arr, target, mid + 1, high);
        } else if (comparison > 0)
        {
            return Search(arr, target, low, mid - 1);
        }
        return mid;
    }
}
