using System;
using System.Collections;

namespace Prac4T3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
        public static int MinRecurssion(Node head, int min)
        {
            min = 9999999;
            
            if(head == null)
            {
                return min;
            }
            if(head.next < min)
            {
                min = head.data;
            }
            return MinRecurssion(head.next, min);
        }
    }
    public class Node
    {
        int data; Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

}
