using System;
using System.Collections.Generic;

namespace Lab01.ReverseStringsWithStack
{
    class Program
    {
        static void Main(params string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            var stack = new Stack<char>(input);

            //for (int i = 0; i < input.Length; i++)
            //{
            //    stack.Push(input[i]);
            //}
            
            // Print and remove elements:
            while (stack.Count > 0)
            {
                //char last = stack.Pop();
                //Console.Write(last);

                Console.Write(stack.Pop().ToString());
            }
            Console.WriteLine();
        }
    }
}
