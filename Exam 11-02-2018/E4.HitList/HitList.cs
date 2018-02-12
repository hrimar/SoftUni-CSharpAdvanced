using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace E4.HitList
{
    class HitList
    {
        static string details;
        static string name;

        static void Main()
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            var result = new Dictionary<string, List<string>>(); // taka 80/100
            // Dictionary<string, Dictionary<string, string>>(); - try this!

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                if (input.Contains(';'))
                {
                    var inputDetails = input.Split(';');
                    for (int i = 0; i < inputDetails.Length; i++)
                    {
                        if (i == 0)
                        {
                            var detailsForOneName = inputDetails[i].Split('=');
                            name = detailsForOneName[0];
                            details = detailsForOneName[1];
                        }
                        else
                        {
                            details = inputDetails[i];
                        }

                        if (!result.ContainsKey(name))
                        {
                            result[name] = new List<string>();
                        }
                        result[name].Add(details);
                    }
                }
                else
                {
                    var detailsForOneName = input.Split('=');
                    name = detailsForOneName[0];
                    details = detailsForOneName[1];

                    if (!result.ContainsKey(name))
                    {
                        result[name] = new List<string>();
                    }
                    result[name].Add(details);
                }
            }

            var targetInput = Console.ReadLine();
            var targetDetails = targetInput.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string targetName = targetDetails[1];

            foreach (var kvp in result.OrderBy(x => x.Key))
            {
                if (kvp.Key == targetName)
                {
                    Console.WriteLine($"Info on {kvp.Key}:");
                    foreach (var details in kvp.Value.OrderBy(a => a))
                    {
                        var personalDetails = details.Split(':');
                        var detail1 = personalDetails[0];
                        var detail2 = personalDetails[1];
                        Console.WriteLine($"---{detail1}: {detail2}");
                    }
                    //Last: check keys length and values lenght
                    int keyLength = kvp.Key.Length;
                    int valuesLength = kvp.Value.Sum(a => a.Length - 1);
                    int index = keyLength + valuesLength;

                    if (valuesLength >= targetInfoIndex)
                    {
                        Console.WriteLine($"Info index: {valuesLength}");
                        Console.WriteLine("Proceed");
                    }
                    else
                    {
                        var diference = Math.Abs(targetInfoIndex - valuesLength);
                        Console.WriteLine($"Info index: {valuesLength}");
                        Console.WriteLine($"Need {diference} more info.");
                    }
                }

            }

        }
    }
}
