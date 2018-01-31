using System;
using System.Linq;

namespace Lab01.SumMatrixElements
{
    class Program
    {
        static void Main()
        {   //100/100
            var sizes = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rolsCount = sizes[0];
            var colsCount = sizes[1];

            int[][] matrix = new int[rolsCount][];
            var sum = 0;

            // 1. Reading  values:
            for (int r = 0; r < rolsCount; r++)
            {               
                matrix[r] = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
               
            }

            // 2.Calc sum:
            for (int r = 0; r < rolsCount; r++)
            {
                for (int c = 0; c < colsCount; c++)
                {
                    sum += matrix[r][c];
                }
            }
            Console.WriteLine(rolsCount);
            Console.WriteLine(colsCount);
            Console.WriteLine(sum);
        }
    }
}
