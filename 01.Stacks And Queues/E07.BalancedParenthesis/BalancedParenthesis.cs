using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.BalancedParenthesis
{
    class BalancedParenthesis 
    {
        static void Main() // 100/100 - Excersise 07.
        {            
            var input = Console.ReadLine().ToCharArray();

            // 1. Два масива с еднакви индекси н аотвар и затвар скоби:
            char[] openBrackets = new[] { '(', '[', '{' };
            char[] closedBrackets = ")]}".ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (openBrackets.Contains(element))
                {
                    // 2. Добавяме в стек асамо отварящите скоби:
                    stack.Push(element);
                }
                else if (closedBrackets.Contains(element)) // като почнат затварящите скоби, 
                {
                    // вземаме поледната отваряща скова
                    var lastElement = stack.Pop();
             // в масива виждаме тя н акой индекс е ако в масив асъ сзатварящи скоби не е със същия индек - NO!
                    int openingIndex = Array.IndexOf(openBrackets, lastElement);
                    int closingIndex = Array.IndexOf(closedBrackets, element);

                    if (openingIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}
