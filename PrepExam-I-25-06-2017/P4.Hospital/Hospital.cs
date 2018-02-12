using System;
using System.Collections.Generic;
using System.Linq;

namespace P4.Hospital
{
    // Май така трябва да се структуритат класовете:
    //class Department
    //{
    //    public Department(string name)
    //    {
    //        this.Name = name;

    //        this.Rooms = new List<Room>();
    //        for (int i = 0; i < 20; i++)
    //        {
    //            Rooms.Add(new Room());
    //        }
    //    }

    //    public string Name { get; set; }
    //    public List<Room> Rooms { get; set; }
    //}

    //class Doctor
    //{
    //    public Doctor(string firstName, string lastName)
    //    {
    //        this.FirstName = firstName;
    //        this.LastName = lastName;
    //        this.Patients = new List<string>();
    //    }

    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public List<string> Patients { get; set; }
    //}

    //class Room
    //{
    //    public Room()
    //    {
    //        this.Patients = new List<string>();
    //    }

    //    public List<string> Patients { get; set; }
    //}


    public class Patient
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Doctor { get; set; }
        public int RoomNumber { get; set; }
    }

    public class Hospital // баааасси Нулевите тестове минават а имам 0/100? По-добро е решението с Dicts! !!!
    {
        static void Main()
        {
            int roomNumberCardiology = 1;
            int roomNumberOncology = 1;
            int roomNumberEmergency = 1;
            int personsCountCardiology = 0;
            int personsCountOncology = 0;
            int personsCountEmergency = 0;

            var patientsList = new List<Patient>();
            string input;
            while ((input = Console.ReadLine()) != "Output")
            {                
                var inputDetails = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string department = inputDetails[0];
                string doctor = $"{inputDetails[1]} {inputDetails[2]}";
                string patientName = inputDetails[3];

                if (department == "Cardiology")
                {
                    personsCountCardiology++;
                    if (personsCountCardiology > 3 && personsCountCardiology<60)
                    {
                        roomNumberCardiology++;
                    }
                    var patientCardio = new Patient()
                    {
                        Name = patientName,
                        Department = department,
                        Doctor = doctor,
                        RoomNumber = roomNumberCardiology
                    };
                    patientsList.Add(patientCardio);
                }
                else if (department == "Oncology")
                {
                    personsCountOncology++;
                    if (personsCountOncology > 3 && personsCountOncology<60)
                    {
                        roomNumberOncology++;
                    }
                    var patientOnco = new Patient()
                    {
                        Name = patientName,
                        Department = department,
                        Doctor = doctor,
                        RoomNumber = roomNumberOncology
                    };
                    patientsList.Add(patientOnco);
                }
                else if (department == "Emergency")
                {
                    personsCountEmergency++;
                    if (personsCountEmergency > 3 && personsCountEmergency<60)
                    {
                        roomNumberEmergency++;
                    }
                    var patientEmer = new Patient()
                    {
                        Name = patientName,
                        Department = department,
                        Doctor = doctor,
                        RoomNumber = roomNumberEmergency
                    };
                    patientsList.Add(patientEmer);
                }

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
                        //var desiredRoom = int.Parse(last);
                        //var persons = patientsList.Where(d => d.Department == outputDetails[0]).Where(d => d.RoomNumber == desiredRoom);
                        //foreach (var p in persons.OrderBy(p => p.Name))
                        //{
                        //    Console.WriteLine(p.Name);
                        //}
                        var departmentPatients = new List<Patient>();
                        int roomNumber = int.Parse(last);

                        foreach (var patient in patientsList
                            .Where(p => p.Department == outputDetails[0]))
                        {
                            departmentPatients.Add(patient);
                        }

                        var result = new List<Patient>();
                        for (int i = 0; i < departmentPatients.Count; i++)
                        {
                            if (Math.Ceiling((i + 1) / 3.0) == roomNumber)
                            {
                                var patient = departmentPatients[i];
                                result.Add(patient);
                            }
                        }

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
