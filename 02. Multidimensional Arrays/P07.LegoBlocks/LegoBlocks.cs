using System;
using System.Linq;

namespace P07.LegoBlocks
{
    class LegoBlocks
    {
        static void Main()
        {
            //100/100 само дооправи кода
            var numOfMatrix = int.Parse(Console.ReadLine());

            var matrix1 = GetMatrix(numOfMatrix);
            var matrix2 = GetMatrix(numOfMatrix);

            matrix2 = ReversingMtrix(matrix2);

            // Concat both matrices:
            var elementsCount = 0;
            var resultMatrix = new int[matrix1.Length][];
            for (int i = 0; i < matrix1.Length; i++)
            {
                resultMatrix[i] = matrix1[i].Concat(matrix2[i]).ToArray();
                elementsCount += resultMatrix[i].Length;
            }

            // CheckingTotalMatrix(resultMatrix);
            bool isMatrix = true;          
            for (int i = 0; i < resultMatrix.Length - 1; i++)
            {
                // ПРОВЕКА ДАЛИ ЕДНА МАТРИВЦА Е ПРАВОЪГ ИЛИ JAGGED 
                if (resultMatrix[i].Length != resultMatrix[i + 1].Length)
                {
                    isMatrix = false;
                    break;
                }               
            }
            if (isMatrix)
            {
                PrintMatrix(resultMatrix);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {elementsCount}");
            }

            // PrintMatrix(resultMatrix);
            // PrintMatrix(matrix2);
        }

        private static void CheckingTotalMatrix(int[][] resultMatrix)
        {
            bool isMatrix = true;
            var elementsCount = 0;
            for (int i = 0; i < resultMatrix.Length-1; i++)
            {
                // КАК СЕ ПРОВЕРЯВА ДАЛИ ЕДНА МАТРИВЦА Е ПРАВОЪГ ИЛИ JAGGED ???
                if (resultMatrix[i].Length != resultMatrix[i+1].Length)
                {
                    isMatrix = false;
                }
                elementsCount += resultMatrix[i].Length;
            }
            if(isMatrix)
            {
                PrintMatrix(resultMatrix);
            }
            else
            {

            }
        }

        private static int[][] ReversingMtrix(int[][] matrix2)
        {
            var reversedMatrix = new int[matrix2.Length][];
            for (int r = 0; r < matrix2.Length; r++)
            {
                reversedMatrix[r] = matrix2[r].Reverse().ToArray();
            }

            return reversedMatrix;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                Console.Write($"[{string.Join(", ", matrix[r])}]");
                Console.WriteLine();
            }
        }

        private static int[][] GetMatrix(int numOfMatrix)
        {
            var matrix1 = new int[numOfMatrix][];
            var matrix2 = new int[numOfMatrix][];

            for (int r = 0; r < numOfMatrix; r++)
            {
                matrix1[r] = Console.ReadLine()
                     .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            return matrix1;
        }
    }
}
