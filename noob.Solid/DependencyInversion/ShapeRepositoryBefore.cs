namespace noob.Solid.DependencyInversion;

/// <summary>
/// Entities must depend on abstractions, not on concretions.
/// It states that the high-level module must not depend on the low-level module, but they should depend on abstractions.
/// </summary>
public class ShapeRepositoryBefore
{
    public class ShapeSqlDatabase
    {
        public string Connect() => "Connection-String-123";
    }

    /// <summary>
    /// This constructor violates DIP by depending on a concrete class instead of an abstraction
    /// Additionally, changing the database provider would result in editing this file - violating OCP
    /// </summary>
    public class ShapeRepository(ShapeRepositoryBefore.ShapeSqlDatabase shapeSqlDatabase)
    {
        private string _dbConnectionString = shapeSqlDatabase.Connect();
    }
}
