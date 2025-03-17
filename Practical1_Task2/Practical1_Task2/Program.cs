using System;

namespace Practical1_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = new int[20];
            int[] ArrayPrimes = new int[20];

            int count = 0;
            int countPrimes = 0;
            double median=0;
            double sum = 0;


            for (int i = 0; i <= Array.Length - 1; i++)
            {
                Array[i] = count;
                count++;
            }

            for (int j = 0; j <= Array.Length - 1; j++)
            {
                if (Array[j] == 0 || Array[j] == 1)
                {
                    Console.WriteLine("Not prime number. ");
                }

                else
                    if (((Array[j] / 1) == Array[j]) && ((Array[j] / Array[j]) == 1))
                {
                    ArrayPrimes[countPrimes] = Array[j];
                    countPrimes++;
                }
            }

            for (int k = 0; k <= Array.Length - 1; k++)
            {
                int midPos = ArrayPrimes.Length / 2;
                double avg;
                

                if ((ArrayPrimes.Length % 2) == 0)
                {
                    median = (ArrayPrimes[midPos] + ArrayPrimes[midPos + 1]) / 2;
                    sum += ArrayPrimes[k];
                    

                }
                else
                    if(!((ArrayPrimes.Length % 2 )== 0))
                {
                    median = ArrayPrimes[midPos];
                    sum += ArrayPrimes[k];

                }
                avg = sum / ArrayPrimes.Length;

                Console.WriteLine($"The median is {median} with an average of {avg}");
            }

            Console.ReadLine();
        }
    }
}
