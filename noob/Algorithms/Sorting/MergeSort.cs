namespace noob.Algorithms.Sorting;

/// <summary>
/// Recursively divides an array in half and sorts each of half
/// before merging them back together
/// </summary>
public static class MergeSort<T> where T : IComparable<T>
{
    public static T[] Sort(T[] source)
    {
        var helper = new T[source.Length];
        return Sort(source.ToArray(), helper, 0, source.Length - 1);
    }

    private static T[] Sort(T[] source, T[] helper, int low, int high)
    {
        if(low < high)
        {
            var middle = (low + high) / 2;
            Sort(source, helper, low, middle); // sort left half
            Sort(source, helper, middle + 1, high); // sort right half
            Merge(source, helper, low, middle, high); // merge left and right halves
        }
        return source;
    }

    private static void Merge(T[] source, T[] helper, int low, int middle, int high)
    {
        // Copy both halves into the helper array
        for (int i = low; i <= high; i++) helper[i] = source[i];

        var left = low;
        var right = middle + 1;
        var current = low;

        // Iterate through source, and compare two halves
        // copy the smaller element into the source array
        while (left <= middle && right <= high)
        {
            var comparison = helper[left].CompareTo(helper[right]);
            if (comparison <= 0)
            {
                source[current] = helper[left];
                left++;
            } else
            {
                source[current] = helper[right];
                right++;
            }

            current++;
        }

        // Copy the rest of the left side of the helper into the source array
        // right half has already been copied over at this point
        var remaining = middle - left;
        for (int i = 0; i <= remaining; i++)
        {
            source[current + i] = helper[left + i];
        }
    }
}
