using noob.Algorithms.Sorting;
using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.SortingAndSearching;

/// <summary>
/// Write a method to sort an array of strings so that all the anagrams are next to
/// each other.
/// </summary>
public class GroupAnagrams
{
    // Example anagrams: "evil", "vile", "restful", "fluster", "Santa", "Satan", "coronavirus", "carnivorous"
    [Theory]
    [InlineData(new object[] { new string[] { "evil", "meow", "vile", "moo" }, new string[] { "evil", "vile", "moo", "meow"  } })]
    [InlineData(new object[] { new string[] { "evil", "meow", "vile", "moo", "restful", "fluster", "hurt" }, new string[] { "evil", "vile", "fluster", "restful", "moo", "hurt", "meow"  } })]
    [InlineData(new object[] { new string[] { "evil", "meow", "vile", "moo", "live" }, new string[] { "evil", "live", "vile", "moo", "meow" } })]

    public void WhenSortingArray_ThenAnagramsAreNextToEachOther(string[] unsortedArray, string[] sortedArray)
    {
        // Act
        var result = SortByAnagram(unsortedArray);

        // Assert
        Assert.Equal(sortedArray, result);
    }

    /// <summary>
    /// Approach:
    /// - sort strings by length - since anagrams must be of same length
    /// - the search through sorted array to find anagrams
    /// - return new array where anagrams are fist and non-anagrams are after
    /// </summary>
    /// <param name="unsortedArray"></param>
    /// <returns></returns>
    private static string[] SortByAnagram(string[] unsortedArray)
    {
        var lengthComparison = (string a, string b) =>
        {
            if (a.Length == b.Length)
            {
                // If length is the same, fallback to sorting alphabetically
                if (a[0] == b[0]) return 0;
                return a[0] > b[0] ? 1 : -1;
            };
            return a.Length > b.Length ? 1 : -1;
        };
        var sortedArray = QuickSort<string>.Sort(unsortedArray, lengthComparison);

        var anagrams = new List<string>();
        var nonAnagrams = new List<string>();

        // Iterate through sorted array and find anagrams for strings of same length
        for (int i = 0; i < sortedArray.Length; i++)
        {
            var str1 = sortedArray[i];
            var j = i + 1;
            var hasAnagram = false;
            while (j < sortedArray.Length && sortedArray[i].Length == sortedArray[j].Length)
            {
                var str2 = sortedArray[j];
                if(IsAnagram(str1, str2))
                {
                    // This won't work if there are multiple anagrams for the same word, but good place to start
                    if (!anagrams.Contains(str1))
                    {
                        anagrams.Add(str1);
                    }
                    anagrams.Add(str2);
                    hasAnagram = true;
                    break;
                }
                j++;
            }
            if (!hasAnagram && !anagrams.Contains(str1))
            {
                // If there are no matches, we add it to the non-anagram list
                nonAnagrams.Add(str1);
            }
        }

        anagrams.AddRange(nonAnagrams);
        return anagrams.ToArray();
    }

    private static bool IsAnagram(string str1, string str2)
    {
        for (int i = 0; i < str1.Length; i++)
        {
            var hasMatchingCharacter = false;
            for (int j = 0; j < str2.Length; j++)
            {
                // this isn't actually correct - doesn't handle multple letters in a word
                if(str1[i] == str2[j])
                {
                    hasMatchingCharacter = true;
                }
            }
            if (!hasMatchingCharacter) return false;
        }
        return true;
    }
}
