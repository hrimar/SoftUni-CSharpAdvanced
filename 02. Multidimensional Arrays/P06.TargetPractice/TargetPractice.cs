using System;
using System.Linq;

namespace P06.TargetPractice
{
    class TargetPractice
    {
        static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var text = Console.ReadLine();

            var input = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // 1. Create matrix
            var matrix = GetMatrix(sizes, text);

            // 2. Bomb matrix
            matrix = BombMatrix(matrix, input);

            // 3. Rearange matrix:
            matrix = Gravity(matrix);

            // 4. Printing:
            for (int r = 0; r < matrix.Length; r++)
            {
                Console.Write(string.Join("", matrix[r]));
                Console.WriteLine();
            }
        }

        private static char[][] Gravity(char[][] matrix) // !!!
        {
            // завъртаме матрицата и ако над празните клетки има нещо, то го слагаме края:
            for (int col = 0; col < matrix[0].Length; col++)
            {
                int emptyRows = 0;
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    if (matrix[row][col] == ' ')
                    {
                        emptyRows++;
                    }
                    else if (emptyRows > 0)
                    {

                        matrix[row + emptyRows][col] = matrix[row][col];
                        matrix[row][col] = ' ';
                    }
                }
            }

            return matrix;
        }

        private static char[][] BombMatrix(char[][] matrix, int[] input)
        {
            int row = input[0];
            int column = input[1];
            int radius = input[2];

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    int a = row - r;
                    int b = column - c;
                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance <= radius)
                    {
                        matrix[r][c] = ' ';
                    }
                }
            }

            return matrix;
        }

        private static char[][] GetMatrix(int[] sizes, string text)
        {
            var rows = sizes[0];
            var cols = sizes[1];
            char[][] matrix = new char[rows][];

            bool isGoingLeft = true;

            int textIndex = 0;

            for (int r = rows - 1; r >= 0; r--)
            {
                matrix[r] = new char[cols];
                int index = isGoingLeft ? cols - 1 : 0;
                int increment = isGoingLeft ? -1 : 1;
                for (int c = 0; c < cols; c++)
                {
                    matrix[r][index] = text[textIndex];
                    textIndex++;

                    if (textIndex > text.Length - 1)
                    {
                        textIndex = 0;
                    }
                    index += increment;
                }
                isGoingLeft = !isGoingLeft;
            }

            return matrix;
        }

    }
}
