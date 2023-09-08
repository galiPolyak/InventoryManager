//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Game : Media
    {
        //Define variables to store values specific to game products
        private string rating;
        private int criticScore;


        //Pre: Contains attribute variables shared by all game products
        public Game(string itemType, string name, double cost, string barcode, string genreOpt, string platformOpt, int year, string rating, int criticScore) :
            base(itemType, name, cost, barcode, genreOpt, platformOpt, year)
        {
            //Define variables as instances of game class
            this.rating = rating;
            this.criticScore = criticScore;
        }


        //Pre: None
        //Post: Returns display a string of the game's data
        //Description: Forms a string to display game's data
        public override string DisplayData()
        {
            //Forms string of movie's data in displayable format
            string display = "Type: " + itemType + "\nName: " + name + "\nCost: " + cost + "\nBarcode: " + barcode + "\nGenre: " + genreOpt +
                "\nPlatform: " + platformOpt + "\nRelease Year: " + year + "\nRating: " + rating + "\nScore: " + criticScore + "\n";

            //Return string
            return display;
        }


        //Pre: None
        //Post: Returns display as a string
        //Description: Creates a string of the game's attributes formatted the same as the products in the inventory file  
        public override string DisplayInventory()
        {
            //Forms string of movie's attributes in inventory format 
            string display = itemType + "," + name + "," + cost + "," + barcode + "," + genreOpt +
                "," + platformOpt + "," + year + "," + rating + "," + criticScore;

            //Return string
            return display;
        }
    }
}
