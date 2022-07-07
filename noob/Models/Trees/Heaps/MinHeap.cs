namespace noob.Models.Trees.Heaps;

public class MinHeap<TPriority, TValue> where TPriority : IComparable<TPriority>
{
    /// <summary>
    /// Capacity of the current heap array
    /// </summary>
    protected int _capacity;
    protected KeyValuePair<TPriority, TValue>?[] _data;

    /// <summary>
    /// Number of items in the heap
    /// </summary>
    public int Size { get; protected set; }

    public MinHeap(int capacity)
    {
        _capacity = capacity;
        _data = new KeyValuePair<TPriority, TValue>?[capacity];
    }

    /// <summary>
    /// Returns the min element in the heap
    /// </summary>
    public KeyValuePair<TPriority, TValue>? Peek() => _data[0];

    /// <summary>
    /// Removes and returns the min element in the heap
    /// </summary>
    public KeyValuePair<TPriority, TValue>? Pop()
    {
        if (Size == 0) return default!;

        var item = _data[0];

        // Take the last item in array and move it to first index
        _data[0] = _data[Size - 1];

        // Then shrink the array
        Size--;

        // Then reheap the array
        HeapifyDown();

        return item;
    }

    public MinHeap<TPriority, TValue> Add(TPriority priority, TValue value)
    {
        EnsureCapacity();

        // Add item to the bottom of the heap
        _data[Size] = new KeyValuePair<TPriority, TValue>(priority, value);
        Size++;

        // Reheap the array
        HeapifyUp();

        return this;
    }

    /// <summary>
    /// Double the heap capacity onc e limit is reached
    /// </summary>
    protected void EnsureCapacity()
    {
        if (Size == _capacity)
        {
            var newCapacity = _capacity * 2;
            var newData = new KeyValuePair<TPriority, TValue>?[newCapacity];

            Array.Copy(_data, newData, _capacity);

            _capacity = newCapacity;
            _data = newData;
        }
    }

    /// <summary>
    /// Swap elements going up the heap to ensure correct ordering
    /// </summary>
    protected void HeapifyUp()
    {
        int index = Size - 1;

        // while the current node has a parent and the parent is larger than the current node
        // swap the two nodes around
        while (ParentPriority(index) != null && ParentPriority(index)!.CompareTo(_data[index].GetValueOrDefault().Key) > 0)
        {
            Swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
    }

    /// <summary>
    /// Swap elements going down the heap to ensure correct ordering
    /// </summary>
    protected void HeapifyDown()
    {
        var index = 0;

        // Only need to check if left child exists,
        // cause right child won't exist if it doesn't
        while (LeftChildPriority(index) != null)
        {
            var smallerChildIndex = GetLeftChildIndex(index);

            // If right child exists and is smaller than left child, update smaller child index
            if (RightChildPriority(index) != null && RightChildPriority(index)!.CompareTo(LeftChildPriority(index)) < 0)
            {
                smallerChildIndex = GetRightChildIndex(index);
            }

            // If the current node is smaller than the smaller child
            // then the heap is back in order
            if (_data[index].GetValueOrDefault().Key.CompareTo(_data[smallerChildIndex].GetValueOrDefault().Key) < 0)
            {
                break;
            }

            // Otherwise, swap the current node with its smallest child
            Swap(smallerChildIndex, index);
            index = smallerChildIndex;
        }
    }

    protected void Swap(int index1, int index2) => (_data[index1], _data[index2]) = (_data[index2], _data[index1]);

    protected static int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
    protected static int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
    protected static int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

    protected TPriority? LeftChildPriority(int parentIndex) => _data[GetLeftChildIndex(parentIndex)].GetValueOrDefault().Key;
    protected TPriority? RightChildPriority(int parentIndex) => _data[GetRightChildIndex(parentIndex)].GetValueOrDefault().Key;
    protected TPriority? ParentPriority(int childIndex) => _data[GetParentIndex(childIndex)].GetValueOrDefault().Key;
}
