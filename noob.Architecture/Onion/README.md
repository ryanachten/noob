# Onion Architecture

Onion Architecture, popularized by Jeffrey Palermo, is based on the principle that the domain model is at the center and all dependencies flow inwards toward it. It uses concentric circles to represent different layers of the application.

## Key Concept

At the core of the onion is the Domain Model, which defines the state and behavior of the business. Outer layers can only depend on inner layers.

- **Domain Model (Core)**: Entities and Value Objects. No dependencies on outer layers.
- **Domain Services (Core)**: Domain-level interfaces and services.
- **Application Services**: Coordinates tasks and encapsulates business rules.
- **Infrastructure / UI (External Layers)**: Implements database access, UI components, and external integrations.

## Ideal Use Case

- Long-lived enterprise applications.
- Projects using Domain-Driven Design (DDD).
- Systems that require high maintainability and testability.

## Benefits

- **Clear Dependency Management**: Dependencies always point inward, ensuring the core remains pure.
- **Testability**: Inner layers can be tested without dependencies on outer layers like the database.
- **Maintainability**: Changes in the outer layers (e.g., swapping a database) don't affect the core business logic.

## Limitations

- **Layer Proliferation**: Can lead to many layers and a lot of boilerplate code (interfaces, services, models).
- **Steep Learning Curve**: Can be difficult for developers used to traditional N-Tier architecture.
- **Potential Redundancy**: Small applications might find themselves repeating data structures across multiple layers.

## Folder Structure

```
noob.Architecture.Onion/
├── Domain/               (Core: Entities and Domain Logic)
├── Application/          (Interfaces and Application Services)
├── Infrastructure/       (Data Access, External Services)
└── Presentation/         (Web API, CLI, UI)
```
