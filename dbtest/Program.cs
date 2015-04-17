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
       
       private static NamingCompounds compoundNamer;

       
        static void Main(string[] args)
        {
            compoundNamer = new NamingCompounds();
            Console.WriteLine("Enter in a binary Ionic compound: ");
            string inCompound = Console.ReadLine();
            Console.WriteLine(compoundNamer.BinaryIonicCompound(inCompound));
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
