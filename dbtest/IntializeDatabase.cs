using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace dbtest
{

    class IntializeDatabase
    {
        private static SQLiteConnection M_CONNECTION;


        /*
         * This method opens the connection to the data base 
         * this database is currently found in the working directory
         */
        public void openDataBase()
        {
            var openString = "data source=elements.db";
            M_CONNECTION = new SQLiteConnection(openString);
            M_CONNECTION.Open();
        }


        /*
         *This method will run a simple query to the database called elements 
         * to determine the the entered cation and anion name
         */
        public dynamic BinaryQueryDatabase(string inp)
        {

             string sqlQuery = "SELECT * FROM elements WHERE Symbol Like " + "'" +  inp + "'"; 
             SQLiteCommand command = new SQLiteCommand(sqlQuery,M_CONNECTION);
             return command;
        }

        /*
         * this method reads the database and stores the contents of the query
         * in a string, which is passed back to main 
         */
        public dynamic readDatabase(SQLiteCommand c)
        {
            SQLiteDataReader reader = c.ExecuteReader();
    
            List<string> elements = new List<string>(); // used to store the elements being passed from the database
           

            while (reader.Read()) //reads the database based on the query
            { 

                elements.Add("" +reader["Name"]);
               
            }

            return elements;


        }
    }
}
