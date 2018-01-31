using System;
using System.Collections.Generic;

namespace Lab02.SimpleCalculatorWithSteck
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            var stack = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                switch (operation)
                {
                    case "+": stack.Push((leftOperand + rightOperand).ToString()); break;
                    case "-": stack.Push((leftOperand - rightOperand).ToString()); break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
