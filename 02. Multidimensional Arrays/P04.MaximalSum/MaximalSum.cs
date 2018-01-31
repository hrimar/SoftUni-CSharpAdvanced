using System;
using System.Linq;

namespace P04.MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // 1 Read matrix
            var matrix = GetMatrix(sizes);

            // 2. Checking sum
            var sum = 0;
            var maxSum = int.MinValue;
            int rowStartIndex = -1;
            int colStartIndex = -1;

            for (int r = 0; r < matrix.Length - 2; r++)
            {
                for (int c = 0; c < matrix[r].Length - 2; c++)
                {
                   
                    sum = matrix[r][c]+matrix[r][c+1]+matrix[r][c+2]+
                        matrix[r+1][c] + matrix[r+1][c + 1] + matrix[r+1][c + 2]+
                        matrix[r+2][c] + matrix[r+2][c + 1] + matrix[r+2][c + 2];

                    if(maxSum<sum)
                    {
                        maxSum = sum;
                        rowStartIndex = r;
                        colStartIndex = c;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[rowStartIndex][colStartIndex]} {matrix[rowStartIndex][colStartIndex + 1]} {matrix[rowStartIndex][colStartIndex + 2]}"+Environment.NewLine+
                        $"{ matrix[rowStartIndex + 1][colStartIndex]} {matrix[rowStartIndex + 1][colStartIndex + 1]} {matrix[rowStartIndex + 1][colStartIndex + 2]}"+Environment.NewLine+
                       $"{matrix[rowStartIndex + 2][colStartIndex]} {matrix[rowStartIndex + 2][colStartIndex + 1]} {matrix[rowStartIndex + 2][colStartIndex + 2]}");
        }

        private static int[][] GetMatrix(int[] sizes)
        {
            var rowCount = sizes[0];
            var colCount = sizes[1];

            var matrix = new int[rowCount][];

            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r] = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            return matrix;
        }
    }
}
