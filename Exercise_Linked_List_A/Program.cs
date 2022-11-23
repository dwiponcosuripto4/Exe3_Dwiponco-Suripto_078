using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Linked_List_A
{
    class Node
    {
        /*create Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)/*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (previous = current = current.next)
                {
                    if (rollNo == current.rollNumber)
                        return (true);/*returns true if the node is found*/
                }
            }
        }
    }
}
