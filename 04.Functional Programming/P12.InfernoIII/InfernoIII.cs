using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.InfernoIII
{
    class InfernoIII
    {
        static void Main() // оф малеее 100/100...
        {
            var gems = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse) 
               .ToList();

            // Dictionari<funcName, List<func>, List<param
            var filters = new Dictionary<string, Func<List<int>, List<int>>>(); // za filtrite

            string command;
            while ((command = Console.ReadLine()) != "Forge")
            {
                ParseCommand(command, filters);
            }

            // за да изпълним всички филтри н аведнъж си правим нов списък
            var filtered = GetFiltered(gems, filters);

            gems = gems.Where(gem => !filtered.Contains(gem)).ToList();

            string result = string.Join(" ", gems);
            Console.WriteLine(result);
        }

        private static List<int> GetFiltered(List<int> gems, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            var filtered = new List<int>();

            foreach (var pair in filters)
            {
                var filter = pair.Value;

                filtered.AddRange(filter(gems));
            }

            return filtered;
        }

        private static void ParseCommand(string commandInput, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            string[] tokens = commandInput.Split(';');
            string command = tokens[0];
            string filterType = tokens[1];
            int parameter = int.Parse(tokens[2]);

            string dictKey = $"{filterType} {parameter}";

            if (command == "Exclude")
            {
                filters[dictKey] = CreateFunction(filterType, parameter);
            }
            else if(command == "Reverse")
            {
                filters.Remove(dictKey);
            }
        }

        private static Func<List<int>, List<int>> CreateFunction(string filterType, int parameter)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftGem = index > 0 ? gems[index - 1] : 0;  // ako няма съседен елем в ляво даваме 0-ла
                        return gem + leftGem == parameter;
                    }).ToList();
                case "Sum Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int rightGem = index < gems.Count-1 ? gems[index + 1] : 0;  // ako няма повече елем в дясно даваме 0-ла
                        return gem + rightGem == parameter;
                    }).ToList();
                case "Sum Left Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftGem = index > 0 ? gems[index - 1] : 0;  
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return leftGem + gem + rightGem == parameter;
                    }).ToList();
                default:
                    throw new NotImplementedException("No Sum Left, Sum Right or Sum Left Right");
            }
        }
    }
}
