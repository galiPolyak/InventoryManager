//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Movie : Media
    {
        //Define variables to store values specific to movie products
        private string director;
        private string rating;
        private string duration;


        //Pre: Contains attribute variables shared by all movie products
        public Movie(string itemType, string name, double cost, string barcode, string genreOpt, string platformOpt, int year, string director, string rating, string duration) :
            base(itemType, name, cost, barcode, genreOpt, platformOpt, year)
        {
            //Define variables as instances of movie class
            this.director = director;
            this.rating = rating;
            this.duration = duration;
        }


        //Pre: None
        //Post: Returns a string of the movie's data
        //Description: Forms a string to display movie's data
        public override string DisplayData()
        {
            //Forms string of movie's data in displayable format
            string display = "Type: " + itemType + "\nName: " + name + "\nCost: " + cost + "\nBarcode: " + barcode + "\nGenre: " + genreOpt +
                "\nPlatform: " + platformOpt + "\nRelease Year: "+ year + "\nDirector: " + director + "\nMPAA Rating: " + rating + "\nDuration: " + duration + "\n";

            //Return string
            return display;
        }


        //Pre: None
        //Post: Returns display as a string
        //Description: Creates a string of the movie's attributes formatted the same as the products in the inventory file 
        public override string DisplayInventory()
        {
            //Forms string of movie's attributes in inventory format 
            string display = itemType + "," + name + "," + cost + "," + barcode + "," + genreOpt +
                "," + platformOpt + "," + year + "," + director + "," + rating + "," + duration;

            //Return string
            return display;
        }
    }
}
