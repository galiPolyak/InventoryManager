//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Product
    {
        //Define variables to store values shared by all products
        protected string itemType;
        protected string name;
        protected double cost;
        protected string barcode;


        //Pre: Contains attribute variables shared by all products
        public Product(string itemType, string name, double cost, string barcode)
        {
            //Defines variable as instance of product class
            this.itemType = itemType;
            this.name = name;
            this.cost = cost;
            this.barcode = barcode;
        }


        //Pre: None
        //Post: Returns item type as a string
        //Description: Access item type of product
        public string GetItemType()
        {
            //returns item type
            return itemType;
        }


        //Pre: None
        //Post: Returns name as a string
        //Description: Access name of product
        public string GetName()
        {
            //returns name
            return name;
        }


        //Pre: None
        //Post: Returns cost as a double
        //Description: Access cost of product
        public double GetCost()
        {
            //returns cost
            return cost;
        }


        //Pre: cost is a double
        //Post: None
        //Description: Modify cost of product
        public void SetCost(double cost)
        {
            //sets cost
            this.cost = cost;
        }


        //Pre: None
        //Post: Returns barcode as a string
        //Description: Access barcode of product
        public string GetBarcode()
        {
            //returns barcode
            return barcode;
        }


        //Pre: None
        //Post: Returns data display as a string
        //Description: Access display data of product
        public virtual string DisplayData()
        {
            //assign empty display string
            string display = "";

            //return display string
            return display;
        }


        //Pre: None
        //Post: Returns formatted inventory display as a string
        //Description: Access formatted inventory display of product
        public virtual string DisplayInventory()
        {
            //assign empty display string
            string display = "";

            //return display string
            return display;
        }


        //Pre: None
        //Post: Returns group as a string
        //Description: Access group of product
        public virtual string GetGroup()
        {
            //assign empty group
            string group = "";

            //return group
            return group;
        }

    }

}
