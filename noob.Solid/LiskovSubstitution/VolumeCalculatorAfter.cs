using noob.Solid.Models;

namespace noob.Solid.LiskovSubstitution;

/// <summary>
/// In practice, it would probably be better to inherit from a shared interface to enforce LSP
/// and this would allow us to avoid type checking in the <see cref="Sum"/> method. 
/// But extending better illustrates the problem at hand here.
/// </summary>
public class VolumeCalculatorAfter : AreaCalculator
{
    public VolumeCalculatorAfter(IEnumerable<IShape> shapes) : base(shapes)
    {
    }

    /// <summary>
    /// Now the subclass <see cref="Sum"/> and parent class <see cref="AreaCalculatorAfter.Sum"/>.
    /// return the same contract, fulfilling the Liskov Substitution principle.
    /// </summary>
    public new double Sum()
    {
        double total = 0;
        foreach (var shape in Shapes)
        {
            if (shape is IThreeDimensionalShape threeDimensionalShape)
            {
                total += threeDimensionalShape.Volume;
            }
        }
        return total;
    }
}
