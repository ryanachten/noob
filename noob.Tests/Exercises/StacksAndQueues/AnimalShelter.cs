using noob.Models.Queue;
using System;
using Xunit;

namespace noob.UnitTests.Exercises.StacksAndQueues;

/// <summary>
/// An animal shelter, which holds only dogs and cats, operates on a strictly"first in, first
/// out" basis. People must adopt either the "oldest" (based on arrival time) of all animals at the shelter,
/// or they can select whether they would prefer a dog or a cat(and will receive the oldest animal of
/// that type). They cannot select which specific animal they would like.Create the data structures to
/// maintain this system and implement operations such as enqueue, dequeueAny, dequeueDog,
/// and dequeueCat. You may use the built-in Linked list data structure.
/// </summary>
public class AnimalShelter
{
    private class Animal
    {
        public string Name { get; private set; }
        public DateTime TimeOfArrival { get; set; } = default!;

        public Animal(string name)
        {
            Name = name;
        }
    }

    private class Cat : Animal {
        public Cat(string name) : base(name) { }
    }

    private class Dog : Animal {
        public Dog(string name) : base(name) { }
    }


    private class AnimalQueue
    {
        private readonly Queue<Dog> DogQueue = new();
        private readonly Queue<Cat> CatQueue = new();

        public AnimalQueue Enqueue(Animal animal)
        {
            animal.TimeOfArrival = DateTime.Now;
            if(animal is Dog dog)
            {
                DogQueue.Add(dog);
            } else if (animal is Cat cat)
            {
                CatQueue.Add(cat);
            }  else
            {
                throw new ArgumentException("This type of animal is not supported!");
            }

            return this;
        }

        public Animal? DequeueAny()
        {
            var dog = DogQueue.Peek();
            var cat = CatQueue.Peek();

            if(dog != null && cat == null || dog?.TimeOfArrival < cat?.TimeOfArrival)
            {
                DogQueue.Remove();
                return dog;
            }

            CatQueue.Remove();
            return cat;
        }

        public Dog? DequeueDog()
        {
            var dog = DogQueue.Peek();
            DogQueue.Remove();
            return dog;
        }

        public Cat? DequeueCat()
        {
            var cat = CatQueue.Peek();
            CatQueue.Remove();
            return cat;
        }
    }

    [Fact]
    public void WhenAddingADog_ThenADogIsAdded()
    {
        // Arrange
        var queue = new AnimalQueue();
        var dog = new Dog("Spot");

        // Act
        queue.Enqueue(dog);

        // Assert
        Assert.Equal(dog, queue.DequeueDog());
    }

    [Fact]
    public void WhenAddingMultipleDogs_ThenDogsAreReturnedInCorrectOrder()
    {
        // Arrange
        var queue = new AnimalQueue();
        var dog1 = new Dog("Spot");
        var dog2 = new Dog("Jess");
        var dog3 = new Dog("Spot");
        var dog4 = new Dog("Harry");


        // Act
        queue.Enqueue(dog1).Enqueue(dog2).Enqueue(dog3).Enqueue(dog4);

        // Assert
        Assert.Equal(dog1, queue.DequeueDog());
        Assert.Equal(dog2, queue.DequeueDog());
        Assert.Equal(dog3, queue.DequeueDog());
        Assert.Equal(dog4, queue.DequeueDog());
        Assert.Null(queue.DequeueDog());
    }

    [Fact]
    public void WhenReturningMultipleTypesOfAnimals_ThenAnimalsAreReturnedInCorrectOrder()
    {
        // Arrange
        var queue = new AnimalQueue();
        var dog1 = new Dog("Spot");
        var cat1 = new Cat("Spot");
        var cat2 = new Cat("Harry");
        var dog2 = new Dog("Jess");

        // Act
        queue.Enqueue(dog1).Enqueue(cat1).Enqueue(cat2).Enqueue(dog2);

        // Assert
        Assert.Equal(dog1, queue.DequeueAny());
        Assert.Equal(cat1, queue.DequeueAny());
        Assert.Equal(cat2, queue.DequeueAny());
        Assert.Equal(dog2, queue.DequeueAny());
    }
}
