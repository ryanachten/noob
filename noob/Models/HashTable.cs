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

        /// <summary>
        /// Current size of the array for the hash table
        /// </summary>
        private int TableLength { get; set; }

        /// <param name="length">Needs to be a prime number</param>
        public HashTable(int length = 3) 
        {
            if (!_tableSizes.Contains(length))
            {
                throw new ArgumentException($"{nameof(length)} is not a valid table length. Use a prime number.");
            }

            TableLength = length;
            Data = new DoublyLinkedList<T>[length];
        }

        public HashTable<T> Add(T data)
        {
            var code = data?.GetHashCode();
            if(code == null)
            {
                throw new ArgumentException($"Argument of type ${data?.GetType()} does not contain a hash code");
            }

            var index = Hash((int)code);
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

            return this;
        }

        /// <summary>
        /// Hash function using the division method to generate an array location.
        /// - resets the signed bit of the hash code
        /// - then computes the remainder of dividing the hash code by table length
        /// </summary>
        /// <param name="hashCode">Hash code of the value being stored</param>
        /// <returns>Array index</returns>
        private int Hash(int hashCode)
        {
            var mask = 0x7fffffff; // int with first bit 0 and remaining bits 1
            var resetCode = hashCode & mask; // use the mask to reset the signed bit of the hashcode
            return resetCode % TableLength;
        }
    }
}
