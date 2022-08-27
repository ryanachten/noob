# noob - Factory
Factory pattern allows us to create an object without expose the logic which created it.
An interface is used for creating the object and a subclass is used to decide which class is instantiated.

Aa factory method is comprised of the following:
1) `IProduct` - an interface describing the factory product
2) `ConcreteProduct` - concrete implementation of the product interface
3) `Creator` - declares the factory method and returns an instance of concrete product

## Advantages
- Code for interfaces, rather than specific implementations
- Makes code more robust, less coupled and easy to extend
- Provides abstraction between implementation and client

## When to use
- When the client is unsure what instance to create at runtime
- To centralise the logic of creating objects