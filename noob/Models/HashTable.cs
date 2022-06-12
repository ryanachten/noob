using noob.Models.LinkedList;
using noob.Utils;

namespace noob.Models
{
    public class HashTable<T>
    {
        public DoublyLinkedList<T>[] Data { get; private set; }

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

            Data = new DoublyLinkedList<T>[length];
        }

        public HashTable<T> Add(T data)
        {
            var code = data?.GetHashCode();
            if(code == null)
            {
                throw new ArgumentException($"Argument of type ${data?.GetType()} does not contain a hash code");
            }

            var index = Hash((int)code, Data.Length);
            if(Data[index] == null)
            {
                Data[index] = new(data);
                Count++;
            } else
            {
                // TODO: currently we're not checking if the value exists in the linked list
                // before appending the value - look at a performant manner of doing this
                Data[index].Append(data);
                Count++;
            }

            if(Count > Data.Length && Data.Length != MaxTableSize)
            {
                Rehash();
            }

            return this;
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

            var newArray = new DoublyLinkedList<T>[newTableSize];
            Count = 0;

            foreach (DoublyLinkedList<T>? list in Data)
            {
                if (list == null) continue;

                foreach (var item in list.Items())
                {
                    if (item != null)
                    {
                        var index = Hash(item.Data!.GetHashCode(), newTableSize);
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
