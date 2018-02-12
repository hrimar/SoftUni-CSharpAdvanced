using System;
using System.Collections.Generic;
using System.Linq;

namespace L05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var peoples = new Dictionary<string, int>(peopleCount); //  так аспестяваме удвояването

            for (int i = 0; i < peopleCount; i++)
            {
                var nameAndAge = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                peoples.Add(nameAndAge[0], int.Parse(nameAndAge[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filter = CreateFilter(condition, age); // Делегат!
            var printer = CreatePrinter(format); // Делегат!

            foreach (var person in peoples)
            {
                if (filter(person.Value)) // т.е. подаваме пром. дърваща функ-я, връщаща bool
                {
                    printer(person); // за принт на всеки човек в съотв формат
                }                
            }
            // или вместо foreach-a:
            // peoples.Where(p => filter(p.Value)).ToList().ForEach(printer);
        }

        static Func<int, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }

        static Action<KeyValuePair<string, int>>CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x=>Console.WriteLine(x.Key); // тук 'х' ни е kvp от Action<KeyValuePair<string, int>>
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
