using System;
using noob.Models.Cache;
using Xunit;

namespace noob.UnitTests.Models.Cache;

public class LFUCacheTests
{
    [Fact]
    public void GivenInvalidCapacity_WhenCreatingCache_ThenExceptionIsThrown()
    {
        Assert.Throws<ArgumentException>(() => new LFUCache(0));
    }

    [Fact]
    public void GivenNewKey_WhenPuttingValue_ThenValueIsDefined()
    {
        var key = 1;
        var value = 100;
        var cache = new LFUCache(1);

        cache.Put(key, value);
        var result = cache.Get(key);

        Assert.Equal(value, result);
    }

    [Fact]
    public void GivenExistingKey_WhenPuttingValue_ThenValueIsUpdated()
    {
        var key = 1;
        var cache = new LFUCache(1);

        cache.Put(key, 100);
        cache.Put(key, 200);

        var result = cache.Get(key);

        Assert.Equal(200, result);
    }

    [Fact]
    public void GivenMissingKey_WhenGettingValue_ThenValueIsMinusOne()
    {
        var cache = new LFUCache(1);

        var result = cache.Get(1);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void GivenCapacityExceeded_WhenValuesHaveTheSameFrequency_ThenLeastRecentlyUsedValueIsRemoved()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Put(3, 3); // Should remove 1

        Assert.Equal(-1, cache.Get(1));
    }

    // [Fact]
    // public void GivenCapacityExceeded_WhenValuesDontHaveTheSameFrequency_ThenLeastFrequentlyUsedValueIsRemoved()
    // {
    //     var cache = new LFUCache(2);

    //     cache.Put(1, 1);
    //     cache.Get(1);
    //     cache.Put(2, 2);
    //     cache.Put(3, 3); // Should remove 2

    //     Assert.Equal(-1, cache.Get(2));
    // }

    [Fact]
    public void GivenCapacityExceeded_WhenValuesDontHaveTheSameFrequency_ThenLeastFrequentlyUsedValueIsRemoved()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 1); // 1: 1
        cache.Put(2, 2); // 2: 1, 1: 1
        cache.Get(1); // 1: 2, 2: 1
        cache.Put(3, 3); // 1: 2, 3: 1
        Assert.Equal(-1, cache.Get(2)); // -> -1
        cache.Get(3); // 1: 2, 3: 2
        cache.Put(4, 4); // 3: 2, 4: 1
        Assert.Equal(-1, cache.Get(1)); // -> -1
        cache.Get(3); // 3: 3, 4: 1
        cache.Get(4); // 3: 2, 4: 2
    }
}