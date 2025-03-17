using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Prac9T3
{
    class Program
    {
        static void Main(string[] args)
        {
            int colLength = 21; int rowLength = 21;

            double[,] inputMatrix = new double[colLength, rowLength];

            int row = 11, col = 11, maxVisit = int.MinValue, rowCount = 0, colCount = 0;

            StreamReader sr = new StreamReader("Instructions.txt");
            String line = sr.ReadLine();

            

            while (line != null)
            {
                if (line.Equals("West"))
                {
                    if (row == 0) 
                    {
                        inputMatrix[col, row] = inputMatrix[col, row] + 1;
                    }
                    else
                    {
                        inputMatrix[col, row] = inputMatrix[col, row] + 1;
                        row--;
                    }
                }

                else
                    if (line.Equals("East"))
                {
                    if (row == 20) 
                    {

                        inputMatrix[col, row] = inputMatrix[col, row] + 1;
                    }
                    else
                    {
                        inputMatrix[col, row] = inputMatrix[col, row] + 1;
                        row++;
                    }
                }


                else
                    if (line.Equals("North"))
                {
                    if (col == 0) 
                    {
                        inputMatrix[col, row] = inputMatrix[col, row] + 1;
                    }
                    else

                    {
                        inputMatrix[col, row] = inputMatrix[col, row] + 1;
                        col--;

                    }
                }

                if (line.Equals("South"))
                {
                    if (col == 20) 
                    {
                        inputMatrix[col, row] = inputMatrix[col, row] + 1;
                    }
                    else
                    {
                        inputMatrix[col, row] = inputMatrix[col, row] + 1;
                        col++;
                    }
                }


                line = sr.ReadLine();
            }
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Robo matrix path starts");
            Console.WriteLine("---------------------------------------------------------");
            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (inputMatrix[i, j] > 0)
                    {
                        Console.Write("*");
                    }
                    else
                        Console.Write("+");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (inputMatrix[i, j] > maxVisit)
                    {
                        maxVisit = (int)inputMatrix[i,j];
                        rowCount = j;
                        colCount = i;
                    }
                    
                }
            }

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Robo matrix path ends");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"cell most frequented is ({colCount},{rowCount}) which is visited {maxVisit} times");
            Console.ReadLine();
        }
        
    }

    class Node
    {
        public String Cargo;
        public double CellCount;
    }
}

