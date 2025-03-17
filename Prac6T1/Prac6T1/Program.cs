using System;
using System.IO;

namespace Prac6T1
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodItem newOne = new FoodItem();
            FoodItem[] ListOfFoods = new FoodItem[17];
            int Count2 = 0;
            FoodItem[] listOfOrganic = new FoodItem[ListOfFoods.Length];
            int countOrganic = 0;

            {
                StreamReader sr = new StreamReader("Items-2.txt");
                String line = sr.ReadLine();


                while (!sr.EndOfStream)
                {
                    String[] elementsInFood = line.Split(",");
                    FoodItem Temp;


                    if (line.Contains("Organic"))
                    {
                        Temp = new OrganicFoodItem(elementsInFood[0], elementsInFood[1], elementsInFood[2], int.Parse(elementsInFood[3]), double.Parse(elementsInFood[4]), true);
                        listOfOrganic[countOrganic] = (OrganicFoodItem)Temp;
                        countOrganic++;
                    }
                    
                    
                        Temp = new FoodItem(elementsInFood[0], elementsInFood[1], elementsInFood[2], int.Parse(elementsInFood[3]), double.Parse(elementsInFood[4]));
                        ListOfFoods[Count2] = Temp;
                        Count2++;
                    
                    
                }
                sr.Close();
            }
            newOne.Display();
            newOne.DisplayTotalAmount();
            


        }
    }
}
