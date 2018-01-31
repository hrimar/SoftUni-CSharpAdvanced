using System;
using System.Collections.Generic;
using System.Text;

namespace E10.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main()  // 100/100 - Имитация нa UNDО !!!
        { 
            var n = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var oldVersions = new Stack<string>();
            oldVersions.Push("");   // dobre е да имаме първо "" за да ен стигаме до stack.Count=0

            for (int i = 0; i < n; i++)
            {
                var commandInput = Console.ReadLine().Split();
                var command = int.Parse(commandInput[0]);

                switch (command)
                {
                    case 1:
                        oldVersions.Push(text.ToString()); // 

                        var newString = commandInput[1];
                        text.Append(newString);
                        break;
                    case 2:
                        oldVersions.Push(text.ToString());

                        int length = int.Parse(commandInput[1]);
                        text.Remove(text.Length - length, length);
                        break;
                    case 3:
                        int index = int.Parse(commandInput[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text.Clear(); // трием буилдъра за да му сложим посл стара операция
                        text.Append(oldVersions.Pop());
                        break;
                }

            }
        }
    }
}
