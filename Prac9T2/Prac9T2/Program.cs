using System;
using System.IO;

namespace Prac9T2
{
    class Program
    {
        static void Main(string[] args)
        {

            
            double curFirst, curSecond;
            int PosFirstList = 0, PosSecondList = 0;

            StreamReader sr1 = new StreamReader("File1.txt");
            double line1 = double.Parse(sr1.ReadLine());

            StreamReader sr2 = new StreamReader("File2.txt");
            double line2 = double.Parse(sr2.ReadLine());

            curFirst = line1;
            curSecond = line2;

            while (!sr1.EndOfStream && !sr2.EndOfStream)
            {
                
                if (curFirst == curSecond)
                {
                    Console.Write($" {curFirst} ");
                    
                    line1 = double.Parse(sr1.ReadLine());
                    line2 = double.Parse(sr2.ReadLine());
                    curFirst = line1;
                    curSecond = line2;
                    PosFirstList++;
                    PosSecondList++;

                }

                else
                    if (curFirst < curSecond)
                {
                    PosFirstList++;
                    line1 = double.Parse(sr1.ReadLine());
                    curFirst = line1;
                }
                else
                {
                    line2 = double.Parse(sr2.ReadLine());
                    curSecond = line2;
                }

            }
            
            Console.ReadLine();
            

        }
    }

}

