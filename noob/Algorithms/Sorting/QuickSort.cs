namespace noob.Algorithms.Sorting;

public static class QuickSort<T>
{
    /// <summary>
    /// Generic quick sort implementation
    /// </summary>
    /// <param name="arr">Unsorted array</param>
    /// <param name="sortFunction">Should return 0 for equal, 1 for greater, -1 for less than</param>
    /// <returns></returns>
    public static T[] Sort(T[] arr, Func<T, T, int> sortFunction) => Sort(arr, 0, arr.Length - 1, sortFunction);

    /// <summary>
    /// Recursively subdivide the array and sort the subdivisions
    /// </summary>
    private static T[] Sort(T[] arr, int left, int right, Func<T, T, int> sortFunction)
    {
        var index = Partition(arr, left, right, sortFunction);

        // Sort left half
        if (left < index - 1) Sort(arr, left, index - 1, sortFunction);

        // Sort right half
        if (index < right) Sort(arr, index, right, sortFunction);

        return arr;
    }

    private static int Partition(T[] arr, int left, int right, Func<T, T, int> sortFunction)
    {
        var index = (left + right) / 2;
        var pivot = arr[index];

        while (left <= right)
        {
            // Find elements on the left and right
            // which should be on the other side of the pivot
            while (sortFunction(arr[left], pivot) < 0) left++;
            while (sortFunction(arr[right], pivot) > 0) right--;

            // We then swap the elements we've found
            if (left <= right)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
                left++;
                right--;
            }
        }

        return left;
    }
}
