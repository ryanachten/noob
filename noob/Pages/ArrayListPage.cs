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

        return this;
    }

    static void PrintArray(ArrayList<int> array)
    {
        Text.WriteText("[ ");
        for (int i = 0; i <= array.Count - 1; i++)
        {
            Text.WriteText($"{array.Data[i]}" + (i == array.Count - 1 ? "" : ", "));
        }
        Text.WriteText(" ]", true);
    }
}
