# noob - Strategy
The Strategy pattern provides a client with easy access to a family of algorithms at runtime.
To achieve this, we abstract an algorithm from its host class and put it into a separate class to prevent messy conditional statements.

1) `Context` - class containing a reference to the strategy object. This reference will be set based on which algorithm is required at runtime
2) `IStrategy` - interface used by the context to call an algorithm
3) `ConcreteStrategy` - classes that implement the strategy, representing different algorithms

## When to use
- Useful when we have multiple algorithms for a specific task. Strategy allows our application to remain flexible when choosing the appropriate algorithm at runtime

### Comparison with other patterns
- Similar to the **state** pattern - the distinction being that **strategy** is passed as an argument to the method and *is not stored* as a reference by the context