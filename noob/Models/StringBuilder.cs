namespace noob.Models;

/// <summary>
/// .NET already has an StringBuilder.
/// This implementation is to better understand the internals of the data structure
/// </summary>
public class StringBuilder : ArrayList<char>
{
    public StringBuilder(int length) : base(length) { }

    public override string ToString()
    {
        return new string(Data, 0, Count);
    }
}