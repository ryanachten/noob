# noob - Mediator

The Mediator pattern allows objects to communicate with one another without knowing each other's underlying structure. The defines an object which encapsulates how objects with interact with each other, supporting easy maintainability through loose coupling.

1) `Mediator` - interface which defines the operations that can be called by colleague objects
2) `ConcreteMediator` - class implementing the mediator operations
3) `Colleague` - abstract class that defines a single protected field, holding a reference to the mediator
4) `ConcreteColleague` - classes that communicate with each other via the mediator

## Disadvantages
- Shouldn't use mediator just to achieve loose-coupling
- The more mediators we have, the harder it is to maintain them

## When to use
- When communication logic between objects is complex; can use mediator to centralize communication logic
- When too many relationships exist; can use mediator to provide a common point of communication