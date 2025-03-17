using System;

namespace Prac4T2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

        private static double GetPi(int num)
        {
            double sum = 0;

            if (sum == 0 )
                return 1;
            if( num % 2 != 0)
            {
                sum += GetPi(4 / num) - GetPi(4 / num + 2);
                num += 2;
            }
            else
            {
                sum += GetPi(4 / num) + GetPi(4 / num + 2);
                num += 2;
            }
            return sum;
        }
    }
}
