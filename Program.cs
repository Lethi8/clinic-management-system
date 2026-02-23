using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Patient_system
{
    internal class Program
    {
        class Patient //Declaring the patient class with its properties
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Condition { get; set; }

            public Patient(string name, int age, string condition) //sets the name, age and condition of the Patient class
            {
                this.Name = name;
                this.Age = age;
                this.Condition = condition;
            }

            public override string ToString()
            {
                return $"Name: {Name}, Age: {Age}, Condition: {Condition}";
                
            }

        }

        class Patients
        {
            private readonly List<Patient> patients = new List<Patient>();

            public Patients()
            {
                //automatically adds sample data provided
                patients.AddRange(new List<Patient>
                {
                    new Patient ("Sarah Mokoena", 34, "Hypertension" ),
                    new Patient ("Thabo Ndlovu",29,"Asthma" ),
                    new Patient ("Nomsa Dlamini", 41, "Diabetes"),
                    new Patient ("Kabelo Molefe", 37, "High Cholesterol"),
                    new Patient ("Lerato Khumalo", 22, "Flu"),
                    new Patient ("Siphiwe Ntuli", 60, "Arthritis"),
                    new Patient ("Ayanda Zulu", 19, "Migraine"),
                    new Patient ("Boitumelo Mthembu", 28, "Allergies"),
                    new Patient ("Tshepo Mabena", 45, "Back Pain"),
                    new Patient ("Zanele Hlophe", 33, "Anxiety"),
                });
            }

            public void AddPatient()
            {

                Console.WriteLine("Enter patient details: ");
                Console.WriteLine("**********************");
                Console.WriteLine("Name: ");
                string Name = Console.ReadLine();

                Console.WriteLine("Age: ");
                int Age = int.Parse(Console.ReadLine());

                Console.WriteLine("Medical Condition: ");
                string Condition = Console.ReadLine();



                patients.Add(new Patient(Name, Age, Condition)); //creates an instance of patients using constructor parameters
                Console.WriteLine($"Patient added: Name: {Name} Age: {Age} Condition: {Condition}");
                Console.WriteLine("Patient added successfully.");

            }

            public void RemovePatient() //method that removes specified patients
            {
                Console.WriteLine("Enter the name of the patient to remove: ");
                string Name = Console.ReadLine();

                var patientName = patients.FirstOrDefault(p => p.Name == Name); //condition that checks if the selected patient is found in the list


                if (patientName != null)
                {
                    patients.Remove(patientName); //removes specified patient name
                    Console.WriteLine($"Patient {Name} removed successfully.");
                    Console.WriteLine();
                    Console.WriteLine("Patient removed successfully.");
                }
                else
                {
                    Console.WriteLine("Patient was not found in the list."); //shows user that specified name was not found
                }
            }

            //method used to look for patients
            public void SearchPatient()
            {
                Console.WriteLine("Enter the name of the patient to search: ");
                Console.WriteLine();
                string Name = Console.ReadLine();

                var patientName = patients.FirstOrDefault(p => p.Name == Name); //condition that looks patient given by user

                if (patientName != null)
                {
                    Console.WriteLine($"Name: {patientName.Name} Age: {patientName.Age} Condition: {patientName.Condition}");
                }
                else
                {
                    Console.WriteLine("Patient was not found in the list.");
                }
            }

            public void DisplayAllPatients() //method that prints out all patients registered
            {
                Console.WriteLine("Registered Patients: ");
                Console.WriteLine();

                if (patients.Count == 0) //if the list is empty
                {
                    Console.WriteLine("No patients were registered.");
                    Console.WriteLine();
                }
                else
                {
                    foreach (var patient in patients) //shows each patient with their details
                    {
                        Console.WriteLine(patient);
                        Console.WriteLine();
                        
                    }
                }

            }
            public static void Exit() //method that helps the user to exit out of the menu
            {
                Console.WriteLine("You have chosen to exit out of the system. Goodbye!");
                Console.WriteLine();
            }
        }
        class PatientInformation
        {
            static string filename = "Patient_Information.txt"; //file anme where information will be printed to

            //Method to write sample data to Patient_information.txt
            public static void WriteToFile()
            {

                //string array of Patient data that should be written to the file
                string[] patientData =
                {
                    "Name: Sarah Mokoena, Age: 34, Condition: Hypertension",
                    "Name: Thabo Ndlovu, Age: 29, Condition: Asthma",
                    "Name: Nomsa Dlamini, Age: 41, Condition: Diabetes",
                    "Name: Kabelo Molefe, Age: 37, Condition: High Cholesterol",
                    "Name: Lerato Khumalo, Age: 22, Condition: Flu",
                    "Name: Siphiwe Ntuli, Age: 60, Condition: Arthritis",
                    "Name: Ayanda Zulu, Age: 19, Condition: Migraine",
                    "Name: Boitumelo Mthembu, Age: 28, Condition: Allergies",
                    "Name: Tshepo Mabena, Age: 45, Condition: Back Pain",
                    "Name: Zanele Hlope, Age: 33, Condition: Anxiety"
                };

                string filePath = @"Patient_Information.txt"; //initializes string variable with the file path

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))  //creates new file
                    {
                        foreach (string patient in patientData) //goes through each patient in patient data
                        {
                            writer.WriteLine(patient); //prints each patient from PatientData to file
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Patient information printed to file: {filename}"); //shows to user that file was successfully created
                    }
                }
                catch (IOException ex) //catches any errors that migh occur
                {
                    Console.WriteLine($"There was an error while wriitng data to this file: {ex.Message}"); //error message shown to the user
                }

            }
        }

        static void Main(string[] args)
        {
            bool running = true;
            Patients patients = new Patients();

            do
            {
                //menu for the clinic patient system 
                Console.WriteLine();
                Console.WriteLine("Welcome to our clinic patient management system!");
                Console.WriteLine("************************************************");
                Console.WriteLine();
                Console.WriteLine("Please select a valid option from the menu below: ");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Remove Patient");
                Console.WriteLine("3. Search Patient");
                Console.WriteLine("4. Display All Patients");
                Console.WriteLine("5. Print patient information to file"); //added feature for question 2
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine()); //receives input from user for their choice
                Console.WriteLine();


                switch (choice)
                {
                    case 1:
                        patients.AddPatient();
                        break;

                    case 2:
                        patients.RemovePatient();
                        break;
                    case 3:
                        patients.SearchPatient();
                        break;

                    case 4:
                        patients.DisplayAllPatients();
                        break;

                    case 5:
                        PatientInformation.WriteToFile();
                        break;

                    case 6:
                        Patients.Exit();
                        running = false;
                        break;


                    default:
                        Console.WriteLine("Select a valid option.");
                        break;
                }

            } while (running);
        }
    }
}
