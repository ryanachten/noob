# noob - Singleton
The Singleton pattern  is popular and widely used. It simply ensures that there is only one instance of a class, and that there is global access to this instance.

## Participants
1) Singleton

## Implementation approaches
The different approaches have the following in common:
- A private constructor to restriction class initialisation
- A private static reference to the single instance of this class
- A public static method which returns the single instance of this class 

### Eager initialisation
- Easiest method
- Class instance created at the time of the class loading
- Will be created regardless of whether or not it is actually needed
  - If a singleton doesn't use a lot of resources, this is the recommended approach
  - Often singletons are created for heavy resources such as database connections where this approach would be less appropriate
- There is also no exception handling with this approach 

### Lazy initialisation
- Lazy singleton instance is null by default 
- The public method will check if an instance exists and create it if it doesn't before returning
- This avoids the potential wasted resources of the above methods, 
- Has potential issues with thread-safety in multithreaded contexts
  - Multiple threads could create instances simultaneously, producing a different singleton per thread

### Thread-safe initialisation (using locking)
- Using locks we can ensure synchronised access to the singleton instance - preventing the multithreading issues described above
- While this resolves the issue above, the use of locks introduces performance overhead, as a new lock is acquired during each reference
- We can workaround this performance issue by adopting a *double-check locking* pattern, but as [noted](https://csharpindepth.com/Articles/Singleton) by Jon Skeet, this too has performance problems among other downsides

### Thread-safe initialisation (using `Lazy<T>`)
- An approach [recommended](https://csharpindepth.com/Articles/Singleton) by Jon Skeet in the use of .NET's `Lazy<T>` class
- Not only does this provide us lazy initialisation out of the box, but it also provides thread-safety
- This approach is also performant and the implementation is easily understood by those unfamiliar with the intricacies of singleton implementation