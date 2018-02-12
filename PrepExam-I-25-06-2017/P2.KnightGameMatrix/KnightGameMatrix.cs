using System;

namespace P2.KnightGameMatrix
{
    class Program
    {
        // 100 /100
        static char[][] matrix;

        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            // 1 Get Matrix:
            matrix = GetMatrix(size);
            // 2. Check everi K:
            int maxAtackedPositions = int.MinValue; ;
            int maxRow = 0;
            int maxCol = 0;
            int counter = 0;

            do
            {
                if (maxAtackedPositions > 0)
                {
                    matrix[maxRow][maxCol] = 'O';
                    maxAtackedPositions = 0;
                    counter++;
                }

                int currentAttacPosition = 0;
                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size; c++)
                    {
                        if (matrix[r][c] == 'K')
                        {
                            currentAttacPosition = CalcCount(r, c);
                            if (currentAttacPosition > maxAtackedPositions)
                            {
                                maxAtackedPositions = currentAttacPosition;
                                maxRow = r;
                                maxCol = c;
                            }
                        }
                    }

                }

            } while (maxAtackedPositions > 0);

            Console.WriteLine(counter);
        }

        private static int CalcCount(int row, int col)
        {
            int currentAtackPositions = 0;
            // за всеки отделен слуюай проверяваме дали е в масива и дали е 'К':
            if (IsPositionAttachked(row - 2, col - 1))
                currentAtackPositions++;

            if (IsPositionAttachked(row - 2, col + 1))
                currentAtackPositions++;

            if (IsPositionAttachked(row - 1, col + 2))
                currentAtackPositions++;

            if (IsPositionAttachked(row - 1, col - 2))
                currentAtackPositions++;

            if (IsPositionAttachked(row +1, col -2))
                currentAtackPositions++;

            if (IsPositionAttachked(row +1, col +2))
                currentAtackPositions++;

            if (IsPositionAttachked(row + 2, col + 1))
                currentAtackPositions++;

            if (IsPositionAttachked(row + 2, col -1))
                currentAtackPositions++;

            return currentAtackPositions;
        }

        static bool IsPositionAttachked(int row, int col)
        {
            return IsPositionInMatrix(row, col) && matrix[row][col] == 'K';
        }

        static bool IsPositionInMatrix(int r, int c)
        {
            return r >= 0 && c >= 0 && r < matrix.Length && c < matrix[0].Length;
        }

        private static char[][] GetMatrix(int size)
        {
            matrix = new char[size][];
            for (int r = 0; r < size; r++)
            {
                matrix[r] = Console.ReadLine().ToCharArray();
            }
            return matrix;
        }
    }
}
