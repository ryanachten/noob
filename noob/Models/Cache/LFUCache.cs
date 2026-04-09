namespace noob.Models.Cache;

/// <summary>
/// Implementation of Least Frequently Used Cache
/// </summary>
public class LFUCache
{
    private class CacheEntry
    {
        public int Key { get; init; }
        public int Value { get; set; }
        public int Frequency { get; set; }
    }
    private readonly int _capacity;

    /// <summary>
    /// Cache with lookup for cache node based on cache key
    /// </summary>
    private readonly Dictionary<int, LinkedListNode<CacheEntry>> _cache;

    /// <summary>
    /// Lookup for nodes based on frequency
    /// </summary>
    private readonly Dictionary<int, LinkedList<CacheEntry>> _frequencyMap;

    private int _minFrequency = 0;
    private const int _startFrequency = 1;

    public LFUCache(int capacity)
    {
        if (capacity < 1) throw new ArgumentException("Capacity can not be less than 1", nameof(capacity));

        _capacity = capacity;
        _cache = new(capacity + 1);
        _frequencyMap = [];
    }

    public int Get(int key)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            UpdateFrequency(node);
            return node.Value.Value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var existingNode))
        {
            existingNode.Value.Value = value;
            UpdateFrequency(existingNode);
        }
        else
        {
            // If we're at capacity, we remove the least frequent node from reference
            if (_cache.Count == _capacity)
            {
                var leastFrequentNode = _frequencyMap[_minFrequency].Last;

                _cache.Remove(leastFrequentNode!.Value.Key);
                _frequencyMap[_minFrequency].RemoveLast();
            }

            var newNode = GetOrCreateFrequencyList(_startFrequency).AddFirst(new CacheEntry()
            {
                Key = key,
                Value = value,
                Frequency = _startFrequency
            });
            _minFrequency = _startFrequency;
            _cache[key] = newNode;
        }
    }

    private void UpdateFrequency(LinkedListNode<CacheEntry> node)
    {
        var prevFreq = node.Value.Frequency;
        var newFreq = prevFreq + 1;

        node.Value.Frequency = newFreq;

        // Remove node from current frequency list
        _frequencyMap[prevFreq].Remove(node);

        // Add node to the start of the frequency list (i.e. ordered by recency)
        GetOrCreateFrequencyList(newFreq).AddFirst(node);

        if (newFreq < _minFrequency) _minFrequency = newFreq;

        if (_minFrequency == prevFreq && _frequencyMap[prevFreq].Count == 0)
        {
            _minFrequency = newFreq;
        }
    }

    private LinkedList<CacheEntry> GetOrCreateFrequencyList(int key)
    {
        if (!_frequencyMap.TryGetValue(key, out var freqList))
        {
            _frequencyMap[key] = new();
            freqList = _frequencyMap[key];
        }

        return freqList;
    }
}