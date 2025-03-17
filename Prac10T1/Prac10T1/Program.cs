using System;
using System.IO;
using System.Collections;


namespace Prac10T1
{
    
    class Program
    {
        static int arraySize = 77;
        static foodItem[] arrayOfFoodItems = new foodItem[arraySize];
        static void Main(string[] args)
        {
            LoadItems();
            ProcessFiles();
            Console.ReadLine();
        }
        public static void LoadItems()
        {
            StreamReader sr = new StreamReader("Products.txt");
            String line = sr.ReadLine();
            int arrayCount = 0;

            while(line != null)
            {
                String[] foodElemements = line.Split(",");
                foodItem temp = new foodItem(int.Parse(foodElemements[0]), foodElemements[1], double.Parse(foodElemements[2]),double.Parse(foodElemements[3]));
                arrayOfFoodItems[arrayCount] = temp;
                arrayCount++;

            }

            bubbleSort(arrayOfFoodItems);
        }
        public static void bubbleSort(foodItem[] al2)
        {
            for (int i = 0; i < al2.Length; i++)
            {
                for (int j = 0; j < al2.Length - 1; j++)
                {
                    if (al2[j].Code.CompareTo(al2[j + 1].Code) > 0) // overload compare method access the items
                    {
                        foodItem temp = al2[j];
                        al2[j] = al2[j + 1];
                        al2[j + 1] = temp;
                        
                    }
                }
            }
        }

        public void selectionSort(foodItem[] al2)
        {
            for (int i = 0; i < al2.Length - 1; i++)
            {
                int minPos = i;
                for (int j = i + 1; j < al2.Length; j++)
                    if (al2[j].Code.CompareTo(al2[minPos].Code) < 0)
                        minPos = j;
                if (minPos != i)
                {
                    foodItem temp = al2[i];
                    al2[i] = al2[minPos];
                    al2[minPos] = temp;
                }
            }
        }

        public void insertSort(foodItem[] al2)
        {
            for (int i = 1; i < al2.Length; i++)
            {
                foodItem v = al2[i];
                int j;
                for (j = i - 1; i >= 0; j--)
                {
                    if (al2[j].Code.CompareTo(v) <= 0) /// ??
                        break;
                }
                al2[j + 1] = v;
            }
        }
        public static void ProcessFiles()
        {
            StreamReader sr1 = new StreamReader("File1.txt");
            String line1 = sr1.ReadLine();

            int arrayCount, distCount = 0;
            double tempFood, tempDistMover,itemProfit = 0,sumProfit = 0;
            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();
            while (!sr1.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String [] foodElemements = line1.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line1 = sr1.ReadLine();
                    

                }
                else
                {
                    arrayCount++;
                }

            }

            Console.WriteLine($"total profit for Distributor 1 is {itemProfit}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();

            StreamReader sr2 = new StreamReader("File2.txt");
            String line2 = sr2.ReadLine();

            while (!sr2.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line2.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.Write($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line2 = sr2.ReadLine();
                }

                else
                {
                    arrayCount++;
                }

            }
            Console.WriteLine($"total profit for Distributor 2 is {itemProfit}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();

            StreamReader sr3 = new StreamReader("File3.txt");
            String line3 = sr3.ReadLine();

            while (!sr3.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line3.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line3 = sr3.ReadLine();


                }
                else
                {
                    arrayCount++;
                }

            }

            Console.WriteLine($"total profit for Distributor 3 is {itemProfit}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();


            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();
            StreamReader sr4 = new StreamReader("File4.txt");
            String line4 = sr4.ReadLine();

            while (!sr4.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line4.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line4 = sr4.ReadLine();


                }

                else
                {
                    arrayCount++;
                }
            }
            Console.WriteLine($"total profit for Distributor 4 is {itemProfit}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();


            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();

            StreamReader sr5 = new StreamReader("File5.txt");
            String line5 = sr5.ReadLine();

            while (!sr5.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line5.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line5 = sr5.ReadLine();
                }

                else
                {
                    arrayCount++;
                }

            }

            Console.WriteLine($"total profit for Distributor 5 is {itemProfit}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();

            StreamReader sr6 = new StreamReader("File6.txt");
            String line6 = sr6.ReadLine();

            while (!sr6.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line6.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line6 = sr6.ReadLine();


                }

                else
                {
                    arrayCount++;
                }
            }
            Console.WriteLine($"total profit for Distributor 6 is {itemProfit}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();
            StreamReader sr7 = new StreamReader("File7.txt");
            String line7 = sr7.ReadLine();

            while (!sr7.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line7.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line7 = sr7.ReadLine();


                }

                else
                {
                    arrayCount++;
                }
            }
            Console.WriteLine($"total profit for Distributor 7 is {itemProfit}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();

            StreamReader sr8 = new StreamReader("File8.txt");
            String line8 = sr8.ReadLine();

            while (!sr8.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line8.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line8 = sr8.ReadLine();


                }

                else
                {
                    arrayCount++;
                }
            }
            Console.WriteLine($"total profit for Distributor 8 is {itemProfit}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();

            StreamReader sr9 = new StreamReader("File9.txt");
            String line9 = sr9.ReadLine();

            while (!sr9.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line9.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line9 = sr9.ReadLine();


                }

                else
                {
                    arrayCount++;
                }

            }
            Console.WriteLine($"total profit for Distributor 9 is {itemProfit:C2}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"---------------------------------------Distributor {distCount++}-----------------------------------------");
            Console.WriteLine();

            StreamReader sr10 = new StreamReader("File10.txt");
            String line10 = sr10.ReadLine();

            while (!sr10.EndOfStream)
            {
                arrayCount = 0;
                DistributorItems tempDistributor;
                String[] foodElemements = line10.Split(",");
                tempDistributor = new DistributorItems(double.Parse(foodElemements[0]), double.Parse(foodElemements[1]));


                tempFood = arrayOfFoodItems[arrayCount].Code;
                tempDistMover = tempDistributor.Code;


                if (tempFood == tempDistMover)
                {
                    itemProfit = (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    sumProfit += (arrayOfFoodItems[arrayCount].Price) * (tempDistributor.QuantitySold) * (arrayOfFoodItems[arrayCount].PercentProfit / 100.00);
                    Console.WriteLine($" Item Profit : {itemProfit} @ a percentage of {arrayOfFoodItems[arrayCount].PercentProfit} with {tempDistributor.QuantitySold} items sold");
                    arrayCount++;
                    line10 = sr10.ReadLine();


                }

                else
                {
                    arrayCount++;
                }

            }

            Console.WriteLine($"total profit for Distributor 10 is {itemProfit:C2}");
            Console.WriteLine();
            Console.WriteLine($"total profit for all distributors is {sumProfit:C2}");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
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
