# noob - Observer
The Observer pattern allows dependencies of a subject to be automatically notified when its state changes.

## Participants
1) `Subject` - class which contains a collection of observers which are subscribed to notifications.
2) `ConcreteSubject` - class maintains its own state. When this state changes, it calls the base subject class to notify observers.
3) `IObserver` - interface which defines an update operation which is called on subject state change
4) `ConcreteObserver` - class implementing the observer interface and is notified by subject state change

## Disadvantages
- Observer pattern can be the cause of memory leaks ([lapsed listener problem](https://en.wikipedia.org/wiki/Lapsed_listener_problem)), where observers fail to unregister from a subject and prevent garbage collection

## When to use
- When specific changes in object state need to notified to dependent objects
- When the subject does not need to know about observers 