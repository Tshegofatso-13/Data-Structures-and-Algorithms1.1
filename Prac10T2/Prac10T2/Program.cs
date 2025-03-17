using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Prac10T2
{
    class Program
    {
        static int rowLength = 77, colLength = 10, colCount = 0, countSalesMan = 0, countProductSales;// counts row and column  sums
        static double[,] arrayOfFoodItemsGrid = new double[colLength, rowLength];

        static void Main(string[] args)
        {
            double[,] codeArray = new double[77,1];


            StreamReader sr = new StreamReader("Products.txt");
            String line = sr.ReadLine();
            int arrayCount = 0;


            while (line != null)
            {
                String[] elements = line.Split(",");
                double temp = double.Parse(elements[0]);
                codeArray[arrayCount,0] = temp; //contains column matrix of just the item codes corresponding to distributor/salesman code 
                arrayCount++;

                line = sr.ReadLine();
            }

            bubbleSort(codeArray);

            //assign each matrix value to its column

            for (int i = 1; i <= 10; i++)
            {
                double tempFoodArrayMover, tempDistMover;
                StreamReader sr1 = new StreamReader($"File{i}.txt");
                String line1 = sr1.ReadLine();
                arrayCount = 0;
                countSalesMan = 0;

                Console.WriteLine($"---------------------------------------Distributor {i}-----------------------------------------");
                Console.WriteLine();
                while (line1 != null)
                {

                    DistributorItems tempDistributor;
                    String[] foodElemements = line1.Split(",");
                    tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                    tempFoodArrayMover = codeArray[arrayCount, 0];
                    tempDistMover = tempDistributor.Code;


                    if (tempFoodArrayMover == tempDistMover)
                    {
                        arrayOfFoodItemsGrid[colCount, arrayCount] = tempDistributor.QuantitySold;
                        countSalesMan += (int)tempDistributor.QuantitySold;
                        arrayCount++;
                        line1 = sr1.ReadLine();


                    }
                    else
                    {
                        arrayOfFoodItemsGrid[colCount, arrayCount] = 0;// place condition to show star, mayber assign zero and check outside of loop
                        arrayCount++;
                    }

                }

                sr1.Close();
                colCount++;
                Console.WriteLine($"Sales by salesman {i} : {countSalesMan}");
 
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < rowLength; i++)
            {
                countProductSales = 0;
                for (int j = 0; j < colLength; j++)
                {
                    countProductSales += (int)arrayOfFoodItemsGrid[j, i];

                }
                Console.WriteLine($"Sales for product {codeArray[i, 0]} : {countProductSales}");
            }
            Console.WriteLine("");
            Console.ReadLine();
            


        }

        public static void bubbleSort(double[,] al2)
        {
            for (int i = 0; i < al2.Length; i++)
            {
                for (int j = 0; j < al2.Length - 1; j++)
                {
                    if (al2[j, 0].CompareTo(al2[j + 1, 0]) > 0) // overload compare method access the items
                    {
                        double temp = al2[j, 0];
                        al2[j, 0] = al2[j + 1, 0];
                        al2[j + 1, 0] = temp;

                    }
                }
            }
        }

    }
    public class foodItem : IComparable
    {
        public int Code;
        public String Descr;
        public double Price;
        public double PercentProfit;


        public foodItem(int Code, String Descr, double Price, double PercentProfit)
        {
            this.Code = Code;
            this.Descr = Descr;
            this.Price = Price;
            this.PercentProfit = PercentProfit;

        }

        public foodItem()
        {
        }

        public int CompareTo(Object obj)
        {
            foodItem ft = (foodItem)obj;

            if (this.Code < ft.Code)
                return -1;
            else
                if (this.Code > ft.Code)
                return 1;
            else
                return 0;
        }
    }
    public class DistributorItems
    {
        public double Code;
        public double QuantitySold;

        public DistributorItems()
        {
        }

        public DistributorItems(double Code, double QuantitySold)
        {
            this.Code = Code;
            this.QuantitySold = QuantitySold;
        }

    }

}


