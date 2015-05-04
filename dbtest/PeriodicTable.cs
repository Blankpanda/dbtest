using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbtest
{

    /* this class handles several different things about the periodic table */


    class PeriodicTable
    {
        int[] period18Numbers = { 2, 10, 18, 36, 54, 86, 118 };



        //DOCCUMENT THIS METHOD LATER
        /* its basically a test of some kind anyway */
        public void test()
        {

         


            int[][] elementsByPeriodsARR = new int[17][];
            int counter = 0;
           
                for (int i = 1; i <= 118; i++)
                {
                    elementsByPeriodsARR[counter][i] = i;

                   if (i == Array.BinarySearch(period18Numbers,i))
                   {
                       counter++;
                   }

                }
            


            Console.ReadLine();
        }



        

    }
}
