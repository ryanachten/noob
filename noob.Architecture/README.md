# Architectural Patterns

This section explores various architectural patterns used in modern software development. The goal is to provide a clear, side-by-side comparison of different approaches to structuring applications for maintainability, testability, and scalability.

## Overview

Architectural patterns provide a high-level structure for an application, defining the relationships between different components and layers. While they share common goals, such as decoupling the core business logic from external concerns, they differ in their specific metaphors and organizational strategies.

## Comparison Table

| Feature | [Hexagonal (Ports & Adapters)](./Hexagonal) | [Onion Architecture](./Onion) | [Clean Architecture](./Clean) | [Vertical Slice Architecture](./VerticalSlice) |
| :--- | :--- | :--- | :--- | :--- |
| **Metaphor** | Hexagon with Ports and Adapters | Concentric Circles (Onion) | Concentric Circles (Clean) | Vertical Slices (Feature-based) |
| **Core Focus** | Decoupling Input/Output from Domain | Domain-Driven Design (DDD) Layers | Use-Case Driven approach | Feature-based organization |
| **Dependencies** | Point inwards to the Hexagon (Domain) | Point inwards towards the Domain Core | Point inwards towards Entities/Use Cases | Co-located within a slice (Vertical) |
| **Common Terms** | Ports, Adapters, Driving/Driven | Core, Application, Infrastructure | Entities, Use Cases, Interface Adapters | Features, Slices, Requests/Handlers |
| **Primary Goal** | Technology independence (Ports) | Layered isolation with central domain | Ultimate isolation and testability | High cohesion and low coupling per feature |

## Exploring the Patterns

- **[Hexagonal](./Hexagonal)**: Focuses on creating a boundary between the application and external systems through interfaces (ports) and implementations (adapters).
- **[Onion](./Onion)**: Emphasizes the centrality of the Domain and uses dependency inversion to ensure outer layers depend only on inner layers.
- **[Clean](./Clean)**: A consolidation of Hexagonal and Onion principles, emphasizing explicit layers for Use Cases and Entities.
- **[Vertical Slice](./VerticalSlice)**: Organizes code around discrete features, grouping all related logic together and minimizing horizontal layering.
