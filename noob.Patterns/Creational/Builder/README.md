# noob - Builder
Builds a complex object using a step-by-step approach. An interface defines the steps to build the final object. The builder itself is independent of the creation process - this is conducted by a director.

## Participants
1) `Builder` - interface defining the steps to create a product
2) `ConcreteBuilder` - class implementing the builder interface to create a complex product
3) `Product` - class defining the complex object that is produced by the builder
4) `Director` - class used to construct product using the builder interface

## Advantages
- Allows us to vary a product's internal representation
- Encapsulates code for construction and representation
- Provides control over steps in the construction process

## Disadvantages
- A builder must be created for each product
- May limit or complicate dependency injection

## Use Cases
- When there is a need to control object creation in steps
- When object creation needs to be independent of assembling
- When there is a need for control over the creation process at runtime  