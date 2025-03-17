using System;
using System.Collections;

namespace Prac5T1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            GetDiv(4, 4);
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
        
        public static int GetDiv(int num, int i)
        {

            if(i==1 )
                return 1;
            if (num % i == 0)
                return num * GetDiv(num,i - 1);
            else
            return GetDiv(num,i - 1);
            
        }

    }
}
