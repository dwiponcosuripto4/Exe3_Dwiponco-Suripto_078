﻿using System;
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
        public Node prev;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        public void addNode()
        {
            int rollNo;
            string name;
            Console.Write("\nEnter the name of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            name = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = name;
            /*Checks if the list empty*/
            if (LAST == null || rollNo <= LAST.rollNumber)
            {
                if ((LAST != null) && (rollNo == LAST.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
                newnode.next = LAST;
                if (LAST != null)
                    LAST.prev = newnode;
                newnode.prev = null;
                LAST = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = LAST; current != null &&
                rollNo >= current.rollNumber; previous = current, current =
                current.next)
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            /*On the execution of the above for loop, prev and
             * current will point to those nodes
             between which the new node is to interseted.*/
            newnode.next = current;
            newnode.prev = previous;

            /*if the node is to be interested at the end of the list.*/
            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)/*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*If the node is present at the end*/
                return true;
            else
                return (false);/*returns false if the node is not found*/
            }
            public bool listEmpty()
            {
                if (LAST == null)
                    return true;
                else
                    return false;
            }

            public void traverse()/*Traverses all the node of the list*/
            {
                if (listEmpty())
                    Console.WriteLine("\nList is empty");
                else
                {
                    Console.WriteLine("\nRecord in the list are:\n");
                    Node currentNode;
                    currentNode = LAST.next;
                    while (currentNode != LAST)
                    {
                        Console.Write(currentNode.rollNumber + "   " + currentNode.name + "\n");
                        currentNode = currentNode.next;
                    }
                    Console.Write(LAST.rollNumber + "   " + LAST.name + "\n");
                }
            }
            public void firstNode()
            {
                if (listEmpty())
                    Console.WriteLine("\nList is empty");
                else
                    Console.WriteLine("\nThe first record in the list is:\n\n " + LAST.next.rollNumber + "   " + LAST.next.name);
            }
            static void Main(string[] args)
            {
                CircularList obj = new CircularList();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. View all the records in the list");
                        Console.WriteLine("2. Search for a record in the list");
                        Console.WriteLine("3. Display the first record in the list");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("5. Add a record to the list");
                        Console.Write("\n Enter your choice (1-4): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Node prev, curr;
                                    prev = curr = null;
                                    Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref prev, ref curr) == false)
                                        Console.WriteLine("\nRecord not found");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    }
                                }
                                break;
                            case '3':
                                {
                                    obj.firstNode();
                                }
                                break;
                            case '4':
                                return;
                        
                            break;
                            default:
                                {
                                    Console.WriteLine("Invalid option");
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
    }
