using noob.Models;
using noob.Utils;

namespace noob.Pages;

public class LinkedListPage : IPage
{
    public IPage PrintTitle()
    {
        Text.WriteH1("LinkedLists");

        return this;
    }

    public IPage PrintBody()
    {
        Text.WriteH2("Appending to tail");

        var singlyLinkedList = new SinglyLinkedList<int>(1).Append(2).Append(10).Append(5);
        PrintLinkedList(singlyLinkedList);

        var doublyLinkedList = new DoublyLinkedList<int>(1).Append(2).Append(10).Append(5);
        PrintLinkedList(doublyLinkedList);

        Text.WriteH2("Deleting a node");

        singlyLinkedList.Delete(10);
        PrintLinkedList(singlyLinkedList);

        doublyLinkedList.Delete(10);
        PrintLinkedList(doublyLinkedList);

        return this;
    }

    static void PrintLinkedList(ILinkedList<int> linkedList)
    {
        var isSinglyList = linkedList.GetType().Name == typeof(SinglyLinkedList<int>).Name;
        Text.WriteH3(isSinglyList ? "Singly Linked List" : "Doubly Linked List");

        Text.WriteText("Forwards: ");
        var current = linkedList.Head;
        while (current.Next != null)
        {
            Text.WriteText($"({current.Data}) -> ");
            current = current.Next;
        }
        Text.WriteText($"({current.Data})");
        Text.NewLine();

        Text.WriteText("Backwards: ");
        while (current.Previous != null)
        {
            Text.WriteText($"({current.Data}) -> ");
            current = current.Previous;
        }
        Text.WriteText($"({current.Data})");
        Text.NewLine();
    }
}
