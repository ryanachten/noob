namespace noob.Algorithms.Sorting;

public static class RadixSort
{
    /// <summary>
    /// Number of bits in a C# int
    /// </summary>
    private static readonly int NumberOfBits = 32;

    public static void Sort(int[] arr)
    {
        int i;
        var temp = new int[arr.Length];
        for (var shift = NumberOfBits - 1; shift > -1; shift--)
        {
            var j = 0;
            for (i = 0; i < arr.Length; i++)
            {
                var move = (arr[i] << shift) >= 0;
                if (shift == 0 ? !move : move)
                {
                    arr[i - j] = arr[i];
                }
                else
                {
                    temp[j++] = arr[i];
                }
            }
            Array.Copy(temp, 0, arr, arr.Length - j, j);
        }
    }
}
