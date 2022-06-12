using noob.Models;
using noob.Utils;

namespace noob.Pages;

public class HashTablePage : IPage
{
    public IPage PrintBody()
    {
        var hash = new HashTable<string, int>();
        var rand = new Random();
        for (int i = 0; i < 10; i++)
        {
            hash.Add(rand.Next(-1000, 1000).ToString(), i);
        }
        PrintHashTable(hash);

        return this;
    }

    public IPage PrintTitle()
    {
        Text.WriteH1("HashTables");
        return this;
    }

    private static void PrintHashTable(HashTable<string, int> table)
    {
        for (int i = 0; i <= table.Data.Length - 1; i++)
        {
            Text.WriteText($"List: {i}", true);

            var list = table.Data[i];
            var currentNode = list?.Head;

            while (currentNode?.Next != null)
            {
                Text.WriteText($"(key: {currentNode.Data.Key}, value: {currentNode.Data.Value}) -> ");
                currentNode = currentNode.Next;
            }
            if (currentNode?.Data != null)
            {
                Text.WriteText($"(key: {currentNode.Data.Key}, value: {currentNode.Data.Value})", true);
            }
        }
        Text.WriteText($"Total number of items: {table.Count}", true);
    }
}
