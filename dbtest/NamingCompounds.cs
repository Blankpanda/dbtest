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
        private static PeriodicTable pTable; // used to gather information from elements relating to the PeriodicTable class



   
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
             

                DB = new IntializeDatabase(); //initalize the data base object
                DB.openDataBase(); // open the database in working directory
                QueryCommand = new SQLiteCommand(); // initalize the command to pass into the reader
                elements = new List<string>(); // initalize list for database elements
                pTable = new PeriodicTable(); // initalize PeriodicTable object for determining periods

                string cation = "";
                string anion = "";
                string verboseCompound = "";

               

                // returns seperated cation and anion and places it into a list
               
                List<string> symbolsSplit = new List<string>(splitSymbolByCapital(symbolCompound));
                 cation = symbolsSplit[0];
                 anion = symbolsSplit[1];

               /*exception code determine if the user entered in the wrong type of formula */

                 // checks to see if the element is an oxide
                 if ( symbolsSplit[1].Contains("O") || symbolsSplit[symbolsSplit.Count - 1].Contains("O"))
                 {
                     Console.WriteLine("Element is an oxide or is invalid");
                     return "";
                 }

                // checks the to see if the element is a valid cation
                 string periodNumberSTR = pTable.GetPeriodicGroup(cation);
                 int cPeriodNumberINT = Convert.ToInt32(periodNumberSTR);

                 if (cPeriodNumberINT <= 12) // if the cation is a not a transition metal, akali earth or akaline element
                 {
                     Console.WriteLine("Invalid Cation entered for a binary ionic compound");
                     return "";
                 }
                     
                     
                //queries the database to match symbol to name

                 string binaryIonicCompoundQuery = "SELECT * FROM elements WHERE Symbol Like ";  // query argument
                 string binaryIonicCompoundReaderArgument = "Name";

                    // determine the cation
              
                    QueryCommand = DB.QueryDatabase(binaryIonicCompoundQuery + "'" + cation + "'"); // query the database and pass the query to the reader
                    elements = DB.readDatabase(QueryCommand , binaryIonicCompoundReaderArgument  ); // readDatabase returns read data as a list
                    cation = elements[0];
               
                    //determine the anion
                    QueryCommand = DB.QueryDatabase(binaryIonicCompoundQuery + "'" + anion + "'");
                    elements = DB.readDatabase(QueryCommand , binaryIonicCompoundReaderArgument );
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






        public string PolyAtomicIons(string symbolCompound)
        {
            try
            {
                DB = new IntializeDatabase(); //initalize the data base object
                DB.openDataBase(); // open the database in working directory
                QueryCommand = new SQLiteCommand(); // initalize the command to pass into the reader
                elements = new List<string>(); // initalize list for database elements
                pTable = new PeriodicTable(); // initalize PeriodicTable object for determining periods

                string cation = "";
                string anion = "";
                string verboseCompound = "";
                
                /* split the symbols up based on cation | anion and include numbers with the proper element
                 * there will be three ways to determine the element.
                 * 1. refering to a different database that contains common poly atomics
                 * 2. determining if the user entered an oxyion
                 * 3. determine if the user entered a hydrate { BaCl2 * 2H2O } */

                // determining the cation
                List<string> symbolsSplit = new List<string>(splitSymbolByCapital(symbolCompound)); // splitSymbolByCapitalAndNumber is used to keep numbers in cation and anion groups
                cation = symbolsSplit[0];
                anion = symbolsSplit[1];

                //consider parralel arrays


            }
            catch (Exception)
            {

                Console.WriteLine("Not a polyatomic ion");
            }

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
        
        //private string[] splitSymbolByCapitalAndNumber(string sym)
        //{
        //    return Regex.Split(sym, @"(")
        //}


      
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
