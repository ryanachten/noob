namespace noob.Patterns.Structural.Bridge;

/// <summary>
/// Implementation.
/// Concrete implementation of the colour bridge interface.
/// </summary>
public class Red : IColour
{
    public string ApplyColour() => "Red";
}
