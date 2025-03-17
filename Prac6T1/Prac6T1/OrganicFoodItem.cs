using System;
using System.IO;
namespace Prac6T1
{
    public class OrganicFoodItem : FoodItem
    {
        public bool isOrganic;

        public OrganicFoodItem(String Code, String Name, String Category, int NrInStock, double CostPrice, bool isOrganic):base(Code,Name,Category,NrInStock,CostPrice)
        {
            this.isOrganic = isOrganic;
        }

        public bool GetOrganic()
        {
            return isOrganic;
        }

        public override double GetSellingPrice()
        {
            double sellingPrice = 1.67 * CostPrice;

            return sellingPrice;
        }
        
        public override void Display()
        {
            OrganicFoodItem[] organicFoodItems = new OrganicFoodItem[ListOfFoods.Length];
            int countO = 0;

            for (int i = 0; i < Count2; i++)
            { 
                if(sr.ReadLine().Contains("Organic"))
                {
                    Console.WriteLine($"Code: {ListOfFoods[i].Code}, Name: {ListOfFoods[i].Name}, Category:{ListOfFoods[i].Category}, Number in Stock: {ListOfFoods[i].NrInStock}, Cost Price: {ListOfFoods[i].CostPrice}");
                    ListOfFoods.CopyTo(organicFoodItems, countO);
                    countO++;
                }
            }
        }
    }
}
