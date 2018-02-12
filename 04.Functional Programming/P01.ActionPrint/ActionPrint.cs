using System;

namespace P01.ActionPrint
{
    class ActionPrint
    {
        static void Main()  // 100/100
        {
            var words = Console.ReadLine()
             .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Action<string> printing = w => Console.WriteLine(w); // 1.declaration

            foreach (var w in words)
            {
              printing(w); // 2. invocing
            }
          
        }
    }
}
