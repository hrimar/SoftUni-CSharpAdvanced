using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03.GroupNumbers
{
    class Program
    {
        static void Main()
        {
            var inputArray = Console.ReadLine()
              .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            // Var1: 100/100
            var firstRow = inputArray.Where(e => Math.Abs(e % 3) == 0).ToArray();
            var secondRow = inputArray.Where(e => Math.Abs(e % 3) == 1).ToArray();
            var thirdRow = inputArray.Where(e => Math.Abs(e % 3) == 2).ToArray();

            var result = new int[3][];
            result[0] = firstRow;
            result[1] = secondRow;
            result[2] = thirdRow;

            //Printing:
            for (int r = 0; r < result.Length; r++)
            {
                Console.Write(string.Join(" ", result[r]));
                Console.WriteLine();
            }
        }
    }
}
