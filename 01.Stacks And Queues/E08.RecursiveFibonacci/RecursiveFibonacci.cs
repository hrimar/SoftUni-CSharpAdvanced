using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E08.RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        private static long[] fibonacciArray;

        static void Main() // Мале тая рекурсия............????????????????????
        {
            var n = int.Parse(Console.ReadLine());

            fibonacciArray = new long[n];
                        
            Console.WriteLine(GetFibonacci(n-1));
        }

        private static long GetFibonacci(int n)
        {            
            if (n < 2)
            {
                return 1;
            }
            if(fibonacciArray[n]==0)
            {
               fibonacciArray[n]= GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }
            
            return fibonacciArray[n];
        }
    }
}
