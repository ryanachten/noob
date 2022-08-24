namespace noob.Solid.InterfaceSegregation;

/// <summary>
/// A client should never be forced to implement an interface that it doesn’t use,
/// or clients shouldn’t be forced to depend on methods they do not use.
/// </summary>
public class InterfacesAfter
{
    /// <summary>
    /// We can address this problem by splitting <see cref="InterfacesBefore.IShape"/> into different interfaces
    /// Allowing shape classes to implement only methods appropriate to their dimensions
    /// </summary>
    public interface ITwoDimensionalShape
    {
        public double Area { get; }
    }

    public interface IThreeDimensionalShape
    {
        public double Volume { get; }
    }

    public class Square : ITwoDimensionalShape
    {
        public int Length { get; set; }
        public double Area => Math.Pow(Length, 2);
    }

    public class Cube : IThreeDimensionalShape
    {
        public int Length { get; set; }
        public double Volume => Math.Pow(Length, 3);
    }
}
