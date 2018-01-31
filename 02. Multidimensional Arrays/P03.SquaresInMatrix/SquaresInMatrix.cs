using System;
using System.Linq;

namespace P03.SquaresInMatrix
{
    class SquaresInMatrix
    {
        static void Main()
        {   // 100/100
            var sizes = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // 1 Read matrix
            var matrix = GetMatrix(sizes);

            // 2. Checking count
            var count = 0;
            for (int r = 0; r < matrix.Length-1; r++)
            {
                for (int c = 0; c < matrix[r].Length-1; c++)
                {
                    char cell = matrix[r][c];
                    if(cell ==matrix[r+1][c+1] && cell == matrix[r][c + 1]&& cell == matrix[r + 1][c])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        private static char[][] GetMatrix(int[] sizes)
        {
            var rowCount = sizes[0];
            var colCount = sizes[1];

            var matrix = new char[rowCount][];

            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r] = Console.ReadLine()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }
            return matrix;
        }
    }
}
