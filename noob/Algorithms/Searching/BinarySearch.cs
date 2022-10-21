namespace noob.Algorithms.Searching;

public static class BinarySearch<T> where T : IComparable<T>
{
    public static int SearchIterative(T[] arr, T target)
    {
        var low = 0;
        var high = arr.Length - 1;
        while (low <= high)
        {
            var mid = (low + high) / 2;
            var comparison = arr[mid].CompareTo(target);

            if (comparison == 0) return mid;
            else if (comparison < 0) low = mid + 1;
            else high = mid - 1;
        }
        return -1;
    }


    /// <summary>
    /// Finds a given element in a sorted array recursively
    /// </summary>
    /// <param name="arr">Sorted array</param>
    /// <param name="target">Element to find in array</param>
    /// <returns>Index if element is found. -1 if error occurs or element is not found</returns>
    public static int SearchRecursive(T[] arr, T target) => SearchRecursive(arr, target, 0, arr.Length - 1);

    private static int SearchRecursive(T[] arr, T target, int low, int high)
    {
        if (low > high) return -1; // Error

        int mid = (low + high) / 2;
        int comparison = arr[mid].CompareTo(target);

        if (comparison < 0)
        {
            return SearchRecursive(arr, target, mid + 1, high);
        }
        else if (comparison > 0)
        {
            return SearchRecursive(arr, target, low, mid - 1);
        }
        return mid;
    }
}
