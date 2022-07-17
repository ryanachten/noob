namespace noob.Algorithms.Sorting;

public static class QuickSort<T> where T : IComparable<T>
{
    public static T[] Sort(T[] arr) => Sort(arr, 0, arr.Length - 1);

    private static T[] Sort(T[] arr, int left, int right)
    {
        var index = Partition(arr, left, right);

        // Sort left half
        if(left < index - 1) Sort(arr, left, index - 1);

        // Sort right half
        if (index < right) Sort(arr, index, right);

        return arr;
    }

    private static int Partition(T[] arr, int left, int right)
    {
        var index = (left + right) / 2;
        var pivot = arr[index];

        while (left <= right)
        {
            // Find elements on the left and right
            // which should be on the other side of the pivot
            while(arr[left].CompareTo(pivot) < 0) left++;
            while (arr[right].CompareTo(pivot) > 0) right--;

            // We then swap the elements we've found
            if(left <= right)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
                left++;
                right--;
            }
        }

        return left;
    }
}
