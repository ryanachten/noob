namespace noob.Algorithms.Sorting;

/// <summary>
/// Conduct linear scans for the smallest element, and moving to the front after each pass
/// </summary>
public static class SelectionSort
{
    public static int[] Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var smallestValue = int.MaxValue;
            int? smallestIndex = null;
            var searchArr = arr[i..];
            
            for (int j = 0; j < searchArr.Length; j++)
            {
                // If the current value is smaller than the current sweep number, update it
                if (searchArr[j] < smallestValue)
                {
                    smallestValue = searchArr[j];
                    smallestIndex = j + i;
                }
            }

            // If we're at the end of the array, swap values
            if (smallestIndex != null)
            {
                (arr[i], arr[(int)smallestIndex]) = (arr[(int)smallestIndex], arr[i]);
            }
        }

        return arr;
    }
}
