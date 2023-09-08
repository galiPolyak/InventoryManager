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
    class MainClass
    {
        //Helps read and write to file using File.IO
        private static StreamReader inFile = null;
        private static StreamWriter outFile = null;

        //Stores manager functionalities
        const string ADD = "Add";
        const string DISPLAY2 = "Display2";
        const string FIND_BARCODE = "FindBarcode";
        const string FIND_NAME = "FindName";
        const string SORT_BY_COST = "SortByCost";
        const string SORT_BY_NAME = "SortByName";

        //Assign action file name and display file name
        private static string readActionsFile = "actions.txt";
        private static string displayFile = "PolyakG_PASS2.txt";

        //Stores action results to write to display actions file
        private static List<string> actionResults = new List<string>();

        public static void Main(string[] args)
        {
            //Initialize store class
            Store store = new Store();

            //Calls method to read inventory from inventory file
            store.ReadInventory();

            //Calls method to read actions from actions file and do them accordingly
            ReadAndDoActions(store);

            //Calls method to displays action results onto console and writes them to action results file
            DisplayActionResults();

            //Read line
            Console.ReadLine();
        }


        //Pre: Instance of store class is passed down
        //Post: None
        //Description: Reads actions from actions file and carries out actions
        private static void ReadAndDoActions(Store store)
        {
            //Defines variable to read actions file by line
            string readActions;

            //Defines array to store split line
            string[] actionFields;

            //Try-Catch error handling
            try
            {
                //Open actions file
                inFile = File.OpenText(readActionsFile);

                //While file is not at the end of its stream loop continuously
                while (!inFile.EndOfStream)
                {
                    //Assign the variable with line from actions text
                    readActions = inFile.ReadLine();

                    //Split read in action line at colon and store in array
                    actionFields = readActions.Split(':');

                    //Perform appropriate action based on read-in actions
                    switch (actionFields[0])
                    {
                        case ADD:

                            //Calls method to add product to inventory
                            store.AddProduct(actionFields[1]);

                            //Calls method to save inventory back into inventory file 
                            store.SaveInvetory();

                            break;

                        case DISPLAY2:

                            //Calls method to get a formatted string of the combined Data Displays of the first 2 items in the inventory collection that match a chosen type
                            actionResults.Add(store.DisplayFirstTwo(actionFields[1]));

                            break;

                        case FIND_BARCODE:

                            //Returns the product matching the given Barcode. If none are found, null is returned
                            Product prodByBarcode = store.FindByBarcode(actionFields[1]);

                            //Calls method to perform appropriate action on product matching the given barcode. If no product exists return 'not found' message
                            actionResults.Add(store.ActionsByBarcode(actionFields, prodByBarcode));

                            //Calls method to save inventory back into inventory file 
                            store.SaveInvetory();

                            break;

                        case FIND_NAME:

                            //Returns a List of Products that match the given Name. If none are found, the empty list is returned
                            List<Product> prodsByName = store.FindByName(actionFields[1]);

                            //Calls method to perform appropriate action on product matching the given name and index. If no product exists return 'not found' message
                            actionResults.Add(store.ActionsByName(actionFields, prodsByName));

                            //Calls method to save inventory back into inventory file 
                            store.SaveInvetory();

                            break;

                        case SORT_BY_COST:

                            //Calls method to sorts products in following order: Group, Type, and by Cost. Cost will be in descending order.  
                            store.SortByCost();

                            //Calls method to save inventory back into inventory file 
                            store.SaveInvetory();

                            break;

                        case SORT_BY_NAME:

                            //Calls method to sort products in the following order: Group, Type, and by Name.
                            store.SortByName();

                            //Calls method to save inventory back into inventory file 
                            store.SaveInvetory();

                            break;

                        default:

                            //If unknown action is given, output action command not found message
                            string invalidAction = "Action Command: " + actionFields[0] + " not recognized\n\n";
                            actionResults.Add(invalidAction);
                            Console.Write(invalidAction);

                            break;
                    }
                }

                //Close actions file
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


        //Pre: actionResults is a list of strings
        //Post: None
        //Description: Displays action results onto console and writes them to action results file
        private static void DisplayActionResults()
        {

            //Try-Catch error handling
            try
            {
                //Create action results display file
                outFile = File.CreateText(displayFile);

                //Loop through action results list
                for (int i = 0; i < actionResults.Count; i++)
                {
                    //Write action results onto file 
                    outFile.Write(actionResults[i]);

                    //Output action results to console
                    Console.Write(actionResults[i]);
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
        
    }
}
           
