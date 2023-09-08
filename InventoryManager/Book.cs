//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Book : Media
    {
        //Define variables to store values specific to book products
        private string author;
        private string publisher;


        //Pre: Contains attribute variables shared by all book products
        public Book(string itemType, string name, double cost, string barcode, string genreOpt, string platformOpt, int year, string author, string publisher) :
            base(itemType, name, cost, barcode, genreOpt, platformOpt, year)
        {
            //Define variables as instances of book class
            this.author = author;
            this.publisher = publisher;
        }


        //Pre: None
        //Post: Returns display as a string of the book's data
        //Description: Forms a string to display movie's data
        public override string DisplayData()
        {
            //Forms string of movie's data in displayable format
            string display = "Type: " + itemType + "\nName: " + name + "\nCost: " + cost + "\nBarcode: " + barcode + "\nGenre: " + genreOpt +
                "\nPlatform: " + platformOpt + "\nRelease Year: " + year + "\nAuthor: " + author + "\nPublisher: " + publisher + "\n";

            //Return string
            return display;
        }


        //Pre: None
        //Post: Returns display as a string
        //Description: Creates a string of the book's attributes formatted the same as the products in the inventory file 
        public override string DisplayInventory()
        {
            //Forms string of movie's attributes in inventory format 
            string display = itemType + "," + name + "," + cost + "," + barcode + "," + genreOpt +
                "," + platformOpt + "," + year + "," + author + "," + publisher;

            //Return string
            return display;
        }
    }
}
