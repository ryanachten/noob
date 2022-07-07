namespace noob.Models.Trees.Heaps;

public class MaxHeap<TPriority, TValue> : MinHeap<TPriority, TValue> where TPriority : IComparable<TPriority>
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
        while (ParentPriority(index) != null && ParentPriority(index)!.CompareTo(_data[index].GetValueOrDefault().Key) < 0)
        {
            Swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
    }

    protected new void HeapifyDown()
    {
        var index = 0;

        // Only need to check if left child exists,
        // cause right child won't exist if it doesn't
        while (LeftChildPriority(index) != null)
        {
            var smallerChildIndex = GetLeftChildIndex(index);

            // If right child exists and is greater than left child, update smaller child index
            if (RightChildPriority(index) != null && RightChildPriority(index)!.CompareTo(LeftChildPriority(index)) > 0)
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
}