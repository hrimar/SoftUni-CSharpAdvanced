using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.MaximumElement
{
    class MaximumElement
    {
        static void Main()
        {
            // Зад за намиране на Max елемент от редица, без метода .Max:
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxStack = new Stack<int>();

            maxStack.Push(int.MinValue);    // !!!

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var command = input[0];

                switch (command)
                {
                    case 1:
                        int currentNum = input[1];
                        stack.Push(currentNum);
                        if (currentNum>=maxStack.Peek())
                        {
                           maxStack.Push(currentNum);
                        }
                        break;
                    case 2:
                        var deletedElement = stack.Pop();
                        if (deletedElement == maxStack.Peek())
                        {
                            maxStack.Pop();
                        }
                         break;
                    case 3:
                        //Console.WriteLine(stack.Max()); // така е 75/100. Гърми време заради .Max
                      
                        Console.WriteLine(maxStack.Peek());
                        break;
                }

            }
        }
    }
}
