using System;
using System.Linq;

namespace P03.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main()  //100/100
        {
            var nums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> getingMin = n => n.Min(); // 1. Declare

            Action<int> print = n => Console.WriteLine(n);

            print(getingMin(nums)); // 2. Invoke
        } 
    }
}
