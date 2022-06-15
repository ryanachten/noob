using noob.Models;

namespace noob.Algorithms;

public class Permutation
{
    private readonly ArrayList<string> _permutations = new(5);
    private string _str;

    public Permutation(string str)
    {
        _str = str;
    }

    public Permutation Permutate()
    {
        Permutate(0, _str.Length - 1);

        return this;
    }


    /// <summary>
    /// Generate all permutations of a given string
    /// </summary>
    /// <param name="str"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public Permutation Permutate(int start, int end)
    {
        if (start == end)
        {
            _permutations.Add(_str);
        } else
        {
            /// For each recursive step, we do the following
            /// - swap the first index with the current index
            /// - permutate all the letter after the first index to the end of the string
            /// - swap the first index with the current index
            for (int i = start; i <= end; i++)
            {
                _str = Swap(_str, start, i);
                Permutate(start + 1, end);
                _str = Swap(_str, start, i);
            }
        }

        return this;
    }

    public IEnumerable<string> GetPermutations() => _permutations.Data.Where(p => p != null);


    /// <summary>
    /// Swap characters of a string at two indices
    /// </summary>
    /// <param name="str"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns>Updated string</returns>
    private static string Swap(string str, int i, int j)
    {
        var characters = str.ToCharArray();
        (characters[j], characters[i]) = (characters[i], characters[j]);
        return new string(characters);
    }
}
