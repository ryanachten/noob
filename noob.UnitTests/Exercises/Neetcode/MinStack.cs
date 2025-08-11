using System;

namespace noob.UnitTests.Exercises.NeetCode;

/// <summary>
/// MinStack implementation where all operations must be O(1)
/// </summary>
public class MinStack
{
    private Node? _head = null;
    private Node? _min = null;

    public void Push(int val)
    {
        var prevHead = _head;
        _head = new(val)
        {
            Next = prevHead
        };

        // The trick to keeping GetMin to O(1) is by maintaining a second stack
        // where the values store the minimum value correlating to the _head stack.
        // We need to be careful to synchronise this when popping and pushing to the main stack.  
        var minValue = _min == null ? _head.Data : Math.Min(_head.Data, _min.Data);
        var prevMin = _min;
        _min = new(minValue)
        {
            Next = prevMin
        };
    }

    public void Pop()
    {
        _head = _head?.Next;
        _min = _min?.Next;
    }

    public int? Top()
    {
        return _head?.Data;
    }

    public int? GetMin()
    {
        return _min?.Data;
    }
}

internal class Node(int data)
{
    public int Data { get; } = data;
    public Node? Next { get; set; }
}