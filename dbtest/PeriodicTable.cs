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
        int[] periodIndexs = { 7,   //1
                               6,   //2
                               4,   //3
                               6,   //4
                               6,   //5
                               6,   //6
                               6,   //7
                               6,   //8
                               6,   //9
                               6,   //10
                               6,   //11
                               6,   //12
                               8,   //13
                               8,   //14
                               8,   //15
                               8,   //16
                               8,   //17
                               7, }; //18
                                  





        //DOCCUMENT THIS METHOD LATER
        /* its basically a test of some kind anyway */
        public void test()
        {

            const int TOTAL_ELEMENT_COUNT = 118; // JUST INCASE WE NEED THIS

            int[][] elementsByPeriodsARR = new int[18][]; // jagged array to hold numbers in a paticular period in an array


            for (int i = 0; i <= elementsByPeriodsARR.Length - 1; i++)  // initalize the values of the array and fill them the with proper
            {                                                           //amount of space
			
                elementsByPeriodsARR[i] = new int[periodIndexs[i]];
               
                
			}

            // sample outputish
            for (int i = 0; i < elementsByPeriodsARR.Length; i++)
            {
                Console.Write("Period # {0} contains: ", i);



                int[] innerArr = elementsByPeriodsARR[i];
                for (int j = 0; j < innerArr.Length; j++)
                {
                    Console.Write(innerArr[j] + " ");
                }

                Console.WriteLine();

            }



            
            


            Console.ReadLine();
        }



        

    }
}
