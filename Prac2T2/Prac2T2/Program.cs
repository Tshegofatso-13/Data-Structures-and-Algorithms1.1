using System;
using System.IO;
using System.Collections;

namespace Prac2T2

{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            LinkedList LL = new LinkedList();

            // LL.DisplayAll();
            //LL.MakeDemoLL();
            // LL.DisplayAll();
            // LL.MakeDemoLL2();
            // LL.DisplayAll();

            Console.WriteLine("First: " + LL.GetFirst());
            Console.WriteLine("Last: " + LL.GetLast());
            Console.WriteLine("At 2: " + LL.GetAt(2));
            Console.WriteLine("At 6: " + LL.GetAt(6));
            LL.InsertAtFirst("AC");
            LL.DisplayAll();
            LL.InsertAtLast("JS");
            LL.DisplayAll();
            LL.InsertAt(0, "8S");
            LL.DisplayAll();
            LL.InsertAt(3, "9S");
            LL.DisplayAll();
            LL.InsertAt(8, "10S");
            LL.DisplayAll();

            Console.WriteLine(LL.Search("JS"));

            Console.ReadLine();
        }
    }

    class LinkedList
    {
        protected int counter;
        protected Node head;        // points to first cell in the list
        protected Node tail;        // points to last cell in the list


        public LinkedList()
        {
            counter = 0;
            head = null;
            tail = null;
        }

        public void DisplayAll()
        {
            Console.WriteLine("Display List");
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.Cargo);
                temp = temp.next;
            }
        }

        public int Count()
        {
            return counter;
        }

        public Node GetFirst()
        {
            return head;

        }

        public Node GetLast()
        {
            return tail;

        }

        public String GetAt(int pos)
        {
            if (head == null) return null;
            else
            {
                Node temp = head;
                while (pos > 0)
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return null;
                }

                return temp.Cargo;
            }
        }

        public void InsertAtFirst(Object newItem)
        {
            
                Cell newNode = new Cell(newItem);
                newNode.setNext(head);
                if (head != null)
                    head.setPrevious(newNode);
                else
                    tail = newNode;
                head = newNode;
                counter++;
            
        }

        public void InsertAtLast(Object newItem)
         {
            if (tail == null)
            {
                InsertAtFirst(newItem);
                return;
            }
            Cell newCell = new Cell(newItem);
            newCell.setPrevious(tail);
            tail.setNext(newCell);
            tail = newCell;
            counter++;
        }
        public bool InsertAt(int pos, String cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;

            if (pos == 0)
            {
                newnode.next = head;
                head = newnode;
                return true;
            }
            else
            {
                if (head == null) return false;
                pos--; // We want to find the node before the insert spot
                Node temp = head;
                while (pos > 0)
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return false;
                }

                newnode.next = temp.next;
                temp.next = newnode;
                return true;
            }
        }

        public String Search(String cargo)
        {
            Node temp = head;
            while ((temp != null) && (temp.Cargo != cargo))
            {
                temp = temp.next;
            }

            if (temp != null) return temp.Cargo;
            else return null;
        }



    }

    class Node
    {
        public String Cargo;  //This linked list stores Strings
        public Node next;  //Reference to next list element

        internal void setNext(Cell newCell)
        {
            throw new NotImplementedException();
        }

        internal void setPrevious(Cell newNode)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Node(Cell v)
        {
            throw new NotImplementedException();
        }
    }
}
