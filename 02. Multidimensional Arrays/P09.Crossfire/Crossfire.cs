using System;
using System.Linq;

namespace P09.Crossfire
{
    class Crossfire
    {
        static void Main()
        {
            //100 /100
            var sizes = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // 1.
            var matrix = GetMatrix(sizes);

            // 2.
            var input = Console.ReadLine();
            while (input != "Nuke it from orbit")
            {
                // 2.1 - Bomb matrix
                matrix = DestroyMatrix(matrix, input);

                // 2.1 Rearange matrix:
                matrix = RearangeMatrix(matrix);

                input = Console.ReadLine();
            }

            // 4. Printing:
            for (int r = 0; r < matrix.Length; r++)
            {
                Console.Write(string.Join(" ", matrix[r]));
                Console.WriteLine();
            }

        }

        private static int[][] RearangeMatrix(int[][] matrix)
        {
            //for (int r = 0; r < matrix.Length; r++)
            //{
            //    matrix[r] = matrix[r].Where(e => e > 0).ToArray();
            //}

            for (int i = 0; i < matrix.Length; i++)
            {
                // Remove destroyed cells if there is ones
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 0)
                    {
                        // на ред, на който има -1 махамe тази ст-ст и пренареждаме реда:
                        matrix[i] = matrix[i].Where(n => n > 0).ToArray();
                        break;
                    }
                }

                // Remove empty rows - НО МОЖЕ и БЕЗ него, явно празен масив не се принтира
                if (matrix[i].Count() < 1) //    if (matrix[i].Count() == 0)
                {
                    // за махане на i-тия ред от масива и долепяне на i+1 на негово място:
                    matrix = matrix.Take(i).Concat(matrix.Skip(i + 1)).ToArray();
                    // or
                    // matrix.RemoveAt(i); ако ползвахме List<List<int>>()
                    i--;
                }
            }

            return matrix;
        }

        private static int[][] DestroyMatrix(int[][] matrix, string input)
        {
            var inputDetails = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int row = inputDetails[0];
            int column = inputDetails[1];
            int radius = inputDetails[2];

            // Така не е събсем добре.По-добре с отделен метод за валидация
            //// Mark destroyed part of the column
            //for (int r = row - radius; r <= row + radius; r++)
            //{
            //    if (r > matrix.Length - 1 || r < 0)
            //    {
            //        continue;
            //    }
            //    if (column > matrix[r].Length - 1 || column < 0)
            //    {
            //        continue;
            //    }
            //    matrix[r][column] = -1;
            //}
            //// Mark destroyed part of the row:
            //for (int c = column - radius; c <= column + radius; c++)
            //{
            //    if (c > matrix[row].Length - 1 || c < 0)
            //    {
            //        continue;
            //    }
            //    if (row > matrix.Length - 1 || row < 0)
            //    {
            //        continue;
            //    }
            //    matrix[row][c] = -1;
            //}



            // Mark destroyed part of the column
            for (int r = row - radius; r <= row + radius; r++)  // !
            {
                if (IsInMatrix(r, column, matrix))
                {
                    matrix[r][column] = -1;
                }
            }

            // Mark destroyed part of the row
            for (int c = column - radius; c <= column + radius; c++)  // !
            {
                if (IsInMatrix(row, c, matrix))
                {
                    matrix[row][c] = -1;
                }
            }

            return matrix;
        }


        private static bool IsInMatrix(int row, int col, int[][] matrix)  // Метод за валидация на матрици!
        {
            if (row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length)
            {
                return true;
            }

            return false;

            // or:
            //return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;           
        }

        private static int[][] GetMatrix(int[] sizes)
        {
            var rowCount = sizes[0];
            var colCount = sizes[1];

            var startElement = 1;

            var matrix = new int[rowCount][];

            for (int r = 0; r < rowCount; r++)
            {
                matrix[r] = new int[colCount];
                for (int c = 0; c < colCount; c++)
                {
                    matrix[r][c] = startElement;
                    startElement++;
                }
            }
            return matrix;
        }
    }
}
