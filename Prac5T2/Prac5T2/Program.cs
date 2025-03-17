using System;

namespace Prac5T2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int CheckForPrimes(int m, int n)
        {
            if (n == m)
                return 0;
            if (n % m == 0)
                return 1;
            else
                return CheckForPrimes(m + 1, n);
        }
        public static void PrintPrimes(int num)
        {
            Console.WriteLine($"Primes numbers between 1 and {num} are");

            for(int x=2;x<=num;x++)
            {
                if (CheckForPrimes(2, x) == 0)
                    Console.WriteLine(" {0} ",x);
            }
        }
    }
}
