using System;
using System.IO;
using System.Collections;


namespace Practical1_Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            new Program();
        }

        public Program()
        {
            FoodTruck FT = new FoodTruck();
            Console.WriteLine("Hello World");
            FT.LoadFoodItems();
            Console.WriteLine("Food Items Loaded Successfully!");

            int option = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Food Truck! What would you like to do?");
                Console.WriteLine("1. Display all food items."); //good
                Console.WriteLine("2. Set up menu for the day."); // almost
                Console.WriteLine("3. Display the menu based on category."); //unsure
                Console.WriteLine("4. Record sales.");//
                Console.WriteLine("5. Determine food items to restock."); // ok
                Console.WriteLine("6. Terminate processing."); // good

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        FT.DisplayMenuItems();
                        break;
                    case 2:
                        FT.SaveNewEntry();
                        break;
                    case 3:
                        FT.DisplayMenuToday();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Please enter a keyword");
                        FT.UpdateQuantity(Console.ReadLine());
                        break;
                    case 5:
                        FT.SaveOutOfStock();
                        break;
                    case 6:
                        Environment.Exit(6);
                        break;
                    default:
                        option = 0;
                        Console.WriteLine("Selection: ");
                        break;
                }


            } while (option != 0);


            Console.ReadLine();
        }
    }

    class FoodTruck
    {
        FoodItem[] NewFoodItem = new FoodItem[18];
        int count = 0;


        private void AddToList(FoodItem b)
        {
            NewFoodItem[count] = b;
            count++;

        }

        public void LoadFoodItems()
        {
            StreamReader sr = new StreamReader("Items.txt");
            String line = sr.ReadLine();


            while(line != null)
            {
                String[] elementsInFood = line.Split(",");
                FoodItem Temp;

                Temp = new FoodItem(elementsInFood[0], elementsInFood[1], elementsInFood[2], int.Parse(elementsInFood[3]), double.Parse(elementsInFood[4]));

                AddToList(Temp);

                //Console.WriteLine($"Code : {cde}  Descr : {desc}  Cate : {cate}  Stock : {QuanInStck}  Price : {prc}  ");
                line = sr.ReadLine();


            }
            sr.Close();
        }

        public void DisplayMenuItems()
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine($"Code : {NewFoodItem[i].GetCode()}  Descr : {NewFoodItem[i].GetDescrptn()}  Cate : {NewFoodItem[i].GetCategry()}  Stock : {NewFoodItem[i].GetQuanttInStock()}  Price : {NewFoodItem[i].GetPrice()}  ");
            }

        }

        public int FindFoodCode(String SearchKey)
        {
            for(int i = 0; i < count; i++)
            {
                if (NewFoodItem[i].GetCode().Contains(SearchKey))
                    return i;
                
            }
            return -1;
        }

        public void SaveNewEntry()
        {
            int location;
            String choice;
            
            
            do
            {
                Console.WriteLine("Please enter food code or -1 to terminate...");
                choice = Console.ReadLine();

                location = FindFoodCode(choice);



                if (NewFoodItem[location].GetQuanttInStock() == 0)
                {
                    Console.WriteLine($"Food item with code {NewFoodItem[location].GetCode()} does not have sufficient stock");

                }

                else
                    if (NewFoodItem[location].GetCode().Equals(0))
                {
                    Console.WriteLine($" Could not find item with code {choice}");
                }
                    

                
                else
                    if (NewFoodItem[location].GetCode() == null)
                {
                    FoodItem Temp;

                    Temp = new FoodItem(choice);

                    AddToList(Temp);

                    Console.WriteLine("Please enter food code or -1 to terminate...");
                    choice = Console.ReadLine();


                    Console.WriteLine($"Quantity with code {choice} is already in stock. ");

                }

                else
                    if (NewFoodItem[location].GetQuanttInStock() > 0)
                {

                    Console.WriteLine($"Quantity with code {choice} is already in stock. ");
                }
                else
                    Console.WriteLine($" Could not find item with code {choice}");

                Console.WriteLine("press enter to continue.....press -1 to terminate");
                choice = Console.ReadLine();
            }

            while (location > 0 || choice.Equals("-1")); 
            

            
        }

        public void DisplayMenuToday()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Breakfast");
            Console.WriteLine("--------------------");
            for (int i = 0; i < count; i++)
            {

                if (NewFoodItem[i].GetCategry().Equals("Breakfast"))
                    {
                    
                    Console.WriteLine($"{NewFoodItem[i].GetDescrptn()} @ R {NewFoodItem[i].GetPrice()}");
                    
                    }
                
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("Lunch");
            Console.WriteLine("--------------------");

            for (int i = 0; i < count; i++)
            {

                if (NewFoodItem[i].GetCategry().Equals("Lunch"))
                {

                    Console.WriteLine($"{NewFoodItem[i].GetDescrptn()} @ R {NewFoodItem[i].GetPrice()}");
                }
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("Supper");
            Console.WriteLine("--------------------");

            for (int i = 0; i < count; i++)
            {
                if (NewFoodItem[i].GetCategry().Equals("Supper"))
                {

                    Console.WriteLine($"{NewFoodItem[i].GetDescrptn()} @ R {NewFoodItem[i].GetPrice()}");
                }

            }
                Console.WriteLine("Press enter to continue...");

        }

        private void DeleteAt(int p)
        {
            for(int i = p; i <= count; i++)
            {
                NewFoodItem[i] = NewFoodItem[1 + i];
            }
            count--;
        }

        public void UpdateQuantity(String newCode)
        {
            int x = FindFoodCode(newCode);
            bool isDone = true;

            while (!isDone)
            {


                if (x > 0)
                {
                    int setNewQuantt = NewFoodItem[x].GetQuanttInStock() - 1;
                    NewFoodItem[x].SetQuantt(setNewQuantt);

                }
                else
                    if (x.Equals(0))
                {
                    Console.WriteLine($" Deleting..... {NewFoodItem[x].GetDescrptn()} with code {NewFoodItem[x].GetCode()}  ");
                    DeleteAt(x);
                }
                else
                    Console.WriteLine("Menu item cannot be found!");
                   

            } 
        }

        public void SaveOutOfStock()
        {
            StreamWriter sw = new StreamWriter("Reorder.txt");
            for (int i = 0; i < count; i++)
            {
                if (NewFoodItem[i].GetQuanttInStock() < 3)
                {
                    sw.WriteLine(NewFoodItem[i].GetCode() + "," + NewFoodItem[i].GetDescrptn() + "," + NewFoodItem[i].GetCategry() + "," + NewFoodItem[i].GetQuanttInStock() + NewFoodItem[i].GetPrice());
                }

            }
            sw.Close();
        }


    }

    class FoodItem
    {
        private String code;
        private String descrptn;
        private String categry;
        private double price;
        private int qInStock;

        public FoodItem(String code, String descrptn, String categry, int qInStock, double price)
        {
            this.code = code;
            this.descrptn = descrptn;
            this.categry = categry;
            this.price = price;
            this.qInStock = qInStock;
        }

        public FoodItem(String code)
        {
            this.code = code;
        }

            public String GetCode()
        {
            return code;
        }

        public String GetDescrptn()
        {
            return descrptn;

        }

        public String GetCategry()
        {
            return categry;
        }

        public double GetPrice()
        {
            return price;
        }

        public int GetQuanttInStock()
        {
            return qInStock;
        }

        public void SetPrice(double value)
        {
            price = value;
        }

        public void SetQuantt(int value)
        {
            qInStock = value;
        }
    }
}
