using System;
using System.IO;
using System.Collections;

namespace Prac2T1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
            Console.ReadLine();
        }

        public Program()
        {
            SinglyLinkedList LL = new SinglyLinkedList();
            LL.LoadLLFirst();
            LL.LoadLLLast();
            Console.ReadLine();

           
        }
    }

   public class SinglyLinkedList
    {
        private Node head;

        public SinglyLinkedList()
        {
            head = null;
        }

        public SinglyLinkedList Convert2LL(ArrayList al)
        {
            SinglyLinkedList ll = new SinglyLinkedList();

            for(int x = 0; x < al.Count;x++)
            {
                
                ll.InsertAtFirst((String)al[x]);
            }
            return ll;
        }
        public SinglyLinkedList Convert2LL2(ArrayList al)
        {
            SinglyLinkedList ll = new SinglyLinkedList();

            for (int x = 0; x < al.Count; x++)
            {

                ll.InsertAtLast((String)al[x]);
            }
            return ll;
        }

        public void LoadLLFirst()
        {
            long start = DateTime.Now.Ticks;

            ArrayList al = new ArrayList();
            
            StreamReader sr = new StreamReader("Dictionary.txt");
            String line = sr.ReadLine();

            while (line != null)
            {
               al.Add(line);
               line = sr.ReadLine();
                   
            }

            sr.Close();
            Convert2LL(al);
            long end = DateTime.Now.Ticks;

            Console.WriteLine("File reading time for InsertFirst: " + (end - start) / 10000);
            Console.WriteLine("Done");
        }

        public void LoadLLLast()
        {
            long start = DateTime.Now.Ticks;

            ArrayList al = new ArrayList();
            
            StreamReader sr = new StreamReader("Dictionary.txt");
            String line = sr.ReadLine();

            while( line != null)
            {
                al.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            Convert2LL2(al);

            long end = DateTime.Now.Ticks;

            Console.WriteLine("File reading time for InsertLast: " + (end - start) / 10000);
            
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

        public String GetFirst()
        {
            if (head != null) return head.Cargo;
            else return null;
        }

        public String GetLast()
        {
            if (head == null) return null;
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                return temp.Cargo;
            }
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

        public void InsertAtFirst(String cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;
            newnode.next = head;
            head = newnode;
        }

        public void InsertAtLast(String cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;

            if (head == null) head = newnode;
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                temp.next = newnode;
            }
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
    }
}