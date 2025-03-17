using System;
using System.IO;
using System.Collections;

namespace Prac4T1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter input number :");
            int num2 = int.Parse(Console.ReadLine());

            int evalNum;

            if (num2 % 2 == 0)
                evalNum = GetSum(num2);
            else
                evalNum = GetSum(num2 - 1);

            Console.WriteLine($"Evaluated sum is {evalNum}");
            Console.ReadLine();
        }

        private static int GetSum(int num)
        {
            if (num == 0)
                return 0;

                return num + GetSum(num - 1);

        }
    }
}
