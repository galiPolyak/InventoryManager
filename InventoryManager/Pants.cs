//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Pants : Clothing
    {
        //Define variable to store value specific to pants products
        private int waistSize;


        //Pre: Contains attribute variables shared by all pants products
        public Pants(string itemType, string name, double cost, string barcode, string materialOpt, int waistSize) : base(itemType, name, cost, barcode, materialOpt)
        {
            //Defines variable as instance of pants class
            this.waistSize = waistSize;
        }


        //Pre: None
        //Post: Returns display as a string of the pants's data
        //Description: Forms a string to display movie's data
        public override string DisplayData()
        {
            //Forms string of movie's data in displayable format
            string display = "Type: " + itemType + "\nName: " + name + "\nCost: " + cost + "\nBarcode: " + barcode + "\nMaterial: " + materialOpt +
                "\nWaist Size: " + waistSize + "\n";

            //Return string
            return display;
        }


        //Pre: None
        //Post: Returns display as a string
        //Description: Creates a string of the pants' attributes formatted the same as the products in the inventory file 
        public override string DisplayInventory()
        {
            //Forms string of movie's attributes in inventory format 
            string display = itemType + "," + name + "," + cost + "," + barcode + "," + materialOpt +
                "," + waistSize;

            //Return string
            return display;
        }

    }
}
