using System;
using System.IO;
using System.Collections;

namespace Prac2T3
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

            LL.MakeDemoLL();

            Console.ReadLine();
        }
    }

    class LinkedList
    {
        private Node head; //Points to first element in the LL if list is not empty

        public LinkedList CreateSt(ArrayList al)
        {
            LinkedList ll = new LinkedList();

            for(int i = 0; i < al.Count;i++)
            {
                ll.InsertAtFirst((double)al[i]);
            }

            return ll;
        }
        
        public void MakeDemoLL()
        {
            ArrayList al = new ArrayList();
            LinkedList ll = new LinkedList();
            double sum = 0, avg = 0;

            StreamReader sr = new StreamReader("Numbers.txt");
            double line = double.Parse(sr.ReadLine());

            while(line != 0)
            {
                al.Add(line);
                sum += line;

            }

            sr.Close();
            avg = sum / al.Count;
            ll = CreateSt(al);

            double GetSd(double avg1)
            {
                double inSum = 0, sd;
                for(int x = 0; x < al.Count;x++)
                {
                    inSum = Math.Pow(((double)al[x] - avg1), 2);
                }
                sd = Math.Sqrt((inSum)/(al.Count-1));

                return sd;
            }

            GetSd(avg);

            
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

        public double GetFirst()
        {
            if (head != null) return head.Cargo;
            else return 0;
        }

        public double GetLast()
        {
            if (head == null) return 0;
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

        public double GetAt(int pos)
        {
            if (head == null) return 0;
            else
            {
                Node temp = head;
                while (pos > 0)
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return 0;
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
        }

        public void InsertAtLast(double cargo)
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

        public bool InsertAt(int pos, double cargo)
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

        public double Search(double cargo)
        {
            Node temp = head;
            while ((temp != null) && (temp.Cargo != cargo))
            {
                temp = temp.next;
            }

            if (temp != null) return temp.Cargo;
            else return 0;
        }



    }

    class Node
    {
        public double Cargo;  //This linked list stores Strings
        public Node next;  //Reference to next list element
    }
}
