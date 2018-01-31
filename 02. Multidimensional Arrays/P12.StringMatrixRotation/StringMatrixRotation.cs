using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.StringMatrixRotation
{
    class StringMatrixRotation
    {
        static void Main()      // 100/100
        {
            var command = Console.ReadLine().Split(new char[] { '(', ')' });
            var degrees = int.Parse(command[1]);

            var matrix = new List<List<char>>();

            var input = Console.ReadLine();
            while (input != "END")
            {
                matrix.Add(input.ToCharArray().ToList());

                input = Console.ReadLine();
            }

            matrix = ReaarrangeMatrix(matrix);

            switch (degrees % 360)
            {
                case 0:
                    Rotate0(matrix);
                    break;
                case 90:
                    Rotate90(matrix);
                    break;
                case 180:
                   Rotate180(matrix);
                    break;
                case 270:
                   Rotate270(matrix);
                    break;
            }
            
        }

        private static void Rotate0(List<List<char>> matrix)
        {
            // Print matrix:
            for (int r = 0; r < matrix.Count; r++)
            {
                Console.WriteLine(string.Join("", matrix[r]));
            }
        }

        private static List<List<char>> ReaarrangeMatrix(List<List<char>> matrix)
        {
            int maxLength = 0;
            for (int r = 0; r < matrix.Count; r++)
            {
                var length = matrix[r].Count();
                if (maxLength < length)
                {
                    maxLength = length;
                }
            }

            for (int r = 0; r < matrix.Count; r++)
            {
                for (int c = 0; c < maxLength; c++)
                {
                    if (matrix[r].Count< maxLength)
                    {
                        matrix[r].Add(' ');
                    }
                }
            }
            return matrix;
        }

        private static void Rotate270(List<List<char>> matrix)
        {
           // т.е при принт на 90 или 270 реда става колона:
            for (int r = matrix[0].Count - 1; r >= 0; r--)
            {
                for (int c = 0; c < matrix.Count; c++)
                {
                    Console.Write(matrix[c][r]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotate180(List<List<char>> matrix)
        {
            for (int r = matrix.Count - 1; r >= 0; r--)
            {
                matrix[r].Reverse();
                Console.WriteLine(string.Join("", matrix[r]));
            }
            // or
            //for (int r = matrix.Count - 1; r >= 0; r--)
            //{
            //    for (int c = 0; c < matrix[0].Count; c++)
            //    {
            //        Console.Write(matrix[r][matrix[r].Count - 1 - c]);
            //    }
            //    Console.WriteLine();
            //}
        }

        private static void Rotate90(List<List<char>> matrix)
        {
            for (int r = 0; r < matrix[0].Count; r++)
            {
                for (int c = 0; c < matrix.Count; c++)
                {
                    Console.Write(matrix[matrix.Count-1-c][r]);
                }
                Console.WriteLine();
            }

        }
    }
}
