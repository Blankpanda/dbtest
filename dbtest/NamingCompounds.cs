using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dbtest
{
    public class NamingCompounds
    {
        private static IntializeDatabase DB; // used for database initalization from Intializedatabase Class
        private static SQLiteCommand QueryCommand; // used for passing query to the reader from Intialized Database class
        private static List<string> elements; // used for taking the input from the reader method in IntializedDatabase class

            
        /*
         * 
         * Binary Ionic Compounds
         *   
         */



        /*
         *This method simply returns a string that expresses  
         *Binary Ionic compounds when the user enters in either the full word
         *or the symbol of the element
         */

        public string  BinaryIonicCompound(string symbolCompound)
        {
            try
            {
                string cation = "";
                string anion = "";
                string verboseCompound = "";
               
                

                DB = new IntializeDatabase(); //initalize the data base object
                DB.openDataBase(); // open the database in working directory
                QueryCommand = new SQLiteCommand(); // initalize the command to pass into the reader
                elements = new List<string>(); // initalize list for database elements

                // returns seperated cation and anion and places it into a list
                 List<string> symbolsSplit = new List<string>(splitSymbolByCapital(symbolCompound));

                 cation = symbolsSplit[0];
                 anion = symbolsSplit[1];

               /*exception code determine if the user entered in the wrong type of formula */

                 if ( symbolsSplit[1].Contains("O") || symbolsSplit[symbolsSplit.Count - 1].Contains("O"))
                 {
                     Console.WriteLine("Element is an oxide or is invalid");
                     return "";
                 }

           



                //queries the database to match symbol to name

                    // determining the cation
              
                    QueryCommand = DB.I_BinaryQueryDatabase(cation); // query the database and pass the query to the reader
                    elements = DB.readDatabase(QueryCommand); // readDatabase returns read data as a list
                    cation = elements[0];

                    //determining the anion
                    QueryCommand = DB.I_BinaryQueryDatabase(anion);
                    elements = DB.readDatabase(QueryCommand);
                    anion = elements[0];

                    // adding "ide" to the end of the anion         
                    anion = verbalIonization(anion);


                    verboseCompound = cation + " " + anion; // combine the cation and the anion a single statement

                
                return verboseCompound; 

            }
            catch (Exception)
            {
                
                Console.WriteLine("Not a binary compound");
               
               
                                  
                return "";
            }
            
        }

        /*
       * This method removes the suffix of the element and replaces it with -ide
       */
        private string verbalIonization(string anion)
        {
            if (anion.Contains("ine")) // if the elements ends in -ine
            {
                anion = reverseString(anion);
                anion = anion.Remove(0, 3);
                anion = reverseString(anion);

            }
            else if (anion.Contains("en")) // if element ends in -en
            {
                anion = reverseString(anion);
                anion = anion.Remove(0, 4);
                anion = reverseString(anion);
            }
            else if (anion.Contains("ur")) // if element ends in -ur
            {
                anion = reverseString(anion);
                anion = anion.Remove(0, 2);
                anion = reverseString(anion);
            }



            anion = anion + "ide";
            return anion;
        }



        /*
        * 
        * Polyatomic Ions
        *   
        */

        private string CommonPolyatomicIons(string symbolCompound)
        {




            return "";
        }















       /*
        * 
        * General use methods 
        * 
        */

        /* used to spilt the symbols into seperate elements in an array */
        private string[] splitSymbolByCapital(string sym)
        {
           return Regex.Split(sym, @"(?<!^)(?=[A-Z])");  // regex not sure how this works, got on stack overflow
        }


      
        /*
         * reverses string to make words easier to remove from 
         */
        private static string reverseString(string anion)
        {
            char[] cARR = anion.ToCharArray();
            Array.Reverse(cARR); 

            return new string(cARR);

        }

       







    }
}
