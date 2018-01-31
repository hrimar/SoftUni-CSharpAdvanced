using System;

namespace Lab04.PascalTriangle
{
    class Program
    {
        static void Main()
        {           //100/100
            var n = int.Parse(Console.ReadLine());
            var matrix = new long[n][];

            for (int r = 0; r < n; r++)
            {
                matrix[r] = new long[r + 1];
                matrix[r][0] = 1;
                matrix[r][matrix[r].Length - 1] = 1;
                if (r >= 2)
                {
                    for (int c = 1; c < r ; c++)
                    {                
                        matrix[r][c] = matrix[r - 1][c - 1] + matrix[r - 1][c];                     
                    }
                }
            }
            // Printing:
            for (int r = 0; r < matrix.Length; r++)
            {
                Console.Write(string.Join(" ", matrix[r]));
                Console.WriteLine();
            }
        }
    }
}
