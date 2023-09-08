//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Dress : Clothing
    {
        //Define variables to store values specific to dress product
        private string dressType;
        private string size;


        //Pre: Contains attribute variables shared by all dress products
        public Dress(string itemType, string name, double cost, string barcode, string materialOpt, string dressType, string size) : base(itemType, name, cost, barcode, materialOpt)
        {
            //Define variables as instances of dress class
            this.dressType = dressType;
            this.size = size;
        }


        //Pre: None
        //Post: Returns display as string of the dress's data
        //Description: Forms a string to display dress's data
        public override string DisplayData()
        {
            //Forms string of movie's data in displayable format
            string display = "Type: " + itemType + "\nName: " + name + "\nCost: " + cost + "\nBarcode: " + barcode + "\nMaterial: " + materialOpt +
                "\nDress Type: " + dressType + "\nSize: " + size + "\n";

            //Return string
            return display;
        }


        //Pre: None
        //Post: Returns display as a string
        //Description: Creates a string of the dress's attributes formatted the same as the products in the inventory file 
        public override string DisplayInventory()
        {
            //Forms string of movie's attributes in inventory format 
            string display = itemType + "," + name + "," + cost + "," + barcode + "," + materialOpt +
                "," + dressType + "," + size;

            //Return string
            return display;
        }
    }
}
