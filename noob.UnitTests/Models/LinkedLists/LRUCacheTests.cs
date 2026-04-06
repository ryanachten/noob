using System;
using noob.Models.LinkedList;
using Xunit;

namespace noob.UnitTests.Models.LinkedLists;

public class LRUCacheTests
{
    [Fact]
    public void GivenInvalidCapacity_WhenCreatingCache_ThenExceptionIsThrown()
    {
        Assert.Throws<ArgumentException>(() => new LRUCache(0));
    }

    [Fact]
    public void GivenNewKey_WhenPuttingValue_ThenValueIsDefined()
    {
        var key = 1;
        var value = 100;
        var cache = new LRUCache(1);

        cache.Put(key, value);
        var result = cache.Get(key);

        Assert.Equal(value, result);
    }

    [Fact]
    public void GivenExistingKey_WhenPuttingValue_ThenValueIsUpdated()
    {
        var key = 1;
        var cache = new LRUCache(1);

        cache.Put(key, 100);
        cache.Put(key, 200);

        var result = cache.Get(key);

        Assert.Equal(200, result);
    }

    [Fact]
    public void GivenMissingKey_WhenGettingValue_ThenValueIsMinusOne()
    {
        var cache = new LRUCache(1);

        var result = cache.Get(1);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void GivenCapacityExceeded_WhenPutting2Values_ThenLeastRecentlyUsedValueIsRemoved()
    {
        var cache = new LRUCache(1);

        cache.Put(1, 1);
        cache.Put(2, 2); // Should remove 1

        Assert.Equal(-1, cache.Get(1));
    }

    [Fact]
    public void GivenCapacityExceeded_WhenPutting3Values_ThenLeastRecentlyUsedValueIsRemoved()
    {
        var cache = new LRUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Put(3, 3); // Should remove 1

        Assert.Equal(-1, cache.Get(1));
    }

    [Fact]
    public void GivenCapacityExceeded_WhenPuttingAndGettingValues_ThenLeastRecentlyUsedValueIsRemoved()
    {
        var cache = new LRUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);
        Assert.Equal(1, cache.Get(1));

        cache.Put(3, 3); // Should remove 2
        Assert.Equal(1, cache.Get(1));
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(3, cache.Get(3));
    }

    [Fact]
    public void GivenCapacityExceeded_WhenPuttingAndGettingMultipleValues_ThenLeastRecentlyUsedValueIsRemoved()
    {
        var cache = new LRUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);
        Assert.Equal(1, cache.Get(1));
        Assert.Equal(2, cache.Get(2));

        cache.Put(3, 3); // Should remove 1
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(2, cache.Get(2));
        Assert.Equal(3, cache.Get(3));
    }
}