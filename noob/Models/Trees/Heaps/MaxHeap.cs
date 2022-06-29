namespace noob.Models.Trees.Heaps;

public class MaxHeap<T> : MinHeap<T> where T : IComparable<T>
{
    public MaxHeap(int capacity) : base(capacity)
    {
    }

    /// <summary>
    /// Swap elements going up the heap to ensure correct ordering
    /// </summary>
    protected new void HeapifyUp()
    {
        int index = Size - 1;

        // while the current node has a parent and the parent is smaller than the current node
        // swap the two nodes around
        while (Parent(index) != null && Parent(index)!.CompareTo(_data[index]) < 0)
        {
            Swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
    }

    /// <summary>
    /// Swap elements going down the heap to ensure correct ordering
    /// </summary>
    protected new void HeapifyDown()
    {
        var index = 0;

        // Only need to check if left child exists,
        // cause right child won't exist if it doesn't
        while (LeftChild(index) != null)
        {
            var smallerChildIndex = GetLeftChildIndex(index);

            // If right child exists and is greater than left child, update smaller child index
            if (RightChild(index) != null && RightChild(index)!.CompareTo(LeftChild(index)) > 0)
            {
                smallerChildIndex = GetRightChildIndex(index);
            }

            // If the current node is smaller than the smaller child
            // then the heap is back in order
            if (_data[index]!.CompareTo(_data[smallerChildIndex]) < 0)
            {
                break;
            }

            // Otherwise, swap the current node with its smallest child
            Swap(smallerChildIndex, index);
            index = smallerChildIndex;
        }
    }
}
