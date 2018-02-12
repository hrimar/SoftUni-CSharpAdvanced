using System;
using System.Collections.Generic;
using System.Linq;

namespace P4_HospitalClass
{
    public class Patient
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Doctor { get; set; }
    }

    class HospitalClass
    {
        static void Main()  // 100/100
        {
            var patientsList = new List<Patient>();
            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] inputArgs = input.Split();
                string departmentName = inputArgs[0];
                string docFisrtName = inputArgs[1];
                string docLastName = inputArgs[2];
                string doctorName = $"{docFisrtName} {docLastName}";
                string patientName = inputArgs[3];

                Patient patient = new Patient()
                {
                    Name = patientName,
                    Department = departmentName,
                    Doctor = doctorName
                };

                patientsList.Add(patient);
            }

            string output;
            while ((output = Console.ReadLine()) != "End")
            {
                var outputDetails = output.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (outputDetails.Length == 1)
                {
                    var persons = patientsList.Where(d => d.Department == outputDetails[0]);
                    foreach (var p in persons)
                    {
                        Console.WriteLine(p.Name);
                    }
                }
                else
                {
                    int notNum = 0;
                    var last = outputDetails[1];
                    if (int.TryParse(last, out notNum))
                    {
                        var departmentPatients = new List<Patient>();
                        int roomNumber = int.Parse(last);
                        // 1. Филтрираме по департамент:
                        foreach (var patient in patientsList
                            .Where(p => p.Department == outputDetails[0]))
                        {
                            departmentPatients.Add(patient);
                        }
                        // 2. Филтрираме по номер на стая:
                        var result = new List<Patient>();
                        for (int i = 0; i < departmentPatients.Count; i++)
                        {
                            if (Math.Ceiling((i + 1) / 3.0) == roomNumber) // !!!
                            {
                                var patient = departmentPatients[i];
                                result.Add(patient);
                            }
                        }
                        // 3. Принт от двете филтрации:
                        foreach (var patient in result.OrderBy(p => p.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    else
                    {
                        var doctor = $"{outputDetails[0]} {outputDetails[1]}";
                        var desiredRoom = (last);
                        var persons = patientsList.Where(d => d.Doctor == doctor);
                        foreach (var p in persons.OrderBy(p => p.Name))
                        {
                            Console.WriteLine(p.Name);
                        }
                    }

                }
               
            }
        }
    }
}

