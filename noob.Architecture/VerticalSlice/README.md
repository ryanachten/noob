# Vertical Slice Architecture

Vertical Slice Architecture, popularized by Jimmy Bogard, organizes code around features or "slices" rather than technical layers. Each slice contains everything needed for a specific request or feature, from the domain logic to the persistence and user interface concerns.

## Key Concept

Instead of horizontal layers (UI, Application, Domain, Infrastructure), the system is divided vertically into discrete features. Each slice is independent and can be implemented differently if needed.

- **Features**: The primary organizational unit. Each feature (e.g., "AddUser", "GetProductDetails") is self-contained.
- **Independence**: Changes to one slice have minimal impact on others.
- **Symmetry**: Each slice follows the same internal pattern, often using MediatR or similar dispatcher-based patterns.

## Ideal Use Case

- Medium-to-large-scale applications where technical layers become a bottleneck.
- Projects where features are relatively independent and change at different rates.
- Teams that want to minimize the complexity of mapping data between multiple layers.

## Benefits

- **Low Coupling**: Features are decoupled from each other.
- **High Cohesion**: All code related to a single feature is kept together.
- **Agility**: Easier to add or modify features without navigating multiple projects or folders.
- **Reduced Over-engineering**: Slices can be as simple or complex as needed; you don't have to follow a rigid layering for every feature.

## Limitations

- **Risk of Code Duplication**: Logic might be repeated across slices (though this is often acceptable to maintain independence).
- **Consistency**: Without discipline, different slices might use wildly different patterns, making the codebase feel disjointed.
- **Identifying "Shared" Logic**: It can be tricky to decide what belongs in a slice and what should be shared across the system.

## Folder Structure

```
noob.Architecture.VerticalSlice/
├── Features/
│   ├── [FeatureName]/
│   │   ├── [Request].cs       (Command/Query, Handler, and Response)
│   │   ├── [DomainModel].cs   (Feature-specific entities or DTOs)
│   │   └── [Persistence].cs   (Repository or DB context if needed)
└── Common/                (Shared cross-cutting concerns like logging, auth)
```
