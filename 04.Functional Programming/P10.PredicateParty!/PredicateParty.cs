
using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.PredicateParty_
{
    class PredicateParty
    {
        static void Main()
        {
            // Var - 100/100:
            var names = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var inputDetails = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = inputDetails[0];
                var criteria = inputDetails[1];
                string surched = inputDetails[2];

                Predicate<string> predicateStartWith = n => n.StartsWith(surched);
                Predicate<string> predicateEndWith = n => n.EndsWith(surched);
                Predicate<string> predicateLength = n => n.Length == int.Parse(surched);
                
                if (command == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            names.RemoveAll(predicateStartWith); // !!
                            break;
                        case "EndsWith":
                            names.RemoveAll(predicateEndWith);  // !!
                            break;
                        case "Length":
                            names.RemoveAll(predicateLength);
                            break;
                    }
                }
                else if (command == "Double")
                {
                    List<string> exactNames = new List<string>();
                    switch (criteria)
                    {
                        case "StartsWith":
                            exactNames = names.FindAll(predicateStartWith);
                            names.AddRange(exactNames);
                            break;
                        case "EndsWith":
                            exactNames = names.FindAll(predicateEndWith);
                            names.AddRange(exactNames);
                            break;
                        case "Length":
                            exactNames = names.FindAll(predicateLength);
                            foreach (var name in exactNames)
                            {
                                int index = names.LastIndexOf(name);
                                names.Insert(index, name);
                            }
                            break;
                    }
                }
            }

            if (names.Count != 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

    }
}