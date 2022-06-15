using noob.Models.LinkedList;
using noob.Utils;

namespace noob.Models
{
    public class HashTable<TKey, TValue> where TValue : struct
    {
        public DoublyLinkedList<KeyValuePair<TKey, TValue>>[] Data { get; private set; }

        /// <summary>
        /// Number of items in the table
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Array of precomputed prime numbers used for table sizes
        /// </summary>
        private readonly int[] _tableSizes = {
            3, 5, 11, 23, 47, 97, 197, 397, 797, 1597, 3203, 6421, 12853, 25717,
            51437, 102877, 205759, 411527, 823117, 1646237, 3292489, 6584983,
            13169977, 26339969, 52679969, 105359939, 210719881, 421439783,
            842879579, 1685759167
        };

        private int MaxTableSize => _tableSizes[^1];

        /// <param name="length">Needs to be a prime number</param>
        public HashTable(int length = 3) 
        {
            if (!_tableSizes.Contains(length))
            {
                throw new ArgumentException($"{nameof(length)} is not a valid table length. Use a prime number.");
            }

            Data = new DoublyLinkedList<KeyValuePair<TKey, TValue>>[length];
        }

        public HashTable<TKey, TValue> Add(TKey key, TValue value)
        {
            var index = GetKeyIndex(key);
            var pair = new KeyValuePair<TKey, TValue>(key, value);

            // If no list exists at the index, instantiate one
            if(Data[index] == null)
            {
                Data[index] = new(pair);
                Count++;
            } else
            {
                foreach (var item in Data[index].Items())
                {
                    // If the key already exists in the link list, update to use new value
                    if (item.Data.Key != null && item.Data.Key.Equals(key))
                    {
                        item.Data = new KeyValuePair<TKey, TValue>(key, value);
                        return this;
                    }
                }
                // If the key doesn't exist, append it to the link list
                Data[index].Append(pair);
                Count++;
            }

            if(Count > Data.Length && Data.Length != MaxTableSize)
            {
                Rehash();
            }

            return this;
        }

        /// <summary>
        /// Returns the value for a key in the table
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value or default value if value doesn't exist</returns>
        public TValue? GetValue(TKey key)
        {
            var index = GetKeyIndex(key);

            // Check list exists at index before iterating through results
            var list = Data[index];
            if (list == null)
            {
                return default;
            }

            foreach (var item in list.Items())
            {
                if(item.Data.Key != null && item.Data.Key.Equals(key))
                {
                    return item.Data.Value;
                }
            }
            return null;
        }

        private int GetKeyIndex(TKey key)
        {
            var code = key?.GetHashCode();
            if (code == null)
            {
                throw new ArgumentException($"Key of type ${key?.GetType()} does not contain a hash code");
            }
            return Hash((int)code, Data.Length);
        }

        /// <summary>
        /// Hash function using the division method to generate an array location.
        /// - resets the signed bit of the hash code
        /// - then computes the remainder of dividing the hash code by table length
        /// </summary>
        /// <param name="hashCode">Hash code of the value being stored</param>
        /// <returns>Array index</returns>
        private int Hash(int hashCode, int tableLength)
        {
            var mask = 0x7fffffff; // int with first bit 0 and remaining bits 1
            var resetCode = hashCode & mask; // use the mask to reset the signed bit of the hashcode
            return resetCode % tableLength;
        }

        /// <summary>
        /// Increases table size to the next prime number
        /// and then rehashes the data to use new table locations
        /// </summary>
        private void Rehash()
        {
            var currentIndex = Array.IndexOf(_tableSizes, Data.Length);
            var newTableSize = _tableSizes[currentIndex + 1];
            
            Text.WriteText($"Rehashing from {Data.Length} -> {newTableSize}", true);

            var newArray = new DoublyLinkedList<KeyValuePair<TKey, TValue>>[newTableSize];
            Count = 0;

            foreach (DoublyLinkedList<KeyValuePair<TKey, TValue>>? list in Data)
            {
                if (list == null) continue;

                foreach (var item in list.Items())
                {
                    if (item != null && item.Data.Key != null)
                    {
                        var index = Hash(item.Data.Key.GetHashCode(), newTableSize);
                        if (newArray[index] == null)
                        {
                            newArray[index] = new(item.Data);
                        }
                        else
                        {
                            newArray[index].Append(item.Data);
                        }
                        Count++;
                    }
                }
            }

            Data = newArray;
        }
    }
}
