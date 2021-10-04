using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demonstrates initializing 2D arrays
            int[,] array2DInit = new int[,] {
                     /*0  1  2*/
                /*0*/{ 1, 2, 3 }, 
                /*1*/{ 4, 5, 6, }, 
                /*2*/{ 7, 8, 9 } };

            int[,] array2DInitInit2 = {                
                { 1, 2, 3 },
                { 4, 5, 6, },
                { 7, 8, 9 } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(array2DInit[i, j]);
                }
            }

            AddRows(array2DInit);

            void AddRows(int[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    int num = 0;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        num += array[i, j];
                    }
                    Console.WriteLine(num);
                }
            }
        }
    }
}
