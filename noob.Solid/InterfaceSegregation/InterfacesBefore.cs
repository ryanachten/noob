namespace noob.Solid.InterfaceSegregation;

/// <summary>
/// A client should never be forced to implement an interface that it doesn’t use,
/// or clients shouldn’t be forced to depend on methods they do not use.
/// </summary>
public class InterfacesBefore
{
    public interface IShape
    {
        /// <summary>
        /// The problem with how this interface is constructed is that
        /// 2D shapes will be forced by the interace to implement <see cref="Volume"/>,
        /// when this is an inappopriate property for the class - violating the Interface Segregation Principle
        /// </summary>
        public double Area { get; }
        public double Volume { get; }
    }

    public class Square : IShape
    {
        public int Length { get; set; }
        public double Area => Math.Pow(Length, 2);
        public double Volume => throw new NotImplementedException();
    }

    public class Cube : IShape
    {
        public int Length { get; set; }
        public double Area => throw new NotImplementedException();
        public double Volume => Math.Pow(Length, 3);
    }
}
