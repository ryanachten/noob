# noob - Command
Using the Command design pattern, a client passes a request (or a 'command') to an invoker. The invoker will then pass this command to an object which can handle and execute the command.

1) `Client` - class which creates the command object
2) `ICommand` - interface containing an execute operation
3) `ConcreteCommand` - class implementing the execute operation, invoking operations on the receiver
4) `Invoker` - class which executes the command
5) `Receiver` - class which performs actions associated with a request

## When to use
- Need to implement callback functionality
- Can be used to support redo and undo functionality
- Can be implemented where different receivers handle commands differently
- Useful for auditing and logging changes via commands