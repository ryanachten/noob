namespace noob.Patterns.Structural.Bridge;

/// <summary>
/// Bridge interface.
/// Used to decouple Colours from Shape implementations
/// </summary>
public interface IColour
{
    string ApplyColour();
}
