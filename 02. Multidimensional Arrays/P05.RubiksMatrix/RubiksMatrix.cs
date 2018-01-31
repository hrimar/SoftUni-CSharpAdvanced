using System;
using System.Linq;

namespace P05.RubiksMatrix
{
    class Rubik_sMatrix
    {
        //private static int[][] matrix; - мошех и да правим матрицата да е глобална за да я достъ. от сякъде

        static void Main()  // 100/100
        {
            // Важна задача за въртене на редове и колони!:
            var sizes = Console.ReadLine().Split();

            var matrix = InitialMatrix(sizes);

            var commandNum = int.Parse(Console.ReadLine());


            for (int i = 0; i < commandNum; i++) // while (commandNum>0) //
            {
                var command = Console.ReadLine().Split();
                var rcIndex = int.Parse(command[0]);
                var direction = command[1];
                var moves = int.Parse(command[2]);

                switch (direction)
                {
                    case "up": MoveCol(matrix, rcIndex, moves); break;
                    case "down": MoveCol(matrix, rcIndex, matrix.Length - moves % matrix.Length); break;
                    case "left": MoveRow(matrix, rcIndex, moves); break;
                    case "right": MoveRow(matrix, rcIndex, matrix[rcIndex].Length - moves % matrix.Length); break;
                        //   case "right": MoveRow(matrix, rcIndex, cols - moves % rows); break;
                }
            }
            // Преподреждане на елементите:
            var element = 1;
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int ri = 0; ri < matrix.Length; ri++)
                        {
                            for (int ci = 0; ci < matrix[0].Length; ci++)
                            {
                                if (matrix[ri][ci] == element)
                                {
                                    var currentElement = matrix[r][c];
                                    matrix[r][c] = matrix[ri][ci];
                                    matrix[ri][ci] = currentElement;
                                    Console.WriteLine($"Swap ({r}, {c}) with ({ri}, {ci})");
                                    break;
                                }
                            }

                        }
                    }
                    element++;
                }
            }
            // PrintMatrix(matrix);
        }

        private static void MoveRow(int[][] matrix, int rcIndex, int moves)
        {
            var tempArr = new int[matrix[rcIndex].Length];
            for (int c = 0; c < matrix[rcIndex].Length; c++)
            {
                tempArr[c] = matrix[rcIndex][(c + moves) % matrix[rcIndex].Length];
            }

            matrix[rcIndex] = tempArr;

        }

        private static void MoveCol(int[][] matrix, int rcIndex, int moves)
        {
            var tempArr = new int[matrix.Length];
            for (int r = 0; r < matrix.Length; r++)
            {
                tempArr[r] = matrix[(r + moves) % matrix.Length][rcIndex];
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r][rcIndex] = tempArr[r];
            }
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int[][] InitialMatrix(string[] sizes)
        {
            var rows = int.Parse(sizes[0]);
            var cols = int.Parse(sizes[1]);

            int num = 1;

            int[][] matrix = new int[rows][];
            for (int r = 0; r < rows; r++)
            {
                matrix[r] = new int[cols];
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    matrix[r][c] = num;
                    num++;
                }
            }

            // или ако беше List<List<int>>() :
            //var matrix = new List<List<int>>();   // !!!
            //var number = 1;
            //for (int row = 0; row < size[0]; row++)
            //{
            //    matrix.Add(new List<int>());      // !!!
            //    for (int col = 0; col < size[1]; col++)
            //    {
            //        matrix[row].Add(number++);
            //    }
            //}
            return matrix;
        }
    }    
}
