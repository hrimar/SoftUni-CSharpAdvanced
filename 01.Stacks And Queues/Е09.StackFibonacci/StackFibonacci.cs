using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E09.StackFibonacci
{
    class StackFibonacci
    {
        static void Main() // 100/100 - ПАК Я РЕШИ - ТОВА Е ХИТЪР ПОДХОД!
        {
            // from 0 to 5 => 0, 1, 1, 2, 3, 5
            var n = int.Parse(Console.ReadLine());

            var result = GetFibonacci(n);
            Console.WriteLine(result);
    
        }

        private static long GetFibonacci(int n)
        {
            var stack = new Stack<long>(new long[] { 0, 1 });
           
                for (int i = 1; i < n; i++)
                {
                var elemMinus1 = stack.Pop();
                var elemMinus2 = stack.Peek();
                stack.Push(elemMinus1);
                stack.Push(elemMinus1 + elemMinus2);
                }

            return stack.Peek();
        }
    }
}
