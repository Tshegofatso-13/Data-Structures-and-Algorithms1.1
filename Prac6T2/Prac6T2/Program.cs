using System;
using System.IO;

namespace L7Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int j = 0; j < 2; j++)  //The process will be repeated twice. The first time using an array-based list and and the second time using a linked list implementation.
            {
                //Step 1: Instantiate the correct list
                WRAV201List thelist;
                if (j == 0) thelist = new WRAV201ArrayList();
                else thelist = new WRAV201LinkedList();

                //Step 2: Process the contents of the file
                StreamReader sr = new StreamReader("Commands.txt");
                String line = sr.ReadLine();

                while (line != null)
                {
                    String[] elements = line.Split(",");
                    if (elements[0] == "InsertFront")
                    {
                        thelist.InsertAtFirst(elements[1]);
                    }
                    else if (elements[0] == "DeleteAt")
                    {
                        thelist.DeleteAt(int.Parse(elements[1]));
                    }
                    else if (elements[0] == "InsertAt")
                    {

                        thelist.InsertAt(int.Parse(elements[1]), elements[2]);
                    }
                    else if (elements[0] == "DeleteFront")
                    {
                        thelist.DeleteFirst();
                    }
                    else if (elements[0] == "InsertEnd")
                    {
                        thelist.InsertAtLast(elements[1]);
                    }
                    else if (elements[0] == "DeleteEnd")
                    {
                        thelist.DeleteLast();
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                        Console.ReadLine();
                    }

                    line = sr.ReadLine();
                }
                sr.Close();

                //Step 3: Display the contents of the list
                if (thelist is WRAV201ArrayList) Console.WriteLine("ArrayList Contents:");
                else Console.WriteLine("LinkedList Contents:");


                //BLOCK B BEGIN: Comment out this block to test your solution to Task 3
                for (int i = 0; i < thelist.Count(); i++)
                {
                    String temp = (String)thelist.GetAt(i);
                    Console.WriteLine(temp);
                }
                Console.WriteLine();
                //BLOCK B END

                /*BLOCK C: Uncomment this block to test your solution to Task 3          
                Console.WriteLine("Displaying using Iterator");
                WRAV201Iterator iterator = thelist.GetIterator();
                while(iterator.HasMoreElements())
                {
                    String temp = (String)iterator.GetNextElement();
                    Console.WriteLine(temp);
                }
                Console.WriteLine();
                */


                /* BLOCK A:  Uncomment this block to test your solution to Task 2
                if (thelist is WRAV201ArrayList)
                {
                    WRAV201LinkedList temp = ((WRAV201ArrayList)thelist).GetLinkedListClone();
                    thelist = temp;
                }
                else
                {
                    WRAV201ArrayList temp = ((WRAV201LinkedList)thelist).GetArrayListClone();
                    thelist = temp;
                }

                Console.WriteLine("Cloned Version:");

                for (int i = 0; i < thelist.Count(); i++)
                {
                    String temp = (String)thelist.GetAt(i);
                    Console.WriteLine(temp);
                }
                Console.WriteLine();
                */
            }
            //Step 4: Display the number of times that a list was instantiated in this program
            Console.WriteLine(WRAV201List.NumberOfInstances);

            Console.ReadLine();
        }
    }
}
