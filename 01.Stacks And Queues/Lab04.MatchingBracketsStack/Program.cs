using System;
using System.Collections.Generic;

namespace Lab04.MatchingBracketsStack
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var stackOpenBracketIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stackOpenBracketIndexes.Push(i); // вкарваме индекса на '('
                }
                if (input[i] == ')')
                {
                    var openBracketIndex = stackOpenBracketIndexes.Pop(); // връщаме индекса на '('
                    var length = i - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, length));
                }
            }
        }
    }
}
