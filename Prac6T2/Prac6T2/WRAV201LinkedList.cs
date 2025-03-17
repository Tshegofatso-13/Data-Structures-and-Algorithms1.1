using System;
using System.Collections.Generic;
using System.Text;

namespace L7Ex2
{
    class WRAV201LinkedList : WRAV201List
    {
        private Node head; //Points to first element in the LL if list is not empty
        private Node tail; //Points to last element in the LL if list is not empty
        public WRAV201LinkedList() : base()
        {
        }

        public override Object GetFirst()
        {
            if (head != null) return head.Cargo;
            else return null;
        }

        public override Object GetLast()
        {
            if (tail != null) return tail.Cargo;
            else return null;
        }

        public override Object GetAt(int pos)
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

        public override void InsertAtFirst(Object cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;
            newnode.next = head;
            head = newnode;

            if (newnode.next == null) tail = newnode;       //The list only contains one element so tail must point to same node as head
            Size++;
        }

        public override void InsertAtLast(Object cargo)
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

        public override bool InsertAt(int pos, Object cargo)
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

        public override Object Search(Object find)
        {
            Node temp = head;
            while ((temp != null) && (!temp.Cargo.Equals(find)))    //Use Cargo's Equals() method to check for equality
            {
                temp = temp.next;
            }

            if (temp != null) return temp.Cargo;
            else return null;                                       //The element was not found
        }

        public override Object DeleteFirst()
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

        public override Object DeleteLast()
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

        public override Object DeleteAt(int pos)
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

        public WRAV201ArrayList GetArrayListClone()
        // Post Condition: returns an WRAV201ArrayList object that contains the same elements as the current linked list
        {
            WRAV201List ll = new WRAV201List();

            WRAV201ArrayList myAL = new WRAV201ArrayList();

            WRAV201ArrayList temp;
            

            for(int i = 0; i < ll.Count(); i++)
            {
                temp = (WRAV201ArrayList)ll.GetAt(i);
                myAL.InsertAtLast(temp);
                
            }

            return (WRAV201ArrayList)myAL;
        }

        
        public override WRAV201Iterator GetIterator()
        {
            // Creating and adding elements in list
            List<WRAV201Iterator> mylist = new List<WRAV201Iterator>();

            // Iterating the elements of mylist
            foreach (var items in mylist)
            // Returning the element after every iteration
                yield return items;
            
        }
        public void WRAV201LinkedListIterator()
        {

        }
        

    }

    class Node
    {
        public Object Cargo;  //This linked list stores Objects
        public Node next;  //Reference to next list element
    }
}
