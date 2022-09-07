using noob.Patterns.Creational.Singleton;
using Xunit;

namespace noob.UnitTests.Patterns.Creational;

public class SingletonTests
{
    [Fact]
    public void WhenInstantiatingEagerSingletons_ThenThereShouldOnlyBeOneInstance()
    {
        var instance1 = EagerSingleton.Instance;
        var instance2 = EagerSingleton.Instance;
        InstancesAretheSame(instance1, instance2);
    }

    [Fact]
    public void WhenInstantiatingLazySingletons_ThenThereShouldOnlyBeOneInstance()
    {
        var instance1 = LazySingleton.Instance;
        var instance2 = LazySingleton.Instance;
        InstancesAretheSame(instance1, instance2);
    }

    [Fact]
    public void WhenInstantiatingThreadSafeLockingSingletons_ThenThereShouldOnlyBeOneInstance()
    {
        var instance1 = ThreadSafeLockingSingleton.Instance;
        var instance2 = ThreadSafeLockingSingleton.Instance;
        InstancesAretheSame(instance1, instance2);
    }

    [Fact]
    public void WhenInstantiatingThreadSafeLazySingletons_ThenThereShouldOnlyBeOneInstance()
    {
        var instance1 = ThreadSafeLazySingleton.Instance;
        var instance2 = ThreadSafeLazySingleton.Instance;
        InstancesAretheSame(instance1, instance2);
    }

    private static void InstancesAretheSame(ISingleton a, ISingleton b)
    {
        Assert.Same(a, b);
        Assert.StrictEqual(a.Value, b.Value);
    }
}
