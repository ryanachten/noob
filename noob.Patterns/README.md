```
      ___         ___         ___
     /__/\       /  /\       /  /\       _____
     \  \:\     /  /::\     /  /::\     /  /::\
      \  \:\   /  /:/\:\   /  /:/\:\   /  /:/\:\
  _____\__\:\ /  /:/  \:\ /  /:/  \:\ /  /:/~/::\
 /__/::::::::/__/:/ \__\:/__/:/ \__\:/__/:/ /:/\:|
 \  \:\~~\~~\\  \:\ /  /:\  \:\ /  /:\  \:\/:/~/:/
  \  \:\  ~~~ \  \:\  /:/ \  \:\  /:/ \  \::/ /:/
   \  \:\      \  \:\/:/   \  \:\/:/   \  \:\/:/
    \  \:\      \  \::/     \  \::/     \  \::/
     \__\/       \__\/       \__\/       \__\/
```

# noob - Design Patterns

Design patterns, focusing on those described by the Gang of Four.
Gang of Four design patterns are split into three categories; *creational*, *structural*, and *behavioural*.

## Creational
Creational design patterns create objects in a way where they can be decoupled from their implementing system. This decoupling provides greater flexibility in deciding which objects are required for a given scenario.

- [x] [**Factory**](./Creational/Factory/) - abstracts the process of creating objects, so the type of object can be determined at runtime
- [ ] **Abstract Factory** - abstracts the process of creating families of objects, so that families of objects can be determined at runtime
- [x] [**Builder**](./Creational/Factory/) - builds a complex object using a step-by-step approach
- [ ] **Prototype** - creates a clone of an object
- [ ] **Singleton** - ensures there is only one instances of a class

## Structural
Structural design patterns deal with the composition of object structures.
Inheritance is used to compose objects and define ways to compose objects.
Focuses on how objects and be composed to produce robust application structures.

- [x] [**Adapter**](./Structural/Adapter/) - provides a bridge between two incompatible classes
- [ ] **Bridge** - separates object abstraction from implementation
- [ ] **Composite** - used to create hierarchical tree structures
- [ ] **Decorator** - dynamically adds responsibilities to objects
- [x] [**Façade**](./Structural/Facade/) - provides a simple entry point for a complex system
- [ ] **Flyweight** - minimize memory usage through sharing data between objects
- [ ] **Proxy** - acts as a public interface to an underlying object

## Behavioural
Behavioural design patterns manage communication, relationships and responsibilities between objects.

- [ ] **Chain of Responsibility** - passes a request among a list (or 'chain') of objects
- [x] [**Command**](./Behavioural/Command/) - client requests are sent to a receiver via an invoker
- [ ] **Interpreter** - implements an expression interface to interpret a particular context
- [ ] **Iterator** - provides iterate over a collection without knowing its underlying structure
- [x] [**Mediator**](./Behavioural/Mediator/) - allows objects to communicate without knowing each other's underlying structure
- [x] [**Observer**](./Behavioural/Observer/) - allows a subject to publish changes, and observers to be notified of these changes
- [ ] **State** - alters object behaviour on state change
- [ ]  **Strategy** - provides an interface for a client to choose an algorithm at runtime
- [ ]  **Visitor** - adds new operations to a set of objects without changing the object
- [ ]  **Template Method** - defines the basic steps of an algorithm where the implementation of steps can be changed

## References:
- [DigitalOcean](https://www.digitalocean.com/community/tutorials/gangs-of-four-gof-design-patterns)
- [DotNetTricks](https://www.dotnettricks.com/learn/designpatterns/gang-of-four-gof-design-patterns-in-net)