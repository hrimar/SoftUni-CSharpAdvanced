using System;
using System.Collections.Generic;
using System.Linq;

namespace P2_KnightGame
{
    public class Knight
    {
        public int Count { get; set; } = 0;
        public int Row { get; set; }
        public int Col { get; set; }
    }

    class KnightGame
    {
        static void Main()
        {
            var knightList = new List<Knight>();

            var size = int.Parse(Console.ReadLine());
            // 1 Get Matrix:
            char[][] matrix = GetMatrix(size);
            // 2. Check everi K:
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {                  
                    if(matrix[r][c] == 'K')
                    {


                        var currentKnight = new Knight()
                        {
                            Count=1,
                            Row = r,
                            Col=c
                        };
                        knightList.Add(currentKnight);
                        if(r-2>=0 && r+2<size && c-1>=0 && c+1<size)
                        {
                            if(matrix[r-2][c+1] == 'K' || matrix[r - 2][c - 1] == 'K'  )
                            {
                                currentKnight.Count++;
                            }                          
                        }
                        else if (r-1>=0 && r+1<size && c-2>=0 && c+2<size)
                        {
                            if (matrix[r - 1][c + 2] == 'K' || matrix[r - 1][c - 2] == 'K')
                            {
                                currentKnight.Count++;
                            }
                        }
                        //else if (r >= 0 && r < size && c - 1 >= 0 && c + 1 < size)
                        //{
                        //    if (matrix[r][c + 1] == 'K' || matrix[r - 1][c - 2] == 'K')
                        //    {
                        //        currentKnight.Count++;
                        //    }
                        //}
                    }
                }                               
               
            }
            // извод: и така с класове става само дореши задачата - виж отделните случай!

            var winner = knightList.OrderBy(k => k.Count).FirstOrDefault();
            Console.WriteLine(winner.Count);
        }

        private static char[][] GetMatrix(int size)
        {
            char[][] matrix = new char[size][];
            for (int r = 0; r < size; r++)
            {
                matrix[r] = Console.ReadLine().ToCharArray();
            }
            return matrix;
        }

        private static bool IsInMatrix(int row, int col, int[][] matrix) //валидация на матрици
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

    }
}
