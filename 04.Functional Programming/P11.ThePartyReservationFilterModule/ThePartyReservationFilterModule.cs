using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.ThePartyReservationFilterModule
{
    class ThePartyReservationFilterModule
    {
        static void Main() // Breeee... 100/100...
        {
            var namesList = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> originalList = new List<string>(namesList);
            List<string> forRemoving = new List<string>();
            List<string> forAddBack = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                var inputDetails = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var addRemove = inputDetails[0];
                var criteria = inputDetails[1];
                string parameter = inputDetails[2];

                Predicate<string> startPredicate = w => w.StartsWith(parameter);
                Predicate<string> endPredicate = w => w.EndsWith(parameter);
                Predicate<string> lengthPredicate = w => w.Length == int.Parse(parameter);
                Predicate<string> containsPredicate = w => w.Contains(parameter);

                if (addRemove == "Add filter")
                {
                    switch (criteria)
                    {
                        case "Starts with":
                            forRemoving = namesList.FindAll(startPredicate);
                            break;
                        case "Ends with":
                            forRemoving = namesList.FindAll(endPredicate);
                            break;
                        case "Length":
                            forRemoving = namesList.FindAll(lengthPredicate);
                            break;
                        case "Contains":
                            forRemoving = namesList.FindAll(containsPredicate);
                            break;
                    }

                    foreach (var nameForRemoving in forRemoving)
                    {
                        for (int i = 0; i < namesList.Count; i++)
                        {
                            if (nameForRemoving == namesList[i])
                            {
                                namesList[i] = string.Empty;
                            }
                        }
                    }
                }
                else if (addRemove == "Remove filter")
                {
                    switch (criteria)
                    {
                        case "Starts with":
                            forAddBack = originalList.FindAll(startPredicate);
                            break;
                        case "Ends with":
                            forAddBack = originalList.FindAll(endPredicate);
                            break;
                        case "Length":
                            forAddBack = originalList.FindAll(lengthPredicate);
                            break;
                        case "Contains":
                            forAddBack = originalList.FindAll(containsPredicate);
                            break;
                    }

                    foreach (var name in forAddBack)
                    {
                        int index = originalList.LastIndexOf(name);
                        namesList[index] = name;
                    }
                }
            }

            foreach (string name in namesList)
            {
                if (name !=string.Empty)
                {
                    Console.Write($"{name} ");
                }
            }
            Console.WriteLine();
        }
    }
}
