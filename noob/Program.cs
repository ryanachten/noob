using noob.Models;
using noob.Pages;
using noob.Utils;

Text.WriteLogo();

//new LinkedListPage().PrintTitle().PrintBody();
//new ArrayListPage().PrintTitle().PrintBody();

static void PrintHashTable(HashTable<int> table)
{
    for (int i = 0; i <= table.Data.Length - 1; i++)
    {
        Text.WriteText($"List: {i}", true);

        var list = table.Data[i];
        var currentNode = list?.Head;

        while (currentNode?.Next != null)
        {
            Text.WriteText($"{currentNode.Data} -> ");
            currentNode = currentNode.Next;
        }
        Text.WriteText($"{currentNode?.Data}", true);
    }
    Text.WriteText($"Total number of items: {table.Count}", true);
}

var hash = new HashTable<int>();
var rand = new Random();
for (int i = 0; i < 100; i++)
{
    hash.Add(rand.Next(-1000, 1000));
}
PrintHashTable(hash);







