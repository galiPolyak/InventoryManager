//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Top : Clothing
    {
        //Define variables to store values specific to top products
        private string style;
        private string size;


        //Pre: Contains attribute variables shared by all top products
        public Top(string itemType, string name, double cost, string barcode, string materialOpt, string style, string size) : base(itemType, name, cost, barcode, materialOpt)
        {
            //Define variables as instances of top class
            this.style = style;
            this.size = size;
        }


        //Pre: None
        //Post: Returns display as a string of the top's data
        //Description: Forms a string to display top's data
        public override string DisplayData()
        {
            //Forms string of movie's data in displayable format
            string display = "Type: " + itemType + "\nName: " + name + "\nCost: " + cost + "\nBarcode: " + barcode + "\nMaterial: " + materialOpt +
                "\nTop Style: " + style + "\nSize: " + size + "\n";

            //Return string
            return display;
        }


        //Pre: None
        //Post: Returns display as a string
        //Description: Creates a string of the top's attributes formatted the same as the products in the inventory file  
        public override string DisplayInventory()
        {
            //Forms string of movie's attributes in inventory format 
            string display = itemType + "," + name + "," + cost + "," + barcode + "," + materialOpt +
                "," + style + "," + size;

            //Return string
            return display;
        }
    }
}
