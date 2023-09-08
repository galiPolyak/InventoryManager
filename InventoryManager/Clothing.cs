//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Clothing : Product
    {
        //Define variables to store values specific to clothing products
        protected string materialOpt;


        //Pre: Contains attribute variables shared by all clothing products
        public Clothing(string itemType, string name, double cost, string barcode, string materialOpt) : base(itemType, name, cost, barcode)
        {
            //Defines variable as instance of clothing class
            this.materialOpt = materialOpt;
        }


        //Pre: None
        //Post: Returns group type as a string
        //Description: Access group type of product
        public override string GetGroup()
        {
            //Assign group as clothing
            string group = "Clothing";

            //Return group
            return group;
        }
    }
}
