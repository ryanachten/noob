# noob - Bridge
Inheritance allows us to specify different implementations of an abstraction. Because of this, implementations are tightly bound to an abstraction.

The Bridge pattern provides an alternative to inheritance, allowing the abstraction and implementation to be modified independently. Instead, an interface acts as a bridge between the abstraction and implementation.

## Participants
1) `Abstraction` - abstract class containing members which define a business object and its functionality
2) `RefinedAbstraction` - extends the interface defined by the *abstraction* class
3) `IBridge` - interface which acts as a bridge between the *abstraction* and *implementation* classes
4) `Implementation` - concrete classes implementing the *bridge* interface and providing implementation details for the *abstraction* classes

## When to use
- Decoupling an implementation from its abstraction
- When abstraction implementation changes shouldn't impact clients
- Useful when versioning software, allowing a client to choose which version of the software they want

### Comparison with other patterns
- The *Bridge* pattern is very similar to the *Adapter* pattern. Bridge is often used when developing new systems, while the Adapter pattern is used for integrating with existing systems.
