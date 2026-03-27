namespace noob.Solid.DependencyInversion;

/// <summary>
/// Entities must depend on abstractions, not on concretions.
/// It states that the high-level module must not depend on the low-level module, but they should depend on abstractions.
/// </summary>
public class ShapeRepositoryAfter
{
    public interface IShapeDatabase
    {
        string Connect();
    }
    public class ShapeSqlDatabase : IShapeDatabase
    {
        public string Connect() => "Connection-String-123";
    }

    /// <summary>
    /// We can address this violation by adding a database interface - changing the 
    /// constructor to rely on an abstraction rather than a concretion.
    /// Additionally, changing the database provider would no longer result in editing this file - fulfilling OCP
    /// </summary>
    public class ShapeRepository(ShapeRepositoryAfter.IShapeDatabase shapeDatabase)
    {
        private string _dbConnectionString = shapeDatabase.Connect();
    }
}
