namespace noob.Models.Cache;

/// <summary>
/// Implementation of Least Recently Used Cache
/// </summary>
public class LRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<(int, int)>> _cache;
    private readonly LinkedList<(int, int)> _recencyList;

    public LRUCache(int capacity)
    {
        if (capacity < 1) throw new ArgumentException("Capacity can not be less than 1", nameof(capacity));

        _capacity = capacity;
        _cache = new(capacity + 1);
        _recencyList = new();
    }

    public int Get(int key)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            UpdateHead(node);
            var (_, cacheValue) = node.Value;
            return cacheValue;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var existingNode))
        {
            existingNode.Value = (key, value);
            UpdateHead(existingNode);
        }
        else
        {
            var newNode = _recencyList.AddFirst((key, value));
            _cache[key] = newNode;
        }

        // If we're over capacity, we remove the least recent node from reference
        if (_cache.Count > _capacity)
        {
            var (leastRecentKey, _) = _recencyList.Last!.Value;
            _cache.Remove(leastRecentKey);
            _recencyList.RemoveLast();
        }
    }

    private void UpdateHead(LinkedListNode<(int, int)> node)
    {
        if (node == _recencyList.First) return; // Already head

        _recencyList.Remove(node);
        _recencyList.AddFirst(node);
    }
}