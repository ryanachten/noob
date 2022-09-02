# noob - Decorator
The Decorator pattern provides an alternative to inheritance, by allowing us to add new functionality to an existing object without changing its structure.

A decorator class wraps the original class and extends it by adding new operations and behaviours at runtime.

## Participants
1) `Component` - interface containing members that will be implemented by the concrete class and the decorator
2) `ConcreteComponent` - class implementing the component interface
3) `Decorator` - abstract class implementing the component interface with a reference to the concrete instance. Acts as a base class for different decorators
4) `ConcreteDecorator` - class inheriting the decorator class, acts as a decorator for components

## Disadvantages
- Requires a lot of classes resulting in similar objects

## When to use
- When we need to add or remove behaviour at runtime
- When we need to make changes to some class instances without impacting others


