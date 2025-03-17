using System;
using System.IO;
using System.Collections;

namespace Prac6T1
{
    
    public class FoodItem
    {
        static int size = 17;
        public static int Count2 = 0;
        public FoodItem[] ListOfFoods = new FoodItem[size];
        public StreamReader sr;

        public String Code;
        public String Name;
        public String Category;
        public int NrInStock;
        public double CostPrice;
        


        public FoodItem(String Code, String Name, String Category, int NrInStock, double CostPrice)
        {
            this.Code = Code;
            this.Name = Name;
            this.Category = Category;
            this.NrInStock = NrInStock;
            this.CostPrice = CostPrice;
            
        }
        
        public FoodItem()
        {
        }

        public virtual double GetSellingPrice()
        {
            double sellingPrice = 1.38 * CostPrice;

            return sellingPrice;
        }
        public int GetNumberInStock()
        {
            return NrInStock;
        }
        public virtual void Display()
        {
            for (int i = 0; i < ListOfFoods.Length; i++)
            {
                Console.WriteLine($"Code: {ListOfFoods[i].Code}, Name: {ListOfFoods[i].Name}, Category:{ListOfFoods[i].Category}, Number in Stock: {ListOfFoods[i].NrInStock}, Cost Price: {ListOfFoods[i].CostPrice}");
            }
        }
        
        private double totalAmountOfMoney(FoodItem [] inputArray)
        {
            double sum = 0;
            FoodItem newOne = new FoodItem();
            for(int i = 0; i < Count2;i++)
            {
                sum += inputArray[i].GetSellingPrice();
            }
            return sum;
        }
        public void DisplayTotalAmount()
        {
            Console.WriteLine(totalAmountOfMoney(ListOfFoods));
        }
        
    }
}
