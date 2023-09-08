//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
namespace InventoryManager
{
    public class Media : Product
    {
        //Define variables to store values specific to media products
        protected string genreOpt;
        protected string platformOpt;
        protected int year;


        //Pre: Contains attribute variables shared by all media products
        public Media(string itemType, string name, double cost, string barcode, string genreOpt, string platformOpt, int year) : base(itemType, name, cost, barcode)
        {
            //Defines variable as instance of media class
            this.genreOpt = genreOpt;
            this.platformOpt = platformOpt;
            this.year = year;
        }


        //Pre: None
        //Post: Returns group type as a string
        //Description: Access group type of product
        public override string GetGroup()
        {
            //Assign group as media
            string group = "Media";

            //Return group
            return group;
        }
    }
}
