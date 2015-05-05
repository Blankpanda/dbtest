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
        public const int TOTAL_ELEMENT_COUNT = 118; // JUST INCASE WE NEED THIS



        public int[][] elementSeperatedByPeriod = new int[][]
        {
            
            new int[] { 1 , 3 , 11 , 19 , 37 , 55 , 87 },           // 1
            new int[] { 4 , 12 , 20 , 38 , 56 , 88 },               // 2
            new int[] { 21 , 39 , 57 , 89 },                        // 3 
            new int[] { 22 , 40 , 58 , 72, 90 , 104 },              // 4
            new int[] { 23 , 41 , 73 , 105 , 59 , 91 },             // 5
            new int[] { 24 , 42 , 74 , 106 , 60 , 92 },             // 6
            new int[] { 25 , 43 , 75 , 107 , 61 , 93 },             // 7
            new int[] { 26 , 44 , 76 , 108 , 62 , 94},              // 8
            new int[] { 27 , 45 , 77 , 109 , 63 , 95},              // 9
            new int[] { 28 , 46 , 78 , 110 , 64 , 96},              // 10
            new int[] { 29 , 47 , 79 , 111 , 65 , 97 },             // 11
            new int[] { 30 , 48 , 80 , 112 , 66 , 98 },             // 12
            new int[] { 5 , 13 , 31 , 49 , 81 , 113 , 67 , 99 },    // 13
            new int[] { 6 , 14 , 32 , 50 , 82 , 114 , 68 , 100 },   // 14
            new int[] { 7 , 15 , 33 , 51 , 83 , 155 , 69 , 101 },   // 15
            new int[] { 8 , 16 , 34 , 52 , 84 , 116 , 70 , 102 },   // 16
            new int[] { 9 , 17 , 35 , 53 , 85 , 117 , 71 , 103 },   // 17
            new int[] { 2 , 10 , 18 , 36 , 54 , 86 , 118 }          // 18
       
        };


        



        //DOCCUMENT THIS METHOD LATER
        /* its basically a test of some kind anyway */
        public void test()
        {
            for (int i = 0; i < elementSeperatedByPeriod.Length; i++)
            {
                Console.Write("Period # {0} contains: ", i);

               int[] innerArr = elementSeperatedByPeriod[i];
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
