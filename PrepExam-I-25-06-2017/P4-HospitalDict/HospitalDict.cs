using System;
using System.Collections.Generic;
using System.Linq;

namespace P4_HospitalDict
{
    class HospitalDict
    {
        static void Main() // 100/100, но заради грешка на 78 ред даваше 50/100 
        {
            var departPatient = new Dictionary<string, List<string>>();
            var doctorPatient = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine().Trim()) != "Output")
            {
                var inputDetails = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string department = inputDetails[0];
                string doctor = $"{inputDetails[1]} {inputDetails[2]}";
                string patientName = inputDetails[3];

               
                if (!departPatient.ContainsKey(department))
                {
                    departPatient[department] = new List<string>();
                }
                if (departPatient[department].Count >= 60)
                {
                    continue;
                }
                departPatient[department].Add(patientName);


                if (!doctorPatient.ContainsKey(doctor))
                {
                    doctorPatient[doctor] = new List<string>();
                }
                doctorPatient[doctor].Add(patientName);                                              
            }

            var commands = new List<string>();
            string output;
            while ((output = Console.ReadLine()) != "End")
            {
                commands.Add(output);
            }

            PrintResult(commands, departPatient, doctorPatient);
        }

        private static void PrintResult(List<string> commands, Dictionary<string, List<string>> departPatient, Dictionary<string, List<string>> doctorPatient)
        {
            foreach (var command in commands)
            {
                var outputDetails = command.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (outputDetails.Length == 1)
                {
                    var persons = departPatient.Where(d => d.Key == outputDetails[0]).ToDictionary(d => d.Key, d => d.Value);
                    foreach (var kvp in persons.Values)
                    {
                        foreach (var k in kvp)
                        {
                            Console.WriteLine(k);
                        }
                    }
                }
                else
                {
                    int notNum = 0;
                    var last = outputDetails[1];
                    if (int.TryParse(last, out notNum))
                    {
                        var desiredRoom = int.Parse(last);
                        var persons = departPatient.Where(d => d.Key == outputDetails[0]).ToDictionary(d => d.Key, d => d.Value);
                        foreach (var kvp in persons.Values)
                        {
                            //foreach (var k in kvp.Skip(desiredRoom - 1 % 3).Take(3).OrderBy(n => n)) - така даваше 50/100
                            foreach (var k in kvp.Skip((desiredRoom * 3) - 3).Take(3).OrderBy(n => n)) // това е! 100/100
                            {
                                Console.WriteLine(k);
                            }
                        }
                    }
                    else
                    {
                        var doctor = $"{outputDetails[0]} {outputDetails[1]}";
                        var persons = doctorPatient.Where(d => d.Key == doctor).ToDictionary(d => d.Key, d => d.Value);
                        foreach (var kvp in persons.Values)
                        {
                            foreach (var k in kvp.OrderBy(n => n))
                            {
                                Console.WriteLine(k);
                            }
                        }
                    }
                }


            }
        }
    }
}
