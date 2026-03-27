# Clean Architecture

Clean Architecture, popularized by Robert C. Martin ("Uncle Bob"), is an architectural pattern that emphasizes independence from frameworks and external tools. It's often visualized as a set of concentric circles.

## Key Concept

Dependencies flow from outer circles to inner circles. The core business rules are at the very center.

- **Entities (Domain)**: Core business objects and rules that are common to the entire enterprise.
- **Use Cases (Application)**: Application-specific business rules. They coordinate the flow of data to and from entities.
- **Interface Adapters (Interface)**: Set of adapters that convert data between Use Cases/Entities and external systems (web, DB, UI).
- **Frameworks and Drivers (Infrastructure)**: Tools, frameworks, and external systems.

## Ideal Use Case

- Large-scale applications with multiple interfaces (Web, Mobile, CLI).
- Projects where the business logic needs to be isolated from framework changes (e.g., swapping Web framework or database).
- Projects requiring high testability and isolation.

## Benefits

- **Framework Independence**: The architecture does not depend on some library or framework.
- **Testability**: Business rules can be tested without the UI, Database, Web Server, or any other external element.
- **UI Independence**: The UI can change easily without changing the rest of the system.
- **Database Independence**: You can swap out SQL for NoSQL without affecting business logic.

## Limitations

- **Complexity**: Many layers and mapping between layers can be tedious and feel over-engineered.
- **Learning Curve**: Mastering the strict dependency rules takes time.
- **Initial Setup Time**: Requires a significant upfront investment in project structure.

## Folder Structure

```
noob.Architecture.Clean/
├── Entities/             (Domain objects and enterprise business rules)
├── UseCases/             (Application-specific business rules)
├── InterfaceAdapters/    (Controllers, Presenters, Gateways)
└── Infrastructure/       (Frameworks, Drivers, DB implementation)
```
