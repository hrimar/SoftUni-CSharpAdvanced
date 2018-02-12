using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ReverseAndexclude
{
    class ReverseAndexclude
    {
        static void Main()  // 100/100
        {
            var array = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            var n = int.Parse(Console.ReadLine());

            var result = new List<int>();

            Func<int, bool> func = x => x % n == 0;

            for (int i = array.Length-1; i >= 0 ; i--)
            {
                if(!func(array[i]))
                {
                    result.Add(array[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
