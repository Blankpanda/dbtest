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
        private static IntializeDatabase DB;
        private static SQLiteCommand QueryCommand;
        private static List<string> elements;


        

            
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
                string[] split = new string[1];
                

                DB = new IntializeDatabase(); //initalize the data base object
                DB.openDataBase(); // open the database in working directory
                QueryCommand = new SQLiteCommand(); // initalize the command to pass into the reader
                elements = new List<string>(); // initalize list for database elements

                // returns seperated cation and anion
                split = splitSymbol(symbolCompound); // consider renaming some stuff here               
                cation = split[0];
                anion = split[1];





                //queries the database to match symbol to name


                // determining the cation
              
                    QueryCommand = DB.BinaryQueryDatabase(cation); // query the database and pass the query to the reader
                    elements = DB.readDatabase(QueryCommand); // readDatabase returns read data as a list
                    cation = elements[0];

                    //determining the anion
                    QueryCommand = DB.BinaryQueryDatabase(anion);
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
         * determine how many characters make up the cation and the anion
            using captials to seperate the symbols into cation and anion 
         * 
         */
        private string[] splitSymbol(string sym)
        {
           return Regex.Split(sym, @"(?<!^)(?=[A-Z])");
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
                anion = anion.Remove(0,4);
                anion = reverseString(anion);
            }
            else if (anion.Contains("ur")) // if element ends in -ur
            {
                anion = reverseString(anion);
                anion = anion.Remove(0,2);
                anion = reverseString(anion);
            }

            
      
            anion = anion + "ide";
            return anion;
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
