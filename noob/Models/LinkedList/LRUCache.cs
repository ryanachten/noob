namespace noob.Models.LinkedList;

public class LRUCache
{
    private class Node
    {
        public int Key { get; init; }
        public int Value { get; set; }
        public Node? Next { get; set; }
        public Node? Previous { get; set; }
    }

    private readonly int _capacity;
    private readonly Dictionary<int, Node> _values;
    private Node? _mostRecentNode;
    private Node? _leastRecentNode;


    public LRUCache(int capacity)
    {
        if (capacity < 1) throw new ArgumentException("Capacity can not be less than 1", nameof(capacity));

        _capacity = capacity;
        _values = [];
    }

    public int Get(int key)
    {
        if (_values.TryGetValue(key, out var node))
        {
            UpdateHead(node);
            return node.Value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (_values.TryGetValue(key, out var node))
        {
            node.Value = value;
            UpdateHead(node);
        }
        else
        {
            node = new Node()
            {
                Key = key,
                Value = value,
                Next = _mostRecentNode
            };
            _values[key] = node;
            _mostRecentNode?.Previous = node;
            _mostRecentNode = node;
            _leastRecentNode ??= node;
        }

        // If we're over capacity, we remove the least recent node from reference
        if (_values.Count > _capacity)
        {
            _values.Remove(_leastRecentNode!.Key);
            _leastRecentNode = _leastRecentNode?.Previous;
            _leastRecentNode?.Next = null;
        }
    }

    private void UpdateHead(Node node)
    {
        if (node == _mostRecentNode) return;

        // Remove node from current position
        var previousNode = node.Previous;
        var nextNode = node.Next;
        previousNode?.Next = nextNode;
        nextNode?.Previous = previousNode;

        // If the current node has no next node (and is least recent), then update least recent
        if (nextNode == null) _leastRecentNode = previousNode;

        // Update node to be most recent
        var formerRecentNode = _mostRecentNode;
        node.Previous = null;
        node.Next = formerRecentNode;
        formerRecentNode?.Previous = node;

        _mostRecentNode = node;
    }
}