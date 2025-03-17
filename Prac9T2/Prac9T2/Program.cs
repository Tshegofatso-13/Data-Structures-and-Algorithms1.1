using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Prac9T2
{

    class Program
    {
        //Step 1: Instantiate the correct list
        static LinkedList linkedList1 = new LinkedList();
        static LinkedList linkedList2 = new LinkedList();
        static LinkedList mergedList = new LinkedList();
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


            //intersection of both lists with no duplicates
            Console.WriteLine("Start Intersection");
            newOne.MergeListIntersxn(linkedList1, linkedList2);
            Console.WriteLine("End of Intersection");


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

        public void InsertAtFirst(Object cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;
            newnode.next = head;
            head = newnode;

            if (newnode.next == null) tail = newnode;       //The list only contains one element so tail must point to same node as head
            Size++;
        }

        public void InsertAtLast(Object cargo)
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

        public bool InsertAt(int pos, Object cargo)
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

        public Object Search(Object find)
        {
            Node temp = head;
            while ((temp != null) && (!temp.Cargo.Equals(find)))    //Use Cargo's Equals() method to check for equality
            {
                temp = temp.next;
            }

            if (temp != null) return temp.Cargo;
            else return null;                                       //The element was not found
        }
        public Node MergeListIntersxn(LinkedList ll1, LinkedList ll2)
        {
            Node curFirst = ll1.head;
            Node curSecond = ll2.head;
            int PosFirstList = 0, PosSecondList = 0;

            while (curFirst != null && curSecond != null)
            {

                if ((double)curFirst.Cargo == (double)curSecond.Cargo)
                {
                    Console.Write($" {curFirst.Cargo.ToString()} ");
                    //mergedList.InsertAtLast(curFirst);
                    curFirst = curFirst.next;
                    curSecond = curSecond.next;
                    PosFirstList++;
                    PosSecondList++;

                }

                else
                    if ((double)curFirst.Cargo < (double)curSecond.Cargo)
                {
                    PosFirstList++;
                    curFirst = curFirst.next;
                }
                else
                {
                    PosSecondList++;
                    curSecond = curSecond.next;
                }

            }
            Console.WriteLine();
            return curFirst;
        }
        public void Display(LinkedList ll)
        {
            Node cur = ll.head;
            while (cur != null)
            {
                Console.WriteLine(cur.Cargo);
                cur = cur.next;
            }
        }

        public Object DeleteFirst()
        {
            if (head == null) return null;              //The list is empty. Delete fails
            else
            {
                Object tempCargo = head.Cargo;
                head = head.next;
                if (head == null) tail = null;          //There was only one element in the list. Now it is empty
                Size--;
                return tempCargo;
            }
        }

        public Object DeleteLast()
        {
            if (head == null) return null;              //The list is empty. Delete fails
            else if (head.next == null)                 //The list contains only one element
            {
                Object tempCargo = head.Cargo;
                head = null;
                tail = null;
                Size--;
                return tempCargo;
            }
            else
            {
                Node temp = head;
                while (temp.next.next != null)          //A reference to the last element in the list must be found
                {
                    temp = temp.next;
                }
                Object tempCargo = temp.next.Cargo;
                temp.next = null;                       //temp is now the new last element in the list
                tail = temp;
                Size--;
                return tempCargo;
            }
        }


        public Object DeleteAt(int pos)
        {
            if (head == null) return null;          //The list is empty. Delete fails

            if (pos == 0)                           //Deleting the first element in the lsit
            {
                Object tempCargo = head.Cargo;
                head = head.next;
                if (head == null) tail = null;      //The only element in the list was deleted
                Size--;
                return tempCargo;
            }
            else
            {
                pos--;                              // We want to find the node before the remove spot so that we can have a reference to the node to be deleted
                Node temp = head;
                while (pos > 0)
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return null;  //There is no element at pos. Delete fails
                }

                if (temp.next == null) return null; //There is no element at pos. Delete fails
                else
                {
                    Object tempCargo = temp.next.Cargo;
                    temp.next = temp.next.next;
                    if (temp.next == null) tail = temp; //The deleted node was the last element in the list
                    Size--;
                    return tempCargo;
                }
            }
        }

        public bool CompareTo(Node HeadofNode1, Node HeadofNode2)
        {
            if (HeadofNode1 == null && HeadofNode2 == null)
            {
                return true;
            }
            Node curNode1Runner = HeadofNode1;
            Node curNode2Runner = HeadofNode2;

            while (curNode1Runner != null && curNode2Runner != null)
            {
                if (curNode1Runner.Cargo != curNode2Runner.Cargo)
                    break;

                if (curNode1Runner.next == null && curNode2Runner.Cargo == null)
                {
                    return true;
                }

                curNode1Runner = curNode1Runner.next;
                curNode2Runner = curNode2Runner.next;
            }
            return false;
        }




    }
    class Node
    {
        public Object Cargo;  //This linked list stores Objects
        public Node next;  //Reference to next list element
    }
}

