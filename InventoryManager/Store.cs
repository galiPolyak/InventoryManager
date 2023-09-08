//Author: Gali Polyak
//File Name: InventoryManager
//Project Name: PASS2
//Creation Date: March 24, 2021
//Modified Date: April 1, 2021
//Description: Inventory Manager!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InventoryManager
{

    public class Store
    {
        //Helps read and write to file using File.IO
        private static StreamReader inFile = null;
        private static StreamWriter outFile = null;

        //Define list to store products written to inventory file
        private static List<Product> products = new List<Product>();

        //Assign inventory file names
        private static string readInventoryFile = "inventory.txt";

        //Assign product type names
        const string MOVIE = "Movie";
        const string GAME = "Game";
        const string BOOK = "Book";
        const string TOP = "Top";
        const string DRESS = "Dress";
        const string PANTS = "Pants";

        //Assign action functionalities
        const string MODIFY = "Modify";
        const string DISPLAY = "Display";
        const string DELETE = "Delete";


        public Store()
        {
        }


        //Pre: None
        //Post: None
        //Description: Reads inventory from inventory file
        public void ReadInventory()
        {

            //Defines variable to read inventory file by line
            string readInventory;

            //Try-Catch error handling
            try
            {
                //Open invetory file
                inFile = File.OpenText(readInventoryFile);

                //Loop continuously while file is not at the end of its stream
                while (!inFile.EndOfStream)
                {
                    //Assign variable with line from inventory file
                    readInventory = inFile.ReadLine();

                    //Add the line to the product list
                    AddProduct(readInventory);
                }

                //Closes inventory file
                inFile.Close();
            }

            catch (FormatException fe)
            {
                //Format exception has been caught, display an error message
                Console.WriteLine(fe.Message);
            }
            catch (FileNotFoundException fnf)
            {
                //File not found exception has been caught, display an error message
                Console.WriteLine(fnf.Message);
            }
            catch (Exception e)
            {
                //Exception has been caught, display an error message
                Console.WriteLine(e.Message);
            }
        }


        //Pre: product is a string conatining the proper amount of attributes for it's type
        //Post: None
        //Description: Converts product string to a product type and adds it to product list
        public void AddProduct(string product)
        {

            //Defines array that stores attributes of each product
            string[] fields;

            //Splits product into attributes assigns to array
            fields = product.Split(',');

            //Find which item type is being passed down and add them to list of products
            switch (fields[0])
            {
                case MOVIE:

                    //Check whether method ValidateData returns true for indexes containing numbers
                    if (ValidateData(fields[2]) && ValidateData(fields[6]))
                    {
                        //Adds the movie product to the list of products
                        products.Add(new Movie(fields[0], fields[1], Convert.ToDouble(fields[2]), fields[3], fields[4],
                            fields[5], Convert.ToInt32(fields[6]), fields[7], fields[8], fields[9]));
                    }

                    break;

                case GAME:

                    //Check whether method ValidateData returns true for indexes containing numbers
                    if (ValidateData(fields[2]) && ValidateData(fields[6]) && ValidateData(fields[8]))
                    {
                        //Adds the game product to the list of products
                        products.Add(new Game(fields[0], fields[1], Convert.ToDouble(fields[2]), fields[3], fields[4],
                        fields[5], Convert.ToInt32(fields[6]), fields[7], Convert.ToInt32(fields[8])));
                    }

                    break;

                case BOOK:

                    //Check whether method ValidateData returns true for indexes containing numbers
                    if (ValidateData(fields[2]) && ValidateData(fields[6]))
                    {
                        //Adds the book product to the list of products
                        products.Add(new Book(fields[0], fields[1], Convert.ToDouble(fields[2]), fields[3], fields[4],
                        fields[5], Convert.ToInt32(fields[6]), fields[7], fields[8]));
                    }

                    break;

                case PANTS:

                    //Check whether method ValidateData returns true for indexes containing numbers
                    if (ValidateData(fields[2]) && ValidateData(fields[5]))
                    {
                        //Adds the pants product to the list of products
                        products.Add(new Pants(fields[0], fields[1], Convert.ToDouble(fields[2]), fields[3], fields[4],
                        Convert.ToInt32(fields[5])));
                    }

                    break;

                case DRESS:

                    //Check whether method ValidateData returns true for indexes containing numbers
                    if (ValidateData(fields[2]))
                    {
                        //Adds the dress product to the list of products
                        products.Add(new Dress(fields[0], fields[1], Convert.ToDouble(fields[2]), fields[3], fields[4],
                        fields[5], fields[6]));
                    }

                    break;

                case TOP:

                    //Check whether method ValidateData returns true for indexes containing numbers
                    if (ValidateData(fields[2]))
                    {
                        //Adds the top product to the list of products
                        products.Add(new Top(fields[0], fields[1], Convert.ToDouble(fields[2]), fields[3], fields[4],
                        fields[5], fields[6]));
                    }

                    break;

                default:

                    //If unknown product is given, output product not found message
                    string invalidField = "Inventory Command: " + fields[0] + " not recognized\n\n";
                    Console.Write(invalidField);

                    break;
            }
        }


        //Pre: type is a string that matches with the product item types
        //Post: Returns either a display string of matching type(s), or a string containing 'not found' message if no types found
        //Description: Displays the first two products from products list that match with the action type. Displays one product if two matching ones don't exist
        //Displays 'not found' message if no products matching the type exist.
        public string DisplayFirstTwo(string type)
        {
            //Initilaizes return string
            string returnString = "";

            //Initializes count. Counts number of displays
            int count = 0;

            //Loop through products list 
            for (int i = 0; i < products.Count; i++)
            {
                //Check whether the type needed to be displayed matches to a type in the product list 
                if (type.Equals(products[i].GetItemType()))
                {
                    //Add matching product to the return string  
                    returnString += products[i].DisplayData() + "\n";

                    //Add one to the count
                    count++;
                }

                //Check whether the display count is two
                if (count == 2)
                {
                    //break the loop
                    break;
                }
            }

            //Check whether the display count is zero after loop is complete
            if (count == 0)
            {
                //Set return string to no products found
                returnString = "No products of type " + type + " found.\n\n";
            }

            //Return return string
            return returnString;
        }


        //Pre: Barcode is a string which is unique to every product 
        //Post: Returns a Product matching the barcode, if none are found return null
        //Description: Finds a product by barcode
        public Product FindByBarcode(string barcode)
        {
            //Loop through products list
            for (int i = 0; i < products.Count; i++)
            {
                //Check whether barcode matches with one of the products
                if (barcode.Equals(products[i].GetBarcode()))
                {
                    //Return the product with matching barcode
                    return products[i];
                }
            }

            //If no product contains the barcode, return null
            return null;
        }


        //Pre: barcodeAction is a string array that does not have a length of under 3 and over 4. It consists of the FindBarcode action, barcode, the secondary action, (cost)
        //Post: Returns a display string of the product matching the barcode. If no matching products are found return 'not found' string message 
        //Description: Performs appropriate actions on product matching the barcode
        public string ActionsByBarcode(string[] barcodeAction, Product prod)
        {
            //Initialize return string
            string returnString = "";

            //Error handling - if barcode action array has a length less than three
            if (barcodeAction.Length < 3)
            {
                //Return empty string
                return returnString;
            }

            //Check whether product is null 
            if (prod == null)
            {
                //If product is null, return item not found message
                returnString = "Item: " + barcodeAction[1] + " not found.\n\n";
                return returnString;
            }

            //Find which action functionality is required
            switch (barcodeAction[2])
            {
                case MODIFY:

                    //Error handling- if barcode action array does not have a length of four
                    if (barcodeAction.Length != 4)
                    {
                        //Return empty string
                        return returnString;
                    }

                    //Assigns the product's modified cost and converts to double
                    double cost = Convert.ToDouble(barcodeAction[3]);

                    //Sets the product's cost to its modified one
                    prod.SetCost(cost);

                    break;

                case DISPLAY:

                    //Set return string to the appropriate display of the product matching the given barcode
                    returnString = prod.DisplayData() + "\n";

                    break;

                case DELETE:

                    //Deletes the product matching the given barcode from the products list
                    products.Remove(prod);

                    break;
            }

            //Return returnString
            return returnString;
        }


        //Pre: name is a string that products possess
        //Post: Returns a Product list of the products matching the name, if none are found return null
        //Description: Finds products by name
        public List <Product> FindByName(string name)
        {

            //Defines names list
            List<Product> names = new List<Product>();

            //Loops through products list
            for (int i = 0; i < products.Count; i++)
            {

                //Check whether name matches with any of the products
                if (name.Equals(products[i].GetName()))
                {
                    //Add name to list
                    names.Add(products[i]);
                }
            }

            //return names list
            return names;
        }


        //Pre: nameAction is a string array that does not have a length of under 4 and over 5. It consists of the FindName action, name, the secondary action, index, (cost)
        //Post: Returns a display string of the product matching the name and index from the names list. If no matching products are found return 'not found' string message 
        //Description: Performs appropriate actions on product matching the name
        public string ActionsByName(string[] nameAction, List <Product> names)
        {
            //Initialize return string
            string returnString = "";

            //Assign index and convert it to an int
            int index = Convert.ToInt32(nameAction[3]);

            //Check whether the product on the given index in the list of names is empty
            if (index >= names.Count)
            {
                //Return 'not found' message
                returnString = "Item: " + nameAction[1] + " not found.\n\n";
                return returnString;
            }

            //Find which action functionality is required
            switch (nameAction[2])
            {
                case MODIFY:

                    //Error Handling - if name action array does not have a length of five
                    if (nameAction.Length != 5)
                    {
                        //Return empty string
                        return returnString;
                    }

                    //Assigns the product's modified cost and converts to double
                    double cost = Convert.ToDouble(nameAction[4]);

                    //Sets the product's cost to its modified one
                    names[index].SetCost(cost);

                    break;

                case DISPLAY:

                    //Set return string to the appropriate display of the product matching the given name
                    returnString = names[index].DisplayData() + "\n";

                    break;

                case DELETE:

                    //Deletes the product matching the given name from the products list
                    products.Remove(names[index]);

                    break;
            }

            //Retern return string
            return returnString;
        }


        //Pre: None
        //Post: None
        //Description: Sorts products in the following order: Group, Type, and by Name.
        public void SortByName()
        {
            //Sorts products in the following order: Group, Type, and by Name.
            products = products.OrderBy(x => x.GetGroup())
                               .ThenBy(x => x.GetItemType())
                               .ThenBy(x => x.GetName())
                               .ToList();
        }


        //Pre: None
        //Post: None
        //Description: Sorts products in following order: Group, Type, and by Cost. Cost will be in descending order. 
        public void SortByCost()
        {
            //Sorts products in following order: Group, Type, and by Cost. Cost will be in descending order. 
            products = products.OrderBy(x => x.GetGroup())
                                .ThenBy(x => x.GetItemType())
                                .ThenByDescending(x => x.GetCost())
                                .ToList();
        }


        //Pre: None
        //Post: None
        //Description: Saves the Inventory back to the inventory.txt file in the exact format it was read in as 
        public void SaveInvetory()
        {
            //Try-Catch error handling
            try
            {
                //Create inventory file
                outFile = File.CreateText(readInventoryFile);

                //Loop through products list
                for (int i = 0; i < products.Count; i++)
                {
                    //Write products to inventory file in proper format
                    outFile.WriteLine(products[i].DisplayInventory());
                }

                //Close file
                outFile.Close();

            }
            catch (FileNotFoundException fnf)
            {
                //File not found exception has been caught, display an error message
                Console.WriteLine(fnf.Message);

            }
            catch (Exception e)
            {
                //Exception has been caught, display an error message
                Console.WriteLine(e.Message);

            }
        }


        //Pre: numCheck is a string
        //Post: Returns bool
        //Description: Validates number data by check if it can be converted to double
        private bool ValidateData(string numCheck)
        {
            //Assign false value to results
            bool results = false;

            //Define double
            double num;

            //Check if number passed down can be converted to double
            if (double.TryParse(numCheck, out num))
            {
                //Assign true value to results 
                results = true;
            }

            //Return results
            return results;
        }
    }   
}
