# noob - Visitor
The Visitor design pattern allows us to add new operations to a set of objects without changing the object itself. It is used when we need to perform the same operation on a similar kind of object by allowing us to move operational logic out of an object's class into another class.

## Participants
1) `Client` - class which has access to objects in the data structure. Can instruct these objects to accept a *visitor* and perform operations.
2) `ObjectStructure` - class holding all elements which can be used by *visitors*
3) `IElement` - interface specifying an *accept* operation
4) `ConcreteElement` - class implementing the *element* interface
5) `IVisitor` - interface specifying the *visit* operation
6) `ConcreteVisitor` - class implementing the *visitor* interface

## Benefits
- When the operation logic changes, we only need to modify the visitor implementation
- Supporting a new type of element only requires changing the visitor interface and implementation

## Limitations
- You need to know the return type of the *visit* method at the time of designing
  - Changing this after the fact would require refactoring the interface and implementations
- If there are many visitor implementations, then it can be hard to extend

## When to use
- When we need to perform the same operation on different but similar types of objects
- When an object has unrelated operations that need to be performed on it
- When an object shouldn't change, but needs to perform new operations