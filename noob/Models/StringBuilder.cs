namespace noob.Models;

/// <summary>
/// .NET already has an StringBuilder.
/// This implementation is to better understand the internals of the data structure
/// </summary>
/// <param name="length">Initial array capacity for StringBuilder</param>
public class StringBuilder(int length) : ArrayList<char>(length)
{

    /// <summary>
    /// Returns the contents of the builder as a string
    /// </summary>
    public override string ToString()
    {
        return new string(Data, 0, Count);
    }
}