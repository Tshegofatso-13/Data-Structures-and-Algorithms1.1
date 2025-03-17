using System;

namespace Act1T7
{
   
    class Program
    {
        static int[] cents = new int[10];
        static void Main(string[] args)
        {
            Console.Write("hu");
            getArrayInput();
        }
        public static void getArrayInput()
        {
            for(int i = 0; i <=cents.Length-1;i++)
            {
                Console.WriteLine("Enter cents :");
                int input = int.Parse(Console.ReadLine());

                if(input > 0 && input <= 500)
                {
                    cents[i] = input;
                }
            }
        }
        public static void getTotal()
        {
            double sum = 0;

            for(int i=0;i<=cents.Length-1;i++)
            {
                sum += cents[i];
            }

            Console.WriteLine("The total sum is {0:C2}", sum);
        }
        public static void getCount()
        {
            int count = 0;
            for(int i=0;i<=cents.Length-1;i++)
            {
                if(cents[i] < 1.00)
                {
                    count++;
                    
                }
            }
            Console.WriteLine($"There are {count} elements with currency less than R1.00 ");
        }
        public static int getMin()
        {
            int minVal = int.MaxValue;

            for (int i = 0; i <= cents.Length - 1; i++)
            {
                if(cents[i] < minVal)
                {
                    minVal = cents[i];
                }
            }

            return minVal;
        }
    }
}
