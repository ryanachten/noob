using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noob.Models
{
    public class Node
    {
        public int Data;
        public Node? Next;
        public Node? Previous;

        public Node(int data)
        {
            Data = data;
        }
    }
}
