using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// /a/ > /g/

namespace dbtest
{
    class Program 
    {
       private static IntializeDatabase DB;
       private static SQLiteCommand QueryCommand;
       private static List<string> elements;

       
        static void Main(string[] args)
        {

            Console.WriteLine("Type in a elements symbol: ");
            string inp = Console.ReadLine();
            inp = "'" + inp + "'";


            DB = new IntializeDatabase(); //initalize the data base object
            DB.openDataBase(); // open the database in working directory
            QueryCommand = new SQLiteCommand(); // initalize the command to pass into the reader
            QueryCommand = DB.queryDatabase(inp); // query the database and pass the query to the reader
            elements = new List<string>(); // initalize list for database elements
            elements = DB.readDatabase(QueryCommand); // readDatabase returns read data as a list




            outputData(elements);
           
           
           
             Console.ReadLine();
        }

        /*
         * This method takes a list and simply outputs them
         */
        private static void outputData(List<string> elements)
        {
            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }
        }

       
       

    }
}
