using System;
using System.Collections.Generic;
using System.Linq;

namespace L02.SumNumbers
{
    class Program
    {
        static void Main()
        {
            Func<string, int> parser = n => int.Parse(n);

            var nums = Console.ReadLine()
                 .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(parser)
                 .OrderBy(n => n);

            int count = nums.Count();
            int sum = nums.Sum();

            Console.WriteLine(count);
            Console.WriteLine(sum);            
        }
    }
}
