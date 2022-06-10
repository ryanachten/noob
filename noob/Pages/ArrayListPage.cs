using noob.Models;
using noob.Utils;

namespace noob.Pages;

public class ArrayListPage : IPage
{
    public IPage PrintTitle()
    {
        Text.WriteH1("ArrayLists");

        return this;
    }

    public IPage PrintBody()
    {
        Text.WriteH2("Appending to array");

        Text.WriteH3("Within capacity");
        var arr = new ArrayList<int>(2).Add(1).Add(2);
        PrintArray(arr);

        Text.WriteH3("Resizing capacity");
        arr.Add(3);
        PrintArray(arr);

        Text.WriteH2("String Builder");
        Text.WriteH3("Returning string");
        var builder = new StringBuilder(100);
        builder.Add('c').Add('a').Add('t');
        PrintArray(builder);
        var str = builder.ToString();
        Text.WriteText($"returns -> '{str}'", true);

        return this;
    }

    static void PrintArray<T>(ArrayList<T> array)
    {
        Text.WriteText("[ ");
        for (int i = 0; i <= array.Count - 1; i++)
        {
            Text.WriteText($"{array.Data[i]}" + (i == array.Count - 1 ? "" : ", "));
        }
        Text.WriteText(" ]", true);
    }
}
