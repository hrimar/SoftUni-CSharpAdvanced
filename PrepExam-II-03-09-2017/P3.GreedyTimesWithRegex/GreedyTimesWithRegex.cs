using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P3.GreedyTimesWithRegex
{
    class GreedyTimesWithRegex
    {
        static void Main() // нещо дребно пропускам тук?
        {
            var bag = new Dictionary<string, Dictionary<string, long>>();
            var capacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();
            var regexCash = new Regex(@"(?<cash>\b[a-zA-Z]{3}\b\s\d+)");
            var regexGold = new Regex(@"(?<gold>\b(Gold|GOLD|gold)\b\s\d+)");
            var regexGem = new Regex(@"(?<gem>\b\w+(Gem|GEM|Gem|GEm|geM|gem|gEm|gEM)\b\s\d+)");


            var matchedCashs = regexCash.Matches(input).Cast<Match>()
                .Select(a => a.Groups["cash"].Value);
            var matchedGolds = regexGold.Matches(input).Cast<Match>()
                .Select(a => a.Groups["gold"].Value);
            var matchedGems = regexGem.Matches(input).Cast<Match>()
                .Select(a => a.Groups["gem"].Value);



            foreach (var item in matchedGolds)
            {
                var itemDetails = item.Split();
                var type = itemDetails[0];
                long amount = long.Parse(itemDetails[1]);
                if (!bag.ContainsKey("Gold"))
                {
                    bag["Gold"] = new Dictionary<string, long>();
                }

                long totalAmountCash = bag.Where(a => a.Key == "Cash")
                    .Select(a => a.Value.Sum(b => b.Value)).Sum();
                long totalAmountGold = bag.Where(a => a.Key == "Gold")
                .Select(a => a.Value.Sum(b => b.Value)).Sum();
                long totalAmountGem = bag.Where(a => a.Key == "Gem")
                .Select(a => a.Value.Sum(b => b.Value)).Sum();
                if (capacity >= totalAmountCash + totalAmountGem + totalAmountGold + amount && amount>=totalAmountGem)
                {
                    if (!bag["Gold"].ContainsKey(type))
                    {
                        bag["Gold"][type] = 0;
                    }
                        bag["Gold"][type] += amount;
                }

            }
            foreach (var item in matchedGems)
            {
                var itemDetails = item.Split();
                var type = itemDetails[0];
                long amount = int.Parse(itemDetails[1]);
                if (!bag.ContainsKey("Gem"))
                {
                    bag["Gem"] = new Dictionary<string, long>();
                }

                long totalAmountCash = bag.Where(a => a.Key == "Cash")
                    .Select(a => a.Value.Sum(b => b.Value)).Sum();
                long totalAmountGold = bag.Where(a => a.Key == "Gold")
                .Select(a => a.Value.Sum(b => b.Value)).Sum();
                long totalAmountGem = bag.Where(a => a.Key == "Gem")
                .Select(a => a.Value.Sum(b => b.Value)).Sum();
                if (capacity >= totalAmountCash + totalAmountGem + totalAmountGold + amount && amount >= totalAmountCash)
                {
                    if (!bag["Gem"].ContainsKey(type))
                    {
                        bag["Gem"][type] = 0;
                    }
                    bag["Gem"][type] += amount;
                }
            }

            foreach (var item in matchedCashs)
            {
                var itemDetails = item.Split();
                var type = itemDetails[0];
                long amount = int.Parse(itemDetails[1]);
                if (!bag.ContainsKey("Cash"))
                {
                    bag["Cash"] = new Dictionary<string, long>();
                }
                long totalAmountCash = bag.Where(a => a.Key == "Cash")
                    .Select(a => a.Value.Sum(b => b.Value)).Sum();
                long totalAmountGold = bag.Where(a => a.Key == "Gold")
                .Select(a => a.Value.Sum(b => b.Value)).Sum();
                long totalAmountGem = bag.Where(a => a.Key == "Gem")
                .Select(a => a.Value.Sum(b => b.Value)).Sum();
                if (capacity >= totalAmountCash +totalAmountGem+totalAmountGold+amount )          // !!!
                {
                    if (!bag["Cash"].ContainsKey(type))
                    {
                        bag["Cash"][type] = 0;
                    }
                    bag["Cash"][type] += amount;
                }

            }

            var orderedBag = bag.OrderByDescending(a => a.Value.Sum(b => b.Value));

            foreach (var kvp in orderedBag)
            {
                if(kvp.Value.Sum(s=>s.Value)!=0)
                {
                    long typeAmount = kvp.Value.Sum(a => a.Value);
                    Console.WriteLine($"<{kvp.Key}> ${typeAmount}");
                    foreach (var item in kvp.Value.OrderByDescending(s => s.Key).ThenBy(b => b.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
                
            }

        }
    }
}
