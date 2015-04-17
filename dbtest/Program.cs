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

            Console.WriteLine("Please enter in a compound: ");
            string inStr = Console.ReadLine();
            
            Console.WriteLine(x.BinaryIonicCompound(inStr));
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
