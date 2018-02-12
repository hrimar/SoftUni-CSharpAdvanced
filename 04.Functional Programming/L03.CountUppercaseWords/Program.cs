using System;
using System.Linq;

namespace L03.CountUppercaseWords
{
    class Program
    {
        static void Main()
        {
            Func<string, bool> checker = w => Char.IsUpper(w[0]);

          Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) // !!!
                .Where(checker)
                //.Where(w => Char.IsUpper(w[0]))
                .ToList()
                .ForEach(w => Console.WriteLine(w));    // !!!
        }
    }
}
