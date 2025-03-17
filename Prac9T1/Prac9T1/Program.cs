using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Prac9T1
{

    class Program
    {
        //Step 1: Instantiate the correct list
        static LinkedList linkedList1 = new LinkedList();
        static LinkedList linkedList2 = new LinkedList();
        static LinkedList MergedList = new LinkedList();
        static void Main(string[] args)
        {
            LinkedList newOne = new LinkedList();

            //Step 2: Process the contents of the file
            /// ll 1
            StreamReader sr = new StreamReader("File1.txt");
            String line = sr.ReadLine();

            while (line != null)
            {
                String element = line;
                linkedList1.InsertAtLast(Convert.ToDouble(element));

                line = sr.ReadLine();
            }
            sr.Close();

            /// ll 2
            StreamReader sr2 = new StreamReader("File2.txt");
            String line2 = sr2.ReadLine();

            while (line2 != null)
            {
                String element2 = line2;
                linkedList2.InsertAtLast(Convert.ToDouble(element2));


                line2 = sr2.ReadLine();
            }


            sr2.Close();

            MergedList.MergeListUnion(linkedList1, linkedList2, MergedList);
            newOne.Display(MergedList);

            Console.ReadLine();
            //Step 3: Display the contents of the list

        }
    }

    class LinkedList
    {
        private Node head; //Points to first element in the LL if list is not empty
        private Node tail; //Points to last element in the LL if list is not empty
        protected int Size = 0; //Points to the size of the list
        public LinkedList()
        {
        }

        public Object GetFirst()
        {
            if (head != null) return head.Cargo;
            else return null;
        }

        public Object GetLast()
        {
            if (tail != null) return tail.Cargo;
            else return null;
        }

        public Object GetAt(int pos)
        {
            if (head == null) return null;  //The list is empty
            else
            {
                Node temp = head;
                while (pos > 0)     // Decrement pos and more to next node until pos == 0
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return null;  //There is no element at pos
                }

                return temp.Cargo;
            }
        }

        public void InsertAtFirst(double cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;
            newnode.next = head;
            head = newnode;

            if (newnode.next == null) tail = newnode;       //The list only contains one element so tail must point to same node as head
            Size++;
        }

        public void InsertAtLast(double cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;

            if (head == null)           //The list is empty
            {
                head = newnode;
                tail = newnode;
            }
            else
            {
                tail.next = newnode;
                tail = newnode;
            }
            Size++;
        }

        public bool InsertAt(int pos, double cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;

            if (pos == 0)
            {
                newnode.next = head;
                head = newnode;

                if (tail == null) tail = newnode;       //Check if this is the only element in the list

                Size++;
                return true;
            }
            else
            {
                if (head == null) return false;         //The list is empty and pos is not 0
                pos--;                                  // We want to find the node before the insert spot
                Node temp = head;
                while (pos > 0)
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return false;     //The is no node before the insert spot so insertion fails
                }

                if (temp == tail) tail = newnode;       //The node is to be added to the end of the list

                newnode.next = temp.next;
                temp.next = newnode;
                Size++;
                return true;
            }
        }

        public void MergeListUnion(LinkedList ll1, LinkedList ll2, LinkedList mergedList)
        {
            Node curFirst = ll1.head;
            Node curSecond = ll2.head;
            int PosFirstList = 0, PosSecondList = 0, PosMergeList = 0;

            while (curFirst != null && curSecond != null)
            {

                if (curFirst.Cargo == curSecond.Cargo)
                {
                    Node curFirstNext = curFirst.next;
                    curFirst.next = null;
                    mergedList.InsertAtLast(curFirst.Cargo);
                    curFirst = curFirstNext;
                    curSecond = curSecond.next;
                    PosFirstList++;
                    PosSecondList++;
                    PosMergeList++;
                }

                else
                    if (curFirst.Cargo < curSecond.Cargo)
                {
                    Node curFirstNext = curFirst.next;
                    curFirst.next = null;
                    mergedList.InsertAtLast(curFirst.Cargo);
                    curFirst = curFirstNext;
                    PosMergeList++;
                    PosFirstList++;
                }
                else
                {
                    Node curSecondNext = curSecond.next;
                    curSecond.next = null;
                    mergedList.InsertAtLast(curSecond.Cargo);
                    curSecond = curSecondNext;
                    PosMergeList++;
                    PosSecondList++;
                }
            }


            if (curFirst == null)
            {
                while (PosSecondList < ll2.Size)
                {
                    mergedList.InsertAtLast(curSecond.Cargo);
                    curSecond = curSecond.next;
                    PosMergeList++;
                    PosSecondList++;

                }
            }
            if (curSecond == null)
            {
                while (PosFirstList < ll1.Size)
                {
                    mergedList.InsertAtLast(curFirst.Cargo);
                    curFirst = curFirst.next;
                    PosMergeList++;
                    PosFirstList++;

                }
            }

        }
        public void Display(LinkedList ll)
        {

            Node cur = ll.head;
            int startPos = 0;
            Console.WriteLine();
            while (cur != null)
            {
                double testy = cur.Cargo;
                Console.Write($" {testy} ");
                cur = cur.next;
                startPos++;
            }
            Console.WriteLine();
        }


    }
    class Node
    {
        public double Cargo;  
        public Node next;  
    }
}

