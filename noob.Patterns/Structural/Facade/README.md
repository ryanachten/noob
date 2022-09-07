# noob - Façade
The facade pattern is often used when a system is very complex. A facade hides these complexities by providing the client with a unified interfaces for accessing the system.

The interface exposes a set number of members required by the client. These members access the system omn behalf of the client, hiding implementation details.

The subsystems abstracted by the facade should not be aware of the facade.

## Participants
1) `Complex system` - a library of subsystems
2) `Subsystem` - classes comprising a complex system
3) `Facade` - wrapper class containing members required by the client
4) `Client` - class which calls the high-level operations provided by the facade

## When to use
- When there is a complex system requiring a logic on the client to be used
- When multiple subsystems can be aggregated into a unified interface
- Can be used as part of a refactor of monolithic or tightly coupled systems by providing a consistent access point