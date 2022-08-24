using noob.Solid.Models;

namespace noob.Solid.LiskovSubstitution;

/// <summary>
/// Let q(x) be a property provable about objects of x of type T.
/// Then q(y) should be provable for objects y of type S where S is a subtype of T.
/// 
/// ...or, in layman's terms:
/// every subclass or derived class should be substitutable for their base or parent class.
/// </summary>
public class VolumeCalculatorBefore : AreaCalculator
{
    public class VolumeSum
    {
        public double Total { get; set; }
        public IEnumerable<IShape> Shapes { get; set; } = default!;
    }

    public VolumeCalculatorBefore(IEnumerable<IShape> shapes) : base(shapes)
    {
    }

    /// <summary>
    /// The issue here is that the contract returned from the subclass <see cref="Sum"/>
    /// deviates from the contract returned from the parent class <see cref="AreaCalculatorAfter.Sum"/>.
    /// This prevents the subclass being substitutable for the parent class and violates the Liskov Substitution principle.
    /// </summary>
    public new VolumeSum Sum()
    {
        double total = 0;
        foreach (var shape in Shapes)
        {
            if (shape is IThreeDimensionalShape threeDimensionalShape)
                total += threeDimensionalShape.Volume;
        }
        return new VolumeSum
        {
            Total = total,
            Shapes = Shapes
        };
    }
}

public class AreaCalculator
{
    public IEnumerable<IShape> Shapes { get; }

    public AreaCalculator(IEnumerable<IShape> shapes)
    {
        Shapes = shapes;
    }


    public double Sum()
    {
        double total = 0;
        foreach (var shape in Shapes)
        {
            if (shape is ITwoDimensionalShape twoDimensionalShape)
            {
                total += twoDimensionalShape.Area;
            }
        }
        return total;
    }
}