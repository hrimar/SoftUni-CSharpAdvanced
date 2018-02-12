using System;
using System.Linq;

namespace L04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(n=>double.Parse(n, System.Globalization.CultureInfo.InvariantCulture)) // ako вместо 1.2 дава 1,2
                        .Select(n => n * 1.2);

            foreach (var n in nums)
            {
                Console.WriteLine($"{n:f2}");
            }
        }
    }
}
