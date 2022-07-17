namespace noob.Algorithms.Sorting;

/// <summary>
/// Swap two elements if one is greater than the other until array is sorted
/// </summary>
public static class BubbleSort
{
    public static T[] Sort<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                var k = j + 1;

                // If the first element is greater than the next element, swap em
                var comparison = arr[j].CompareTo(arr[k]);
                if (comparison > 0)
                {
                    (arr[k], arr[j]) = (arr[j], arr[k]);
                }
            }
        }

        return arr;
    }
}
