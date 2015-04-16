using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
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

                DB = new IntializeDatabase(); //initalize the data base object
                DB.openDataBase(); // open the database in working directory
                QueryCommand = new SQLiteCommand(); // initalize the command to pass into the reader
                elements = new List<string>(); // initalize list for database elements


                // determine how many characters make up the cation and the anion
                if (symbolCompound.Length == 2) // example CO
                {
                    cation = symbolCompound.Substring(0, 1);
                    anion = symbolCompound.Substring(1, 1);
                }
                else if (symbolCompound.Length == 3) // FeS
                {
                    cation = symbolCompound.Substring(0, 2);
                    anion = symbolCompound.Substring(2, 1);
                }
                else if (symbolCompound.Length == 4) //NaCl
                {
                    cation = symbolCompound.Substring(0, 2);
                    anion = symbolCompound.Substring(2, 2);
                }


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

        private static string reverseString(string anion)
        {
            char[] cARR = anion.ToCharArray();
            Array.Reverse(cARR);

            

            return new string(cARR);

        }








    }
}
