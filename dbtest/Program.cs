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
       
       private static NamingCompounds x;

       
        static void Main(string[] args)
        {
            x = new NamingCompounds();
            string test = "NaRn";
            
            Console.WriteLine(x.BinaryIonicCompound(test));
            Console.ReadLine();
        }

        /*
         * This method takes a list and simply outputs the contents of the list
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
