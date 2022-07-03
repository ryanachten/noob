namespace noob.Models;

/// <summary>
/// .NET already has an StringBuilder.
/// This implementation is to better understand the internals of the data structure
/// </summary>
public class StringBuilder : ArrayList<char>
{
    /// <param name="length">Initial array capacity for StringBuilder</param>
    public StringBuilder(int length) : base(length) { }

    /// <summary>
    /// Returns the contents of the builder as a string
    /// </summary>
    public override string ToString()
    {
        return new string(Data, 0, Count);
    }
}