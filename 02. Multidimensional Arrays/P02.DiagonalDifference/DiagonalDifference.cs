using System;
using System.Linq;

namespace P02.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main()
        {       // 100/100:
            var size = int.Parse(Console.ReadLine());
                     
            int sum = 0;
            
            // 1 Read matrix
           var matrix = GetMatrix(size);

            int primariDiagonal = GetPrimariDiangonal(matrix);
            int seconDiagonal = GetSecondDiagonal(matrix);
            sum = Math.Abs(primariDiagonal - seconDiagonal);
                        
            Console.WriteLine(sum);
        }

        private static int GetSecondDiagonal(int[][] matrix)
        {
            int secondDiagonalSum = 0;
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix.Length-1-r == c)
                    {secondDiagonalSum += matrix[r][c];
                    }
                }
            }
            return secondDiagonalSum;
        }

        private static int GetPrimariDiangonal(int[][] matrix)
        {
            int firstDiagonalSum = 0;
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (r == c)
                    {
                        firstDiagonalSum += matrix[r][c];
                    }
                }
            }
            return firstDiagonalSum;
        }

        private static int[][] GetMatrix(int size)
        {
            var matrix = new int[size][];
          
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
