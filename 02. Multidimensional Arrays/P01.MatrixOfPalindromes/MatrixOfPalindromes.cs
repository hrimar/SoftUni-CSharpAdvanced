using System;
using System.Linq;
using System.Text;

namespace P01.MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main()
        {
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //DateTime start = DateTime.Now;

            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = sizes[0];
            var cols = sizes[1];

            var sb = new StringBuilder();

            var matrix = new string[rows][];
            for (int r = 0; r < rows; r++)
            {
                matrix[r] = new string[cols];

                for (int c = 0; c < cols; c++)
                {
                    sb.Clear();
                    char firstLetter = ((char)('a' + r));
                    char secondLetter = ((char)('a' + r + c));
                    char thirdLetter = ((char)('a' + r));

                    // Var 1: with string - 6 685202 clicks
                    matrix[r][c] = $"{firstLetter}{secondLetter}{thirdLetter}";

                    // Var 2: with StringBuilder - 5 349 022 clicks
                    //sb.Append((char)firstLetter);
                    //sb.Append((char)secondLetter);
                    //sb.Append((char)thirdLetter );

                   // matrix[r][c] = sb.ToString();

                }
                //sb.AppendLine();
            }

            // Printing:
            for (int r = 0; r < matrix.Length; r++)
            {
                Console.Write(string.Join(" ", matrix[r]));
                Console.WriteLine();
            }


            //DateTime end = DateTime.Now;
            //Console.WriteLine(end - start);
            //watch.Stop();
            //Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
