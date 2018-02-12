using System;
using System.Linq;

namespace P05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()  // 100/100
        {
            var array = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var input = Console.ReadLine();
            while (input != "end")
            {
                Func<int, int> func = x=>x;

                switch (input)
                {
                    case "add":
                        func = x => x = x + 1;
                        break;
                    case "multiply":
                        func = x => x = x * 2;
                        break;
                    case "subtract":
                        func = x => x = x - 1;
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", array));
                        break;
                    default:
                        func = null;
                        break;
                }
                array = ChangeArray(array, func);

                input = Console.ReadLine();
            }
        }

        private static int[] ChangeArray(int[] array, Func<int, int> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }

            return array;
        }
    }
}
