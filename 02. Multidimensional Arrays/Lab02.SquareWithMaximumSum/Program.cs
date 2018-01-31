using System;
using System.Linq;

namespace Lab02.SquareWithMaximumSum
{
    class Program
    {
        static void Main()
        {   // 100/100
            var sizes = Console.ReadLine()
               .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var rolsCount = sizes[0];
            var colsCount = sizes[1];

            int[][] matrix = new int[rolsCount][];

            var maxSum = int.MinValue;
            int maxRowIndex = -1;
            int maxColIndex = -1;

            // 1. Reading  values:
            for (int r = 0; r < rolsCount; r++)
            {
                matrix[r] = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            // 2. FindingMax sum
            for (int r = 0; r < rolsCount-1; r++)
            {
                for (int c = 0; c < colsCount-1; c++)
                {
                    var sum = matrix[r][c] + matrix[r][c + 1] + matrix[r + 1][c] + matrix[r+1][c+1];

                    if(maxSum<sum)
                    {
                        maxSum = sum;
                        maxRowIndex = r;
                        maxColIndex = c;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxRowIndex][maxColIndex]} {matrix[maxRowIndex][maxColIndex+1]}");
            Console.WriteLine($"{matrix[maxRowIndex+1][maxColIndex]} {matrix[maxRowIndex+1][maxColIndex + 1]}");
            Console.WriteLine(maxSum);

        }
    }
}
