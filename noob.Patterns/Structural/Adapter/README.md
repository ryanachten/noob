# noob - Adapter
The Adapter pattern acts as a bridge between two incompatible interfaces, by providing an 'adapter' which is responsible from this communication.

## Participants
1) `ITarget` - interface used by the client to fulfil a request
2) `Adapter` - class implementing the target interface and inheriting from the adaptee class. Provides communication between the client and the adaptee
3) `Adaptee` - class containing functionality required by the client. The interface for the adaptee is incompatible with the client
4) `Client` - class which interacts with the adaptee via the adapter

## When to use
- When a system is incompatible with another system, but needs to use it
- To allow communication between independent new and legacy systems

### Comparison with other patterns
- Adapters can use **factory**, **builder** or **prototype** creational patterns, depending on implementation needs.
- Can be used instead of **facade** to hide platform-specificity