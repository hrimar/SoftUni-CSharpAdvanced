using System;
using System.Linq;

namespace P13.TriFunction
{
    class TriFunction
    {
        static void Main()  // 100/100
        {
            // ОТ листа words да се принтира дума, за която сумата от карактерите и е >= на даденото число n:
            var n = int.Parse(Console.ReadLine());

            var words = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            //// Var 1:
            //Console.WriteLine(words.FirstOrDefault(name =>name.ToCharArray().Sum(c=>c) >= n));

            //// Var 2:
            //Func<string, int, bool> filter = (word, sum) => word.ToCharArray().Sum(w => w) >= sum;
            //Console.WriteLine(words.FirstOrDefault(word => filter(word, n)));

            // Var 3:
            var filter = CreateFilter(n);
            Console.WriteLine(words.FirstOrDefault(word => filter(word)));
        }

        private static Func<string, bool> CreateFilter(int n)
        {
            return word => word.ToCharArray().Sum(w => w) >= n;

        }
    }
}
